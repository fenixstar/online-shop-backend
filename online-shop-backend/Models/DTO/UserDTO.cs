namespace online_shop_backend.Models.DTO;

public class UserDto
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string PasswordConfirm { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
}