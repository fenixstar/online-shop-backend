namespace online_shop_backend.Models.DTO;

public class RefreshTokenDto
{
    public string RefreshToken { get; set; }
    public UserDto User { get; set; }
}