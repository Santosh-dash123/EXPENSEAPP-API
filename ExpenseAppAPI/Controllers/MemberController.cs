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
        [Consumes("multipart/form-data")]
        public async Task<ApiResponse<bool>> AddMembers([FromForm] ListOfMember data)
        {
            if (data == null)
            {
                return new ApiResponse<bool>("Member cannot be empty", false);
            }
            else
            {
                var response = await _service.AddMembers(data!);
                return response;
            }
        }
        [HttpPost("/UpdateMembers")]
        public async Task<ApiResponse<bool>> UpdateMembers([FromForm] MemberDto data)
        {
            if (data == null)
            {
                return new ApiResponse<bool>("Member cannot be empty", false);
            }
            else
            {
                var response = await _service.UpdateMembers(data!);
                return response;
            }
        }
        [HttpPost("/DeleteMembers")]
        public async Task<ApiResponse<bool>> DeleteMembers(int Id)
        {
            if (Id == 0)
            {
                return new ApiResponse<bool>("Member cannot be empty", false);
            }
            else
            {
                var response = await _service.DeleteMembers(Id!);
                return response;
            }
        }

        [HttpGet("/GetAllMembers/{RoomOwnerId}/{WhichTypeDataGet}")]
        public async Task<ApiResponse<List<GetMembersByRoomOwnerDto>>> GetAllMembers(int RoomOwnerId,string WhichTypeDataGet)
        {
            if(RoomOwnerId != 0)
            {
                var response = await _service.GetAllMembers(RoomOwnerId, WhichTypeDataGet);
                return response;
            }
            else
            {
                return null!;
            }
        }
    }
}
