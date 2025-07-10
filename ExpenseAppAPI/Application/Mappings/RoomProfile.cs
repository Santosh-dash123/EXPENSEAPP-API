using AutoMapper;
using ExpenseAppAPI.Application.DTOs;
using ExpenseAppAPI.Domain.Entities;

namespace ExpenseAppAPI.Application.Mappings
{
    public class RoomProfile : Profile
    {
        public RoomProfile()
        {
            CreateMap<Room_Mst, RoomDto>().ReverseMap();
            CreateMap<CreateRoomDto, Room_Mst>().ReverseMap();
        }
    }
}
