namespace ExpenseAppAPI.Domain.Entities
{
    public class EmailOtpVerification
    {
        public int Id { get; set; }
        public string? Email { get; set; }
        public string? Otp { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public bool IsVerified { get; set; } = false;
        public bool IsActive { get; set; } = true;
    }
}
