using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SwitchAcademy.Persistence.DTOs;
using SwitchAcademy.Persistence.Responses;
using SwitchAcademy.Services.Interfaces;

namespace SwitchAcademy.Controllers
{
    [Route("api/v1/auth")]
    [ApiController]
    [Produces("application/json")]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        private readonly ILogger<AuthController> _logger;

        public AuthController(IAuthService authService, ILogger<AuthController> logger)
        {
            _authService = authService;
            _logger = logger;
        }


        [HttpPost("login")]
        public async Task<ActionResult<LoginResponse>> Login(LoginDto request)
        {
            _logger.LogInformation($"Processing request {JsonConvert.SerializeObject(request)}");
            var response = await _authService.Login(request);
            _logger.LogInformation($"Response gotten from auth Service {JsonConvert.SerializeObject(response)}");
            if (response.IsSuccessful)
                return Ok(response);
            return BadRequest(response);
        }

        [HttpPost("register")]
        public async Task<ActionResult<DefaultResponse>> Register(RegisterDto request)
        {
            _logger.LogInformation($"Processing request {JsonConvert.SerializeObject(request)}");
            var response = await _authService.Registration(request);
            _logger.LogInformation($"Response gotten from auth Service {JsonConvert.SerializeObject(response)}");
            if (response.IsSuccessful)
                return Ok(response);
            return BadRequest(response);
        }

    }
}
