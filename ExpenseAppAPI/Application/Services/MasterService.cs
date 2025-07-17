using AutoMapper;
using ExpenseAppAPI.Application.DTOs;
using ExpenseAppAPI.Application.Response;
using ExpenseAppAPI.Domain.Entities;
using ExpenseAppAPI.Infrastructure.Interfaces;

namespace ExpenseAppAPI.Application.Services
{
    public class MasterService
    {
        private readonly IMasterRepository _repository;
        private readonly IMapper _mapper;

        public MasterService(IMasterRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<WorkTypeMstDto>> GetWorkTypeMaster()
        {
            var workType = _mapper.Map<List<WorkTypeMstDto>>(await _repository.GetWorkTypeMaster());
            return workType;
        }
        public async Task<ApiResponse<List<UserTypeDto>>> GetUserType()
        {
            var response = await _repository.GetUserType();
            var userTypeDtos = _mapper.Map<List<UserTypeDto>>(response.Data);

            return new ApiResponse<List<UserTypeDto>>(response.StatusMessage, userTypeDtos);
        }
        public async Task<ApiResponse<List<GetRoomDto>>> GetAllRoom(int RoomOwnerId)
        {
            var response = await _repository.GetAllRoom(RoomOwnerId);
            var roomDtos = _mapper.Map<List<GetRoomDto>>(response.Data);
            return new ApiResponse<List<GetRoomDto>>(response.StatusMessage, roomDtos);
        }
    }
}
