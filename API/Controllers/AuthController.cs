using API.DTOs;
using API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace API.Controllers 
{
    [ApiController]
    [Route("")]
    public class AuthController : ControllerBase 
    {
        private readonly UserManager<User> _userService;
        private readonly IMapper _mapper;
        public AuthController(UserManager<User> userManager, IMapper mapper)
        {
            _userService = userManager;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult TestEndpoint()
        {
            Console.WriteLine("200 Ok");
            return Ok("Endpoint reached");
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> CreateAccount([FromBody] RegisterDTO user) 
        {
            //if email isn't used by another user
            User newUser = _mapper.Map<User>(user);
            var result = await this._userService.CreateAsync(newUser, user.Password);

            if(!result.Succeeded)
                return BadRequest(result.Errors);
            
            return newUser;
        }

        // [HttpPost("login")]
        // public async Task<ActionResult> Login(LoginDTO loginModel)
        // {

        // }

    }

}