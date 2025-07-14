using ExpenseAppAPI.Application.Response;
using ExpenseAppAPI.Domain.Entities;

namespace ExpenseAppAPI.Infrastructure.Interfaces
{
    public interface IManageUserRepository
    {
        Task<ApiResponse<ManageUser>> AddUser(ManageUser user);
        Task<ManageUser> CheckLogin(ManageUser user);
        Task<List<ManageUser>> GetRoomOwner();
    }
}
