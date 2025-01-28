using API.DTOs;
using API.Models;

namespace API.Services;

public interface IAuthService
{
    public Task<User?> RegisterAsync(RegisterDTO request);
    public Task<TokenDTO?> LoginAsync(LoginDTO request);
    // public Task<UserDTO?> LoginAsync(LoginDTO request);
    public Task<TokenDTO?> RefreshTokenAsync(RefreshTokenRequestDTO request);

    public IEnumerable<User> GetAllUsers();

}