using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ItSkillHouse.Contracts;
using ItSkillHouse.Models;
using ItSkillHouse.Models.Repositories;
using ItSkillHouse.Models.Services;

namespace ItSkillHouse.Services
{
    public class RecruiterService : IRecruiterService
    {
        private readonly IRecruiterRepository _recruiterRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RecruiterService(IRecruiterRepository recruiterRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _recruiterRepository = recruiterRepository;
        }

        public async Task<ListResponse<TModel>> GetAsync<TModel>()
        {
            var recruiters = await _recruiterRepository.GetAsync();
            var recruitersCount = await _recruiterRepository.CountAsync();

            var recruitersDtosList = _mapper.Map<List<Recruiter>, List<TModel>>(recruiters);
            return new ListResponse<TModel>(recruitersDtosList, recruitersCount);
        }
    }
}