using AutoMapper;
using ExpenseAppAPI.Application.DTOs;
using ExpenseAppAPI.Domain.Entities;

namespace ExpenseAppAPI.Application.Mappings
{
    public class MemberProfile:Profile
    {
        public MemberProfile()
        {
            CreateMap<Member_Mst, MemberDto>().ReverseMap();
        }
    }
}
