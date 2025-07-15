using ExpenseAppAPI.Application.DTOs;
using ExpenseAppAPI.Application.Response;
using ExpenseAppAPI.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly MemberService _service;

        public MemberController(MemberService service)
        {
            _service = service;
        }
        [HttpPost("/AddMembers")]
        public async Task<ApiResponse<MemberDto>> AddMembers([FromForm] List<MemberDto> data)
        {
            if (data == null)
            {
                return new ApiResponse<MemberDto>("Member cannot be empty", null!);
            }
            else
            {
                var response = await _service.AddMembers(data!);
                return response;
            }
        }
    }
}
