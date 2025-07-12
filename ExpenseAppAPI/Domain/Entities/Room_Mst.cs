namespace ExpenseAppAPI.Domain.Entities
{
    public class Room_Mst
    {
        public int Id { get; set; }
        public int RoomOwnerId { get; set; }
        public string? Name { get; set; }
        public string? Image { get; set; }
        public string? Address { get; set; }
        public DateTime RentDate { get; set; }
        public decimal? Ammount { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
