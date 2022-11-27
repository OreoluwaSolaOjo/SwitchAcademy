using Microsoft.AspNetCore.Mvc;
using SwitchAcademy.Persistence.DTOs;
using SwitchAcademy.Persistence.Responses;
using SwitchAcademy.Services.Interfaces;

namespace SwitchAcademy.Controllers
{
    [Route("api/v1/users")]
    [ApiController]
    [Produces("application/json")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("get-users")]
        public async Task<ActionResult<AllUsersResponse<GetUserDto>>> GetAll()
        {
            var response = await _userService.GetAllUsers();
            if (response.IsSuccessful)
                return Ok(response);
            return BadRequest(response);
        }

        [HttpGet("get-user/{Id}")]
        public async Task<ActionResult<GetSingleUserResponse<GetUserDto>>> GetUserById(int Id)
        {
            var response = await _userService.GetUserById(Id);
            if (response.IsSuccessful)
                return Ok(response);
            return BadRequest(response);
        }

        [HttpPost("update-user/{Id}")]
        public async Task<ActionResult<GetSingleUserResponse<GetUserDto>>> UpdateUser(int Id, [FromBody] UpdateUserDto request)
        {
            var response = await _userService.UpdateUser(Id, request);
            if (response.IsSuccessful)
                return Ok(response);
            return BadRequest(response);
        }


    }
}
