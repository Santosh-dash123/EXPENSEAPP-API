using ExpenseAppAPI.Domain.Entities;

namespace ExpenseAppAPI.Infrastructure.Interfaces
{
    public interface IManageUserRepository
    {
        Task<ManageUser> AddUser(ManageUser user);
        Task<ManageUser> CheckLogin(ManageUser user);
    }
}
