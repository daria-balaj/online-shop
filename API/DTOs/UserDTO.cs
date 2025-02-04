namespace API.DTOs;

public class UserDTO
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; }
    public string Token { get; set; }
    public string Role { get; set; } = "customer";

}