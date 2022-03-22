using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ItSkillHouse.Contracts;
using ItSkillHouse.Contracts.Profession;
using ItSkillHouse.Models;
using ItSkillHouse.Models.Repositories;
using ItSkillHouse.Models.Services;

namespace ItSkillHouse.Services
{
    public class ProfessionService : IProfessionService
    {
        private readonly IProfessionRepository _professionRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProfessionService(IProfessionRepository professionRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _professionRepository = professionRepository;
        }
        
        public async Task<ResultResponse<TModel>> AddAsync<TModel>(SaveProfessionRequest request)
        {
            var duplicate = await _professionRepository.GetAsync(profession => profession.Name == request.Name);
            if (duplicate != null) throw new Exception("Profession with this name is already exist");
            
            var profession = _mapper.Map<SaveProfessionRequest, Profession>(request);
            await _professionRepository.AddAsync(profession);
            await _unitOfWork.SaveChangesAsync();
            
            var professionDto = _mapper.Map<Profession, TModel>(profession);
            return new ResultResponse<TModel>(professionDto);
        }

        public async Task<ListResponse<TModel>> GetAsync<TModel>()
        {
            var professions = await _professionRepository.GetAsync();
            var professionsCount = await _professionRepository.CountAsync();

            var professionsDtosList = _mapper.Map<List<Profession>, List<TModel>>(professions);
            return new ListResponse<TModel>(professionsDtosList, professionsCount);
        }
    }
}