using ExpenseAppAPI.Application.DTOs;
using ExpenseAppAPI.Application.Response;
using ExpenseAppAPI.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ManageUserService _service;

        public UserController(ManageUserService service)
        {
            _service = service;
        }
        [HttpPost]
        [Route("/CheckLogin")]
        public async Task<ActionResult<ApiResponse<ManageUserDto>>> CheckLogin([FromBody] ManageUserDto dto)
        {
            var result = await _service.CheckLogin(dto);

            if (result != null)
            {
                var response = new ApiResponse<ManageUserDto>("Login Successfully", result);
                return Ok(response);
            }
            else
            {
                var response = new ApiResponse<ManageUserDto>("Login Failed", null);
                return Unauthorized(response);
            }
        }

    }
}
