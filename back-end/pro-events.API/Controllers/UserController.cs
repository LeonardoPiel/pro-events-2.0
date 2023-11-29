using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using pro_events.API.Extensions;
using pro_events.Application.DTO.Users;
using pro_events.Application.IServices;
using System.Reflection;
using System.Security.Claims;

namespace pro_events.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;

        public UserController(IUserService userService, ITokenService tokenService)
        {
            this._userService = userService;
            this._tokenService = tokenService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var username = User.GetUserName();
                var user = await _userService.GetUserByUserName(username);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Error while requesting. Message: {ex.Message}.");
            }
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromBody] UserSaveDto userDto)
        {
            try
            {
                var ret = await _userService.CreateUser(userDto);
                var rs = new 
                {
                    data = ret,
                    jwt = _tokenService.GenerateToken(ret).Result
                };
                return ret != null ? Ok(rs) : StatusCode(StatusCodes.Status500InternalServerError, $"Error while requesting.");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Error while requesting. Message: {ex.Message}.");
            }
        }
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] UserLoginDto login)
        {
            try
            {
                var user = await _userService.GetUserByUserName(login.UserName);
                if (user == null) return Unauthorized("User not found");
                var checkPassword = await _userService.CheckUserPassword(user, login.Password);
                if (!checkPassword.Succeeded) return Unauthorized("Incorrect password");

                var ret = new
                {
                    jwt = _tokenService.GenerateToken(user).Result
                };
                return ret != null ? Ok(ret) : StatusCode(StatusCodes.Status500InternalServerError, $"Error while requesting.");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Error while requesting. Message: {ex.Message}.");
            }
        }
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UserSaveDto userDto)
        {
            try
            {
                var user = await _userService.GetUserByUserName(User.GetUserName());
                if (user == null) return Unauthorized("User not found");


                var ret = await _userService.UpdateUser(userDto);
                return ret != null ? Ok(ret) : StatusCode(StatusCodes.Status500InternalServerError, $"Error while requesting.");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Error while requesting. Message: {ex.Message}.");
            }
        }
    }
}
