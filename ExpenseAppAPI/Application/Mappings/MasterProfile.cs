using AutoMapper;
using ExpenseAppAPI.Application.DTOs;
using ExpenseAppAPI.Domain.Entities;

namespace ExpenseAppAPI.Application.Mappings
{
    public class MasterProfile:Profile
    {
        public MasterProfile()
        {
            CreateMap<WorkType_Mst, WorkTypeMstDto>().ReverseMap();
            CreateMap<UserType, UserTypeDto>().ReverseMap();
            CreateMap<Room_Mst, GetRoomDto>().ReverseMap();

            //Mapping for EmailOtpVerification and OtpVerifyModelDto
            CreateMap<EmailOtpVerification, OtpVerifyModelDto>().ReverseMap();
        }
    }
}
