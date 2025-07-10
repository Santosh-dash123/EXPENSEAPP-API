namespace ExpenseAppAPI.Application.DTOs
{
    public class ManageUserDto
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Password { get; set; }
        public int UserType { get; set; }
    }
}
