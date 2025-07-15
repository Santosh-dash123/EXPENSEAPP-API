namespace ExpenseAppAPI.Domain.Entities
{
    public class Member_Mst
    {
        public int Id { get; set; }
        public int? RoomOwnerId { get; set; }
        public int? RoomId { get; set; }
        public string? Name { get; set; }
        public string? Gender { get; set; }
        public string? AdharCard { get; set; }
        public string? FatherName { get; set; }
        public string? Image { get; set; }
        public DateTime? JoiningDate { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public int? WorkType { get; set; }
        public string? JobName { get; set; }
        public string? CompanyName { get; set; }
        public string? CollegeName { get; set; }
        public string? CourseName { get; set; }
        public bool? Status { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
