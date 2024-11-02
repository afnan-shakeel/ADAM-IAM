using Application.DTOs;
using Core.Entities;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;


        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpPost("search")]
        public async Task<IActionResult> SearchUser([FromBody] UserDto userDto)
        {
            _logger.LogInformation($"Searching for user: {userDto.UserName}");
            var userDtoRes = await _userService.GetByUsernameAsync(userDto.UserName);
            if (userDtoRes == null)
            {
                // _logger.LogWarning($"User not found: {username}");
                return NotFound("User not found");
            }
            return Ok(userDtoRes);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(User user)
        {
            _logger.LogInformation($"Registering user: {user.Username}");
            var result = await _userService.RegisterUserAsync(user);
            return Ok(result);
        }

        [HttpGet]
        public IActionResult TestException()
        {
            throw new Exception("This is a test exception");
        }
    }
}