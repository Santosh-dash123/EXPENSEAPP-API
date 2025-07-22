using ExpenseAppAPI.Application.DTOs;
using ExpenseAppAPI.Application.Response;
using ExpenseAppAPI.Domain.Entities;
using ExpenseAppAPI.Infrastructure.Data;
using ExpenseAppAPI.Infrastructure.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace ExpenseAppAPI.Infrastructure.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        private readonly AppDbContext _context;
        public MemberRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ApiResponse<bool>> AddMembers(List<Member_Mst> members)
        {
            var response = new ApiResponse<bool>("", false);
            try
            {
                string jsonData = JsonConvert.SerializeObject(members);
                var param = new SqlParameter("@JsonData", jsonData);
                await _context.Database.ExecuteSqlRawAsync("EXEC SP_AddMultipleMembers @JsonData", param);

                response.StatusMessage = "Members inserted successfully.";
                response.Data = true;
            }
            catch (Exception ex)
            {
                response.StatusMessage = "Error occurred while inserting members.";
                response.Data = false;
            }

            return response;
        }
        public async Task<ApiResponse<List<GetMembersByRoomOwnerDto>>> GetAllMembers(int roomOwnerId,string whichTypeDataGet)
        {
            var response = new ApiResponse<List<GetMembersByRoomOwnerDto>>("", null!);

            try
            {
                var param = new SqlParameter("@RoomOwnerId", roomOwnerId);
                var param2 = new SqlParameter("@WhichTypeDataGet", whichTypeDataGet);

                var result = await _context
                   .GetMembersByRoomOwnerDto 
                   .FromSqlRaw("EXEC SP_GetMembersByRoomOwner @RoomOwnerId,@WhichTypeDataGet", param,param2)
                   .ToListAsync();

                response.StatusMessage = "Members retrieved successfully.";
                response.Data = result;
            }
            catch (Exception ex)
            {
                response.StatusMessage = "Error occurred while fetching members.";
                response.Data = null!;
            }

            return response;
        }

        public async Task<ApiResponse<bool>> UpdateMembers(Member_Mst member)
        {
            var response = new ApiResponse<bool>("", false);
            try
            {
                _context.Member_Mst.Update(member);
                await _context.SaveChangesAsync();
                response.StatusMessage = "Member updated successfully.";
                response.Data = true;
            }
            catch (Exception ex)
            {
                response.StatusMessage = "Error occurred while updating member.";
                response.Data = false;
            }
            return response;
        }
        public async Task<ApiResponse<bool>> DeleteMembers(int Id)
        {
            var response = new ApiResponse<bool>("", false);
            try
            {
                var existingMember = await _context.Member_Mst.FindAsync(Id);
                if (existingMember == null)
                {
                    response.StatusMessage = "Member not found.";
                    return response;
                }
                else
                {
                    existingMember.IsActive = false;
                }
                await _context.SaveChangesAsync();
                response.StatusMessage = "Member deleted successfully.";
                response.Data = true;
            }
            catch (Exception ex)
            {
                response.StatusMessage = "Error occurred while deleting member.";
                response.Data = false!;
            }
            return response;

        }
    }
}
