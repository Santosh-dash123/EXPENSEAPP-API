namespace ExpenseAppAPI.Application.DTOs
{
    public class CreateRoomDto
    {
        public int Id { get; set; }
        public int RoomOwnerId { get; set; }
        public string? Name { get; set; }
        public IFormFile? Image { get; set; }
        public string? Address { get; set; }
        public DateTime RentDate { get; set; }
        public decimal? Ammount { get; set; }
    }
}
