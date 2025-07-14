using AutoMapper;
using ExpenseAppAPI.Application.DTOs;
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
    }
}
