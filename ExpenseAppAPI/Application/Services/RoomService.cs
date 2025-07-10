using ExpenseAppAPI.Application.DTOs;
using AutoMapper;
using ExpenseAppAPI.Domain.Entities;
using ExpenseAppAPI.Infrastructure.Interfaces;
namespace ExpenseAppAPI.Application.Services
{
    public class RoomService
    {
        private readonly IRoomRepository _repository;
        private readonly IMapper _mapper;

        public RoomService(IRoomRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<RoomDto>> GetAllRooms()
        {
            var rooms = await _repository.GetAllRooms();
            return _mapper.Map<List<RoomDto>>(rooms);
        }

        public async Task<RoomDto> GetParticularRoom(int id)
        {
            var room = await _repository.GetParticularRoom(id);
            return _mapper.Map<RoomDto>(room);
        }

        public async Task<RoomDto> AddRooms(CreateRoomDto dto)
        {
            var room = _mapper.Map<Room_Mst>(dto);
            var added = await _repository.AddRooms(room);
            return _mapper.Map<RoomDto>(added);
        }

        public async Task<RoomDto> UpdateRoom(RoomDto dto)
        {
            var room = _mapper.Map<Room_Mst>(dto);
            var updated = await _repository.UpdateRoom(room);
            return _mapper.Map<RoomDto>(updated);
        }

        public async Task<bool> DeleteRoom(int id)
        {
            bool deleted = await _repository.DeleteRoom(id);
            return deleted;
        }
    }
}
