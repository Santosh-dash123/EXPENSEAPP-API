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
        public async Task<ManageUser> AddUser(ManageUser user)
        {
            _context.ManageUser.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }
        public async Task<ManageUser?> CheckLogin(ManageUser user)
        {
            if (user != null)
            {
                var userInDb = await _context.ManageUser
                            .FirstOrDefaultAsync(x => x.Email == user.Email || x.PhoneNumber == user.PhoneNumber);

                if (userInDb != null && PasswordHelper.VerifyPassword(userInDb.Password!, user.Password!))
                {
                    return userInDb;
                }
            }

            return null;
        }

    }
}
