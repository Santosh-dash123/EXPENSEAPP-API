using ExpenseAppAPI.Application.Response;
using ExpenseAppAPI.Domain.Entities;

namespace ExpenseAppAPI.Infrastructure.Interfaces
{
    public interface IHelperRepository
    {
        Task<ApiResponse<EmailOtpVerification>> AddEmailOtpVerification(EmailOtpVerification emailOtpVerification);
        Task<ApiResponse<EmailOtpVerification>> EmailOtpVerification(EmailOtpVerification emailOtpVerification);
    }
}
