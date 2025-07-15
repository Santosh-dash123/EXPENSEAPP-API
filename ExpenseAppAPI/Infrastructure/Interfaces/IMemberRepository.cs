using ExpenseAppAPI.Application.DTOs;
using ExpenseAppAPI.Application.Response;
using ExpenseAppAPI.Domain.Entities;

namespace ExpenseAppAPI.Infrastructure.Interfaces
{
    public interface IMemberRepository
    {
        Task<ApiResponse<Member_Mst>> AddMembers(List<Member_Mst> members);
    }
}
