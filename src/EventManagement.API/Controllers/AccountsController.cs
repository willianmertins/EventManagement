using EventManagement.Application.DTOs;
using EventManagement.Application.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace EventManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountsController(RegisterUserUseCase registerUserCase, LoginUserUseCase loginUserUseCase) : ControllerBase
    {
        private readonly RegisterUserUseCase _registerUserUseCase = registerUserCase ?? throw new ArgumentNullException(nameof(registerUserCase));
        private readonly LoginUserUseCase _loginUserUseCase = loginUserUseCase ?? throw new ArgumentNullException(nameof(loginUserUseCase));

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterUserRequest request)
        {
            var result = await _registerUserUseCase.ExecuteAsync(request);
            return !result.Succeeded ? BadRequest(result) : Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var result = await _loginUserUseCase.ExecuteAsync(request);
            return !result.Succeeded ? BadRequest(result) : Ok(result);
        }
    }
}
