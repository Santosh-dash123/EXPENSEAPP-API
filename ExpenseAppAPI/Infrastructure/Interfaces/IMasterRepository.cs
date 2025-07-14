using ExpenseAppAPI.Application.Response;
using ExpenseAppAPI.Domain.Entities;
namespace ExpenseAppAPI.Infrastructure.Interfaces
{
    public interface IMasterRepository
    {
        Task<List<WorkType_Mst>> GetWorkTypeMaster();
    }
}
