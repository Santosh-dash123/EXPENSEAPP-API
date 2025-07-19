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
        public async Task<ApiResponse<bool>> AddMembers(ListOfMember value)
        {
            var data = _mapper.Map<List<Member_Mst>>(value.MemberData!);
            var members = value.MemberData!;
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
            return new ApiResponse<bool>(response.StatusMessage, response.Data);
        }
        public async Task<ApiResponse<bool>> UpdateMembers(MemberDto members)
        {
            var data = _mapper.Map<Member_Mst>(members);
            if(members.Image != null)
            {
                data.Image = await FileUploadHelper.SaveImageAsync(members.Image!, "assets/documents"); 
            }
            if(members.AdharCard != null)
            {
                data.AdharCard = await FileUploadHelper.SaveImageAsync(members.AdharCard!, "assets/documents");
            }
            var response = await _repository.UpdateMembers(data);
            return new ApiResponse<bool>(response.StatusMessage, response.Data);
        }
        public async Task<ApiResponse<bool>> DeleteMembers(int Id)
        {
            var response = await _repository.DeleteMembers(Id);
            if(response == null)
            {
                return new ApiResponse<bool>("Member not found", false);
            }
            else
            {
                return new ApiResponse<bool>(response.StatusMessage, response.Data);
            }
        }

        public async Task<ApiResponse<List<GetMembersByRoomOwnerDto>>> GetAllMembers(int RoomOwnerId)
        {
            var response = await _repository.GetAllMembers(RoomOwnerId);
            if(response == null)
            {
                return null!;
            }
            else
            {
                return response;
            }
        }
    }
}
