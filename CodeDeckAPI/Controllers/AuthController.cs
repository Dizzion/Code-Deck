using System.Threading.Tasks;
using CodeDeckAPI.Data;
using CodeDeckAPI.Dtos;
using CodeDeckAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodeDeckAPI.Controllers
{
    [ApiController]
    [Route("/api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepo _authRepo;
        public AuthController(IAuthRepo authRepo)
        {
            _authRepo = authRepo;

        }

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
    }
}