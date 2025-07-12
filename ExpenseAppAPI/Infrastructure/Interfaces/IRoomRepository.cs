using ExpenseAppAPI.Domain.Entities;

namespace ExpenseAppAPI.Infrastructure.Interfaces
{
    public interface IRoomRepository
    {
        Task<List<Room_Mst>> GetAllRooms(int ROId);
        Task<Room_Mst> GetParticularRoom(int id);
        Task<Room_Mst> AddRooms(Room_Mst room);
        Task<Room_Mst> UpdateRoom(Room_Mst room);
        Task<bool> DeleteRoom(int id);
    }
}
