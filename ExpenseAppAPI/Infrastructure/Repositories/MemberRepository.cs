using ExpenseAppAPI.Application.Response;
using ExpenseAppAPI.Domain.Entities;
using ExpenseAppAPI.Infrastructure.Data;
using ExpenseAppAPI.Infrastructure.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace ExpenseAppAPI.Infrastructure.Repositories
{
    public class MemberRepository:IMemberRepository
    {
        private readonly AppDbContext _context;
        public MemberRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ApiResponse<Member_Mst>> AddMembers(List<Member_Mst> members)
        {
            var response = new ApiResponse<Member_Mst>();
            try
            {
                string jsonData = JsonConvert.SerializeObject(members);
                var param = new SqlParameter("@JsonData", jsonData);
                await _context.Database.ExecuteSqlRawAsync("EXEC SP_AddMultipleMembers @JsonData", param);

                response.StatusMessage = "Members inserted successfully.";
                response.Data = members.FirstOrDefault()!;
            }
            catch (Exception ex)
            {
                response.StatusMessage = "Error occurred while inserting members.";
                response.Data = null!;
            }

            return response;
        }
    }
}
