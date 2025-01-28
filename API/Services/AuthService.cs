using API.DTOs;
using API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using System.Security.Claims;
using Microsoft.IdentityModel;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using API.Data;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace API.Services;

public class AuthService(IConfiguration _config, DataContext _context, IMapper _mapper) : IAuthService
{
    public IEnumerable<User> GetAllUsers()
    {
        return _context.Users.AsEnumerable();
    }

    public async Task<User?> RegisterAsync(RegisterDTO request)
    {
        if (await _context.Users.AnyAsync(x => x.Email == request.Email))
            return null;

        User newUser = _mapper.Map<User>(request);
        newUser.PasswordHash = new PasswordHasher<User>().HashPassword(newUser, request.Password);
        _context.Users.Add(newUser);
        await _context.SaveChangesAsync();

        return newUser;
    }

    public async Task<TokenDTO?> LoginAsync(LoginDTO request)
    {
        var account = await _context.Users.FirstOrDefaultAsync(acc => acc.Email == request.Email);
        if (account == null) return null;

        if (new PasswordHasher<User>().VerifyHashedPassword(account, account.PasswordHash!, request.Password)
            == PasswordVerificationResult.Failed)
            return null;
        return await CreateTokenResponse(account);
    }

    private async Task<TokenDTO?> CreateTokenResponse(User account)
    {
        return new TokenDTO
        {
            AccessToken = CreateToken(account),
            RefreshToken = await SaveNewRefreshToken(account)
        };
    }

    private string CreateToken(User user)
    {
        var claims = new Dictionary<string, object>
        {
            [ClaimTypes.Email] = user.Email,
            [ClaimTypes.Role] = user.Role
        };
        var key = new SymmetricSecurityKey(
            System.Text.Encoding.UTF8.GetBytes(_config.GetValue<string>("Key")!));

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

        var descriptor = new SecurityTokenDescriptor{
            Issuer = _config.GetValue<string>("Issuer"),
            Claims = claims,
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = creds
        };

        var handler = new JsonWebTokenHandler();
        handler.SetDefaultTimesOnTokenCreation = false;
        return handler.CreateToken(descriptor);
        
    }

    private string GenerateRefreshToken()
    {
        var randomNumber = new byte[32];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomNumber);
        return Convert.ToBase64String(randomNumber);
    }

    private async Task<string> SaveNewRefreshToken(User user)
    {
        user.RefreshToken = GenerateRefreshToken();
        user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);
        await _context.SaveChangesAsync();
        return user.RefreshToken;
    }

    public async Task<TokenDTO?> RefreshTokenAsync(RefreshTokenRequestDTO request)
    {
        var user = await ValidateRefreshToken(request);
        if (user == null)
            return null;

        return await CreateTokenResponse(user);
           
    }




    private async Task<User?> ValidateRefreshToken(RefreshTokenRequestDTO request)
    {
        var user = await _context.Users.FindAsync(request.UserID);
        if (user is null || user.RefreshToken != request.RefreshToken
        //  || user.RefreshTokenExpiryTime < DateTime.UtcNow
         )
            return null;
        
        await SaveNewRefreshToken(user);
        return user;
    }
}