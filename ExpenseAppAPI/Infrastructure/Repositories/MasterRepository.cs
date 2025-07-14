using ExpenseAppAPI.Application.Response;
using ExpenseAppAPI.Domain.Entities;
using ExpenseAppAPI.Helpers;
using ExpenseAppAPI.Infrastructure.Data;
using ExpenseAppAPI.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ExpenseAppAPI.Infrastructure.Repositories
{
    public class MasterRepository:IMasterRepository
    {
        private readonly AppDbContext _context;
        public MasterRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<WorkType_Mst>> GetWorkTypeMaster()
        {
            return await _context.WorkType_Mst
                .Where(x => x.IsActive == true).OrderByDescending(x => x.CreatedDate)
                .ToListAsync();
        }
        public async Task<ApiResponse<List<UserType>>> GetUserType()
        {
            var userTypes = await _context.UserType
                .Where(x => x.IsActive == true)
                .ToListAsync();

            return new ApiResponse<List<UserType>>("User types fetched successfully", userTypes);
        }
    }
}
