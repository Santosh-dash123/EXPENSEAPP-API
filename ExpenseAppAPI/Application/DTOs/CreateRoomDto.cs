namespace ExpenseAppAPI.Application.DTOs
{
    public class CreateRoomDto
    {
        public string? Name { get; set; }
        public string? Image { get; set; }
        public string? Address { get; set; }
        public DateTime RentDate { get; set; }
        public decimal? Ammount { get; set; }
    }
}
