namespace ExpenseAppAPI.Domain.Entities
{
    public class WorkType_Mst
    {
        public int Id { get; set; }
        public string? WorkType { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
