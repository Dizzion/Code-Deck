using System.Threading.Tasks;
using CodeDeckAPI.Data;
using CodeDeckAPI.Dtos;
using CodeDeckAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CodeDeckAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("/api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepo _authRepo;
        public AuthController(IAuthRepo authRepo)
        {
            _authRepo = authRepo;

        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterDto userRegisterDto) 
        {
            ServiceResponse<int> response = await _authRepo.Register(
                new User { Username = userRegisterDto.Username }, userRegisterDto.Password
            );
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserLoginDto userLoginDto) 
        {
            ServiceResponse<string> response = await _authRepo.Login(
                userLoginDto.Username, userLoginDto.Password
            );
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpGet("User/{username}")]
        public ActionResult <UserReadDto> GetUserByUsername(string username)
        {
            var userItem = _authRepo.GetUserByUsername(username);

            if(userItem == null)
            {
                return NotFound();
            }
            return Ok(userItem);
        }
    }
}