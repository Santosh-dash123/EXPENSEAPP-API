using ExpenseAppAPI.Application.DTOs;
using ExpenseAppAPI.Application.Response;
using ExpenseAppAPI.Domain.Entities;

namespace ExpenseAppAPI.Infrastructure.Interfaces
{
    public interface IMemberRepository
    {
        Task<ApiResponse<bool>> AddMembers(List<Member_Mst> members);
        //Task<ApiResponse<Member_Mst>> AddMembers(Member_Mst member)
        //{
        //    return AddMembers(new List<Member_Mst> { member });
        //}
        Task<ApiResponse<bool>> UpdateMembers(Member_Mst member);
        Task<ApiResponse<bool>> DeleteMembers(int Id);
        Task<ApiResponse<List<GetMembersByRoomOwnerDto>>> GetAllMembers(int roomOwnerId,string whichTypeDataGet);
    }
}
