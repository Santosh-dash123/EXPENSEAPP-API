using AutoMapper;
using ExpenseAppAPI.Application.DTOs;
using ExpenseAppAPI.Application.Response;
using ExpenseAppAPI.Domain.Entities;
using ExpenseAppAPI.Infrastructure.Interfaces;

namespace ExpenseAppAPI.Application.Services
{
    public class ManageUserService
    {
        private readonly IManageUserRepository _repository;
        private readonly IMapper _mapper;

        public ManageUserService(IManageUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ManageUserDto> CheckLogin(ManageUserDto user)
        {
            var manageuser = _mapper.Map<ManageUser>(user);
            var data = await _repository.CheckLogin(manageuser);
            return _mapper.Map<ManageUserDto>(data);
        }
        public async Task<ApiResponse<ManageUser>> AddUserAsync(ManageUser dto)
        {

            if (dto.UserType == 2 && (dto.RoomOwnerId == null || dto.RoomOwnerId == 0))
            {
                var response = new ApiResponse<ManageUser>("RoomOwnerId is required when UserType is Member!", null);
                return response;
            }

            var user = new ManageUser
            {
                Name = dto.Name,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                Password = dto.Password,
                UserType = dto.UserType,
                RoomOwnerId = dto.RoomOwnerId,
                IsActive = true,
                CreatedDate = DateTime.Now
            };

            var result = await _repository.AddUser(user);
            return result;
        }
        public async Task<ApiResponse<List<GetRoomOwnerDto>>> GetRoomOwner()
        {
            var result = _mapper.Map<List<GetRoomOwnerDto>>(await _repository.GetRoomOwner());

            if (result == null || result.Count == 0)
            {
                return new ApiResponse<List<GetRoomOwnerDto>>("No room owners found", null);
            }

            return new ApiResponse<List<GetRoomOwnerDto>>("Room owners fetched successfully", result);
        }
    }
}
