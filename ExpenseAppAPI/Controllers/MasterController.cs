using ExpenseAppAPI.Application.DTOs;
using ExpenseAppAPI.Application.Response;
using ExpenseAppAPI.Application.Services;
using ExpenseAppAPI.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MasterController : ControllerBase
    {
        private readonly MasterService _service;

        public MasterController(MasterService service)
        {
            _service = service;
        }
        [HttpGet]
        [Route("/GetWorkType")]
        public async Task<ActionResult<ApiResponse<List<WorkTypeMstDto>>>> GetWorkType()
        {
            var result = await _service.GetWorkTypeMaster();
            return Ok(result);
        }
    }
}
