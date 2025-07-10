using ExpenseAppAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExpenseAppAPI.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Room_Mst> Room_Mst { get; set; }
        public DbSet<ManageUser> ManageUser { get; set; }
    }
}