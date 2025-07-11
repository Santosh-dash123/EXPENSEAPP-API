using ExpenseAppAPI.Application.DTOs;
using ExpenseAppAPI.Application.Response;
using ExpenseAppAPI.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly RoomService _service;

        public RoomsController(RoomService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("/GetRooms")]
        public async Task<ActionResult<List<RoomDto>>> GetRooms()
        {
            return Ok(await _service.GetAllRooms());
        }

        [HttpGet]
        [Route("/GetParticularRoom/{id}")]
        public async Task<ActionResult<List<RoomDto>>> GetParticularRoom(int id)
        {
            if(id != 0)
            {
                return Ok(await _service.GetParticularRoom(id));
            }
            else
            {
                return NotFound(new ApiResponse<bool>("Room not found", false));
            }
        }

        [HttpPost]
        [Route("/AddRooms")]
        public async Task<ActionResult<RoomDto>> AddRooms([FromForm] CreateRoomDto dto)
        {
            var result = await _service.AddRooms(dto);

            var response = new ApiResponse<RoomDto>("Room Created Successfully",result);
            return CreatedAtAction(nameof(GetRooms), new { id = result.Id }, response);
        }
        [HttpPost]
        [Route("/UpdateRoom")]
        public async Task<ActionResult<RoomDto>> UpdateRoom([FromForm] CreateRoomDto dto)
        {
            var result = await _service.UpdateRoom(dto);

            var response = new ApiResponse<RoomDto>("Room Updated Successfully", result);
            return CreatedAtAction(nameof(GetRooms), new { id = result.Id }, response);
        }
        [HttpDelete]
        [Route("/DeleteRoom/{id}")]
        public async Task<ActionResult<ApiResponse<bool>>> DeleteRoom(int id)
        {
            var result = await _service.DeleteRoom(id);
            if (!result)
            {
                return NotFound(new ApiResponse<bool>("Room not found", false));
            }
            var response = new ApiResponse<bool>("Room Deleted Successfully", true);
            return Ok(response);
        }

    }
}
