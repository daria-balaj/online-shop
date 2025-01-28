using API.DTOs;
using API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using System.Security.Claims;
using Microsoft.IdentityModel;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using API.Services;


namespace API.Controllers 
{
    [ApiController]
    [Route("api")]
    public class AuthController : BaseAPIController 
    {
        // private readonly UserManager<User> _userService;
        // private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        private readonly IAuthService _authService;
        public AuthController(IConfiguration configuration, IAuthService authService)
        {
            // _userService = userManager;
            // _mapper = mapper;
            _config = configuration;
            _authService = authService;
        }

        [HttpGet("get-users")]
        public IEnumerable<User> GetAllUsers()
        {
            return _authService.GetAllUsers();
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register([FromBody] RegisterDTO request) 
        {
            var user = await _authService.RegisterAsync(request);
            if (user is null) return BadRequest("Invalid input");
            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<ActionResult<TokenDTO>> Login([FromBody] LoginDTO loginModel)
        {
            var token = await _authService.LoginAsync(loginModel);
            if (token is null) return Unauthorized("Incorrect email or password");
            return Ok(token);
        }

    
        // [HttpPost("login")]
        // public async Task<ActionResult<UserDTO>> Login([FromBody] LoginDTO loginModel)
        // {
        //     var user = await _authService.LoginAsync(loginModel);
        //     if (user is null) return BadRequest("Incorrect email or password");
        //     return Ok(user);
        // }

        [HttpPost("refresh-token")]
        public async Task<ActionResult<TokenDTO>> RefreshToken(RefreshTokenRequestDTO request)
        {
            var result = await _authService.RefreshTokenAsync(request);
            if (result is null)
                return BadRequest("User is null");
                
            if (result.RefreshToken is null)
                return BadRequest("Invalid refresh token");
            // if (result is null || result.AccessToken is null || result.RefreshToken is null)
            //     return BadRequest("Invalid refresh token");
                
            return Ok(result);
        }

    }

}