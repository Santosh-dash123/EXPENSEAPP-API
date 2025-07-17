using ExpenseAppAPI.Application.Response;
using ExpenseAppAPI.Domain.Entities;
namespace ExpenseAppAPI.Infrastructure.Interfaces
{
    public interface IMasterRepository
    {
        Task<List<WorkType_Mst>> GetWorkTypeMaster();
        Task<ApiResponse<List<UserType>>> GetUserType();
        Task<ApiResponse<List<Room_Mst>>> GetAllRoom(int RoomOwnerId);
    }
}
