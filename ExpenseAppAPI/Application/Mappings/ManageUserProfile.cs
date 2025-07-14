using AutoMapper;
using ExpenseAppAPI.Application.DTOs;
using ExpenseAppAPI.Domain.Entities;

namespace ExpenseAppAPI.Application.Mappings
{
    public class ManageUserProfile:Profile
    {
        public ManageUserProfile()
        {
            CreateMap<ManageUser, ManageUserDto>().ReverseMap();
            CreateMap<ManageUser, GetRoomOwnerDto>().ReverseMap();
        }
    }
}
