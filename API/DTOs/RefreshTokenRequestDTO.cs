namespace API.DTOs;

public class RefreshTokenRequestDTO
{
    public int UserID { get; set; }
    public required string RefreshToken { get; set; }
}