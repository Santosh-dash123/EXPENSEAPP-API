using ExpenseAppAPI.Application.Response;
using ExpenseAppAPI.Domain.Entities;
using ExpenseAppAPI.Helpers;
using ExpenseAppAPI.Infrastructure.Data;
using ExpenseAppAPI.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Net.Mail;
namespace ExpenseAppAPI.Infrastructure.Repositories
{
    public class HelperRepository : IHelperRepository
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _config;
        public HelperRepository(AppDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        public async Task<ApiResponse<EmailOtpVerification>> AddEmailOtpVerification(EmailOtpVerification emailOtpVerification)
        {
            //Code For Unique Email OTP Verification
            var otp = new Random().Next(1000, 9999).ToString();

            // Mark all previous OTPs as inactive in same email id
            var previousOtps = _context.EmailOtpVerification.Where(x => x.Email == emailOtpVerification.Email && x.IsActive == true);
            foreach (var item in previousOtps)
                item.IsActive = false;

            _context.EmailOtpVerification.Add(new EmailOtpVerification
            {
                Email = emailOtpVerification.Email,
                Otp = otp
            });

            await _context.SaveChangesAsync();

            // Send OTP using SMTP
            var smtpClient = new SmtpClient(_config["SMTP:Host"])
            {
                Port = int.Parse(_config["SMTP:Port"]!),
                Credentials = new NetworkCredential(_config["SMTP:Username"], _config["SMTP:Password"]),
                EnableSsl = true,
            };

            var mail = new MailMessage
            {
                From = new MailAddress(_config["SMTP:From"]!),
                Subject = "Your OTP for Email Verification",
                Body = $"Your OTP is {otp}.<br/>It will expire in 5 minutes.<br/><br/>Thanks & Regards,<br/>Expense Tracker Team",
                IsBodyHtml = true,
            };
            mail.To.Add(emailOtpVerification.Email!);
            await smtpClient.SendMailAsync(mail);

            return new ApiResponse<EmailOtpVerification>("OTP Sent Successfully to " + emailOtpVerification.Email + "!", emailOtpVerification);
        }
        public async Task<ApiResponse<EmailOtpVerification>> EmailOtpVerification(EmailOtpVerification emailOtpVerification)
        {
            var record = await _context.EmailOtpVerification
             .Where(x => x.Email == emailOtpVerification.Email && x.IsActive)
             .OrderByDescending(x => x.CreatedOn)
             .FirstOrDefaultAsync();

            if (record == null)
                return new ApiResponse<EmailOtpVerification>("No active OTP found!", emailOtpVerification);

            if (record.CreatedOn.AddMinutes(5) < DateTime.Now)
            {
                record.IsActive = false;
                await _context.SaveChangesAsync();
                return new ApiResponse<EmailOtpVerification>("OTP has expired!", emailOtpVerification);
            }

            if (record.Otp != emailOtpVerification.Otp)
                return new ApiResponse<EmailOtpVerification>("Invalid OTP!", emailOtpVerification);

            record.IsVerified = true;
            record.IsActive = false;
            await _context.SaveChangesAsync();

            return new ApiResponse<EmailOtpVerification>("Email Verified Successfully!", emailOtpVerification);
        }
    }
}
