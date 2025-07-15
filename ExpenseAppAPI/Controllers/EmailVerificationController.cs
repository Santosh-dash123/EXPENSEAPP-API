using ExpenseAppAPI.Application.DTOs;
using ExpenseAppAPI.Application.Response;
using ExpenseAppAPI.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailVerificationController : ControllerBase
    {
        private readonly HelperService _helperService;
        public EmailVerificationController(HelperService helperService)
        {
            _helperService = helperService;
        }
        [HttpPost("/SendOtp")]
        public async Task<ApiResponse<OtpVerifyModelDto>> SendOtp([FromBody] OtpVerifyModelDto data)
        {
            if(data == null)
            {
                return new ApiResponse<OtpVerifyModelDto>("Email cannot be empty", null!);
            }
            else
            {
                var response = await _helperService.AddEmailOtpVerification(data!);
                return response;
            }
        }
        [HttpPost("/VerifyOtp")]
        public async Task<ApiResponse<OtpVerifyModelDto>> VerifyOtp([FromBody] OtpVerifyModelDto data)
        {
            if (data == null)
            {
                return new ApiResponse<OtpVerifyModelDto>("OTP cannot be empty", null!);
            }
            else
            {
                var response = await _helperService.EmailOtpVerification(data!);
                return response;
            }
        }
    }
}
