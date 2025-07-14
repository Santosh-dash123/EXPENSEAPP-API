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
        }
    }
}
