using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ItSkillHouse.Contracts;
using ItSkillHouse.Contracts.Technology;
using ItSkillHouse.Models;
using ItSkillHouse.Models.Repositories;
using ItSkillHouse.Models.Services;

namespace ItSkillHouse.Services
{
    public class TechnologyService : ITechnologyService
    {
        private readonly ITechnologyRepository _technologyRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TechnologyService(ITechnologyRepository technologyRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _technologyRepository = technologyRepository;
        }
        
        public async Task<ResultResponse<TModel>> AddAsync<TModel>(SaveTechnologyRequest request)
        {
            var duplicate = await _technologyRepository.GetAsync(technology => technology.Name == request.Name);
            if (duplicate != null) throw new Exception("Technology with this name is already exist");
            
            var technology = _mapper.Map<SaveTechnologyRequest, Technology>(request);
            await _technologyRepository.AddAsync(technology);
            await _unitOfWork.SaveChangesAsync();
            
            var technologyDto = _mapper.Map<Technology, TModel>(technology);
            return new ResultResponse<TModel>(technologyDto);
        }

        public async Task<ListResponse<TModel>> GetAsync<TModel>()
        {
            var technologies = await _technologyRepository.GetAsync();
            var technologiesCount = await _technologyRepository.CountAsync();

            var technologiesDtosList = _mapper.Map<List<Technology>, List<TModel>>(technologies);
            return new ListResponse<TModel>(technologiesDtosList, technologiesCount);
        }
    }
}