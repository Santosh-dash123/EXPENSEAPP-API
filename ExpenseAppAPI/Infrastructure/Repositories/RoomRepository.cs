using ExpenseAppAPI.Domain.Entities;
using ExpenseAppAPI.Infrastructure.Data;
using ExpenseAppAPI.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ExpenseAppAPI.Infrastructure.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly AppDbContext _context;

        public RoomRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Room_Mst>> GetAllRooms(int ROId) => await _context.Room_Mst.Where(x => x.IsActive == true && x.RoomOwnerId == ROId).ToListAsync();

        public async Task<Room_Mst> GetParticularRoom(int id) => await _context.Room_Mst.FindAsync(id);

        public async Task<Room_Mst> AddRooms(Room_Mst room)
        {
            _context.Room_Mst.Add(room);
            await _context.SaveChangesAsync();
            return room;
        }
        public async Task<Room_Mst> UpdateRoom(Room_Mst room)
        {
            var existingRoom = await _context.Room_Mst.FindAsync(room.Id);
            if (existingRoom == null)
            {
                return null; 
            }

            existingRoom.Name = room.Name;
            existingRoom.Image = room.Image;
            existingRoom.Address = room.Address;
            existingRoom.RentDate = room.RentDate;
            existingRoom.Ammount = room.Ammount;

            await _context.SaveChangesAsync();
            return existingRoom;
        }
        public async Task<bool> DeleteRoom(int id)
        {
            var existingRoom = await _context.Room_Mst.FindAsync(id);
            if (existingRoom == null)
            {
                return false;
            }
            existingRoom.IsActive = false;
            return await _context.SaveChangesAsync() > 0;
        }
       
    }
}
