using ExpenseAppAPI.Application.Response;
using ExpenseAppAPI.Domain.Entities;
using ExpenseAppAPI.Helpers;
using ExpenseAppAPI.Infrastructure.Data;
using ExpenseAppAPI.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ExpenseAppAPI.Infrastructure.Repositories
{
    public class ManageUserRepository:IManageUserRepository
    {
        private readonly AppDbContext _context;

        public ManageUserRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ApiResponse<ManageUser>> AddUser(ManageUser user)
        {
            _context.ManageUser.Add(user);
            await _context.SaveChangesAsync();
            return new ApiResponse<ManageUser>("User Registered Successfully!", user);
        }
        public async Task<ManageUser?> CheckLogin(ManageUser user)
        {
            if (user != null)
            {
                var userIsPresent = await _context.ManageUser
                    .Where(x => (x.Email == user.Email || x.PhoneNumber == user.PhoneNumber) && x.Password == user.Password)
                    .FirstOrDefaultAsync();

                return userIsPresent != null ? userIsPresent : null;
            }

            return null;
        }

        //On Registration, we need to get the room owner
        public async Task<List<ManageUser>> GetRoomOwner()
        {
            return await _context.ManageUser
                .Where(x => x.UserType == 1 && x.IsActive == true).OrderByDescending(x => x.CreatedDate)
                .ToListAsync();
        }

    }
}
