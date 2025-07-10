using AutoMapper;
using ExpenseAppAPI.Application.DTOs;
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
    }
}
