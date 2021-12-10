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
        
        public async Task<ResultResponse<TModel>> AddAsync<TModel>(AddProfessionRequest request)
        {
            var duplicate = await _professionRepository.GetAsync(profession => profession.Name == request.Name);
            if (duplicate != null) throw new Exception("Profession with this name is already exist");
            
            var profession = _mapper.Map<AddProfessionRequest, Profession>(request);
            await _professionRepository.AddAsync(profession);
            await _unitOfWork.SaveChangesAsync();
            
            var professionDto = _mapper.Map<Profession, TModel>(profession);
            return new ResultResponse<TModel>(professionDto);
        }

        public async Task<ListResponse<TModel>> GetAsync<TModel>(ListProfessionsRequest request)
        {
            var filter = _mapper.Map<ListProfessionsRequest, ProfessionsFilter>(request);
            var sort = _mapper.Map<ListProfessionsRequest, Sort>(request);
            var paging = _mapper.Map<ListProfessionsRequest, Paging>(request);
            
            var professions = await _professionRepository.GetAsync(filter, sort, paging);
            var professionsCount = await _professionRepository.CountAsync(filter);

            var professionsDtosList = _mapper.Map<List<Profession>, List<TModel>>(professions);
            return new ListResponse<TModel>(professionsDtosList, professionsCount);
        }

        public async Task DeleteAsync(int id)
        {
            var profession = await _professionRepository.GetByIdAsync(id);
            if (profession == null) throw new Exception("Profession is not found");

            _professionRepository.Delete(profession);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}