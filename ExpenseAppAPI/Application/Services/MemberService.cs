using AutoMapper;
using ExpenseAppAPI.Application.DTOs;
using ExpenseAppAPI.Application.Response;
using ExpenseAppAPI.Domain.Entities;
using ExpenseAppAPI.Helpers;
using ExpenseAppAPI.Infrastructure.Interfaces;
namespace ExpenseAppAPI.Application.Services
{
    public class MemberService
    {
        private readonly IMemberRepository _repository;
        private readonly IMapper _mapper;
        public MemberService(IMemberRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ApiResponse<MemberDto>> AddMembers(List<MemberDto> members)
        {
            var data = _mapper.Map<List<Member_Mst>>(members);
            for (int i = 0; i < members.Count; i++)
            {
                var memberDto = members[i];
                var entity = data[i];

                entity.Image = null;
                entity.AdharCard = null;
                if (memberDto.Image != null)
                {
                    entity.Image = await FileUploadHelper.SaveImageAsync(memberDto.Image!, "assets/documents");
                }
                if(memberDto.AdharCard != null)
                {
                    entity.AdharCard = await FileUploadHelper.SaveImageAsync(memberDto.AdharCard!, "assets/documents");
                }
                
            }
            var response = await _repository.AddMembers(data);
            var mappedDto = _mapper.Map<MemberDto>(response.Data);
            return new ApiResponse<MemberDto>(response.StatusMessage, mappedDto);
        }
    }
}
