using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using online_shop_backend.Models.DTO;
using online_shop_backend.Models.Entities;
using online_shop_backend.Models.Identity;
using online_shop_backend.Repositories.Interfaces;
using online_shop_backend.Services.Interfaces;
using online_shop_backend.Utils;

namespace online_shop_backend.Controllers;

[Route("/api/account")]
[AllowAnonymous]
public class AccountController(
    UserManager<ApplicationUser> userManager,
        IRefreshTokenRepository refreshTokenRepository,
        IConfiguration configuration,
        IUserDetailRepository userDetailRepository,
        IMailService mailService)
    : Controller
{
    [HttpPost("details")]
    [Authorize]
    public async Task<List<UserDetail>> GetCurrentUserDetails([FromBody] UserDto user)
    {
        if (user.Username == null) return null;

        var retrievedUser = await userManager.FindByNameAsync(user.Username);

        var result = userDetailRepository.GetDetailsForUser(retrievedUser.Id).ToList();
        result[0].ApplicationUser = retrievedUser;

        return result;
    }

    [HttpPost("update-address")]
    [Authorize]
    public async Task<IActionResult> UpdateUserAddress([FromBody] AddressDto address)
    {
        var user = await userManager.FindByNameAsync(address.Username);

        var userDetails = userDetailRepository.GetDetailsForUser(user?.Id).ToList();

        if (userDetails.Count > 0 && !string.IsNullOrEmpty(userDetails[0].Address1))
            return BadRequest(new { message = "Address already set" });

        userDetails[0].Address1 = address.Address1;
        userDetails[0].Address2 = address.Address2;
        userDetails[0].Address3 = address.Address3;

        userDetailRepository.UpdateUserDetail(userDetails[0]);

        return Ok();
    }

    [HttpPost("update")]
    [Authorize]
    public async Task<IActionResult> UpdateAccount([FromBody] AccountPageDto account)
    {
        var user = await userManager.FindByNameAsync(account.User.Username);
        var details = userDetailRepository.GetDetailsForUser(user?.Id).ToList();

        user.Email = account.User.Email;

        if (userManager.PasswordHasher.HashPassword(user, account.User.Password) != user.PasswordHash)
        {
            await userManager.ChangePasswordAsync(user,
                account.User.PasswordConfirm,
                account.User.Password);
        }

        details[0].Name = account.User.Name;

        details[0].Surname = account.User.Surname;

        details[0].Address1 = account.Address.Address1;

        details[0].Address2 = account.Address.Address2;

        details[0].Address2 = account.Address.Address2;

        user.Details = details;

        var result = await userManager.UpdateAsync(user);

        return result.Succeeded ? Ok() : BadRequest(new { message = "Update not successful" });
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] UserDto user)
    {
        var userToAdd = new ApplicationUser
        {
            UserName = user.Username,
            Email = user.Email,
            Details = new List<UserDetail>
            {
                new()
                {
                    Name = user.Name,
                    Surname = user.Surname
                }
            }
        };

        var result = await userManager.CreateAsync(userToAdd, user.Password);

        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(userToAdd, Constants.User);
            await userManager.AddToRoleAsync(userToAdd, Constants.Moderator);
            await userManager.AddToRoleAsync(userToAdd, Constants.Admin);
            await mailService.SendEmailAsync(user.Email, user.Name, "Welcome to VetUniverse", "Welcome to VetUniverse");
        }

        return result.Succeeded
            ? Ok((IdentityResult.Success, userToAdd.Id))
            : BadRequest(IdentityResult.Failed((result.Errors as IdentityError[])!));
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] UserDto userDto)
    {
        if (string.IsNullOrEmpty(userDto.Username) || string.IsNullOrEmpty(userDto.Password))
            return BadRequest("Username/password cannot be empty");

        var user = await userManager.FindByNameAsync(userDto.Username);

        if (user != null && await userManager.CheckPasswordAsync(user, userDto.Password))
        {
            var refreshToken = TokenFactory.GenerateToken();

            refreshTokenRepository.AddRefreshToken(
                new RefreshToken
                {
                    Token = refreshToken,
                    ApplicationUserId = user.Id,
                    ExpiryDate = DateTime.Now.AddDays(30).ToUniversalTime()
                });

            var jwt = await GenerateJwt(user);

            return Ok(new { jwt, refreshToken });
        }

        return Unauthorized("Invalid username/password");
    }

    [HttpPost("refresh")]
    public async Task<IActionResult> Refresh([FromBody] RefreshTokenDto tokenDto)
    {
        if (refreshTokenRepository.IsRefreshTokenActive(tokenDto.RefreshToken))
        {
            var user = await userManager.FindByNameAsync(tokenDto.User.Username);
            var jwt = await GenerateJwt(user);

            return Ok(new { jwt, tokenDto.RefreshToken });
        }

        return BadRequest("Invalid refresh token");
    }

    private async Task<string> GenerateJwt(ApplicationUser user)
    {
        var secretKey = Encoding.ASCII.GetBytes(configuration["SecretKey"]!);

        var claims = (await userManager.GetRolesAsync(user))
            .Select(r => new Claim("role", r));

        var token = new JwtSecurityToken(configuration["Issuer"], configuration["Issuer"],
            claims, null, DateTime.UtcNow.AddHours(6), new SigningCredentials(
                new SymmetricSecurityKey(secretKey), SecurityAlgorithms.HmacSha256Signature));

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}