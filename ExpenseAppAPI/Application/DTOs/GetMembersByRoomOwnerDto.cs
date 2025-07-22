using System.ComponentModel.DataAnnotations;

namespace ExpenseAppAPI.Application.DTOs
{
    public class GetMembersByRoomOwnerDto
    {
        [Key]
        public int Id { get; set; }
        public int? RoomId { get; set; }
        public string? RoomName { get; set; }
        public string? Name { get; set; }
        public string? Gender { get; set; }
        public string? AdharCard { get; set; }
        public string? FatherName { get; set; }
        public string? ProfilePicture { get; set; } 
        public DateTime JoiningDate { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public int? WorkType { get; set; }
        public string? WorkTypeName { get; set; }
        public string? JobName { get; set; } 
        public string? CompanyName { get; set; } 
    }
}
