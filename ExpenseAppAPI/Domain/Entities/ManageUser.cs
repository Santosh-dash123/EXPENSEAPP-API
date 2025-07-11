﻿namespace ExpenseAppAPI.Domain.Entities
{
    public class ManageUser
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Password { get; set; }
        public int UserType { get; set; }
        public int RoomOwnerId { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
