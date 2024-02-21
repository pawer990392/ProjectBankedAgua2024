using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WaterSystem.Application.Dtos.Request;
using WaterSystem.Application.Interfaces;

namespace WaterSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly IUserApplication _userApplication;

        public UserController(IUserApplication userApplication)
        {
            _userApplication = userApplication;
        }
        [AllowAnonymous]
        [HttpPost("RegisterUser")]
        public async Task<IActionResult> RegisterUser([FromBody] UserRequestDto requestDto)
        {
            var response = await _userApplication.RegisterUser(requestDto);
            return Ok(response);
        }
        [AllowAnonymous]
        [HttpPost("Generate/Token")]
        public async Task<IActionResult> GnerateToken([FromBody] TokenRequestDto requestDto)
        {
            var response = await _userApplication.GenereToken(requestDto);
            return Ok(response);
        }

    }
}
