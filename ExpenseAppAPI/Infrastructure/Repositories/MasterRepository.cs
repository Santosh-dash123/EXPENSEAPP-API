using ExpenseAppAPI.Application.Response;
using ExpenseAppAPI.Domain.Entities;
using ExpenseAppAPI.Helpers;
using ExpenseAppAPI.Infrastructure.Data;
using ExpenseAppAPI.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Net.Mail;

namespace ExpenseAppAPI.Infrastructure.Repositories
{
    public class MasterRepository : IMasterRepository
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _config;
        public MasterRepository(AppDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
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

        public async Task<ApiResponse<List<Room_Mst>>> GetAllRoom(int RoomOwnerId)
        {
            var rooms = await _context.Room_Mst
                .Where(x => x.IsActive == true && x.RoomOwnerId == RoomOwnerId)
                .ToListAsync();
            return new ApiResponse<List<Room_Mst>>("Rooms fetched successfully", rooms);

        }
    }
}
