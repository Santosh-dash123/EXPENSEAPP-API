using AutoMapper;
using ExpenseAppAPI.Application.DTOs;
using ExpenseAppAPI.Domain.Entities;
using ExpenseAppAPI.Helpers;
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

        public async Task<List<RoomDto>> GetAllRooms(int ROId)
        {
            var rooms = await _repository.GetAllRooms(ROId);
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
            if (dto.Image != null)
            {
                string savedPath = await FileUploadHelper.SaveImageAsync(dto.Image, "assets/images");
                room.Image = savedPath;
            }
            var added = await _repository.AddRooms(room);
            return _mapper.Map<RoomDto>(added);
        }

        public async Task<RoomDto> UpdateRoom(CreateRoomDto dto)
        {
            var existingRoom = await _repository.GetParticularRoom(dto.Id);
            if (existingRoom == null)
            {
                throw new Exception("Room not found.");
            }
            var room = _mapper.Map<Room_Mst>(dto);
            if (dto.Image != null)
            {
                string savedPath = await FileUploadHelper.SaveImageAsync(dto.Image, "assets/images");
                room.Image = savedPath;
            }
            else
            {
                room.Image = existingRoom.Image;
            }

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
