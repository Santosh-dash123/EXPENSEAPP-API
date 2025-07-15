using AutoMapper;
using ExpenseAppAPI.Application.DTOs;
using ExpenseAppAPI.Application.Response;
using ExpenseAppAPI.Domain.Entities;
using ExpenseAppAPI.Infrastructure.Interfaces;

namespace ExpenseAppAPI.Application.Services
{
    public class HelperService
    {
        private readonly IHelperRepository _repository;
        private readonly IMapper _mapper;

        public HelperService(IHelperRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ApiResponse<OtpVerifyModelDto>> AddEmailOtpVerification(OtpVerifyModelDto emailOtpVerificationDto)
        {
            var emailOtpVerification = _mapper.Map<EmailOtpVerification>(emailOtpVerificationDto);
            var response = await _repository.AddEmailOtpVerification(emailOtpVerification);
            var mappedResponse = _mapper.Map<OtpVerifyModelDto>(response.Data);
            return new ApiResponse<OtpVerifyModelDto>(response.StatusMessage, mappedResponse);
        }
        public async Task<ApiResponse<OtpVerifyModelDto>> EmailOtpVerification(OtpVerifyModelDto emailOtpVerificationDto)
        {
            var emailOtpVerification = _mapper.Map<EmailOtpVerification>(emailOtpVerificationDto);
            var response = await _repository.EmailOtpVerification(emailOtpVerification);
            var mappedResponse = _mapper.Map<OtpVerifyModelDto>(response.Data);
            return new ApiResponse<OtpVerifyModelDto>(response.StatusMessage, mappedResponse);
        }
    }
}
