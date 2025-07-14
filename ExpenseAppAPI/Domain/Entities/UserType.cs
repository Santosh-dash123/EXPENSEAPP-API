namespace ExpenseAppAPI.Domain.Entities
{
    public class UserType
    {
        public int Id { get; set; }
        public string? Role { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
