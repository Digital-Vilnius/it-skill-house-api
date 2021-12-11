using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ItSkillHouse.Contracts;
using ItSkillHouse.Contracts.Contractor;
using ItSkillHouse.Models;
using ItSkillHouse.Models.Repositories;
using ItSkillHouse.Models.Services;

namespace ItSkillHouse.Services
{
    public class ContractorService : IContractorService
    {
        private readonly IContractorRepository _contractorRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ContractorService(IContractorRepository contractorRepository, IMapper mapper, IUnitOfWork unitOfWork, IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _contractorRepository = contractorRepository;
        }
        
        public async Task<ResultResponse<TModel>> AddAsync<TModel>(AddContractorRequest request)
        {
            var duplicate = await _userRepository.GetAsync(user => user.Email == request.Email);
            if (duplicate != null) throw new Exception("User with this email is already exist");

            var contractor = _mapper.Map<AddContractorRequest, Contractor>(request);
            contractor.Technologies.Add(new ContractorTechnology{TechnologyId = request.MainTechnologyId, IsMain = true});
            await _contractorRepository.AddAsync(contractor);
            await _unitOfWork.SaveChangesAsync();
            
            var contractorDto = _mapper.Map<Contractor, TModel>(contractor);
            return new ResultResponse<TModel>(contractorDto);
        }

        public async Task<ResultResponse<TModel>> EditAsync<TModel>(int id, EditContractorRequest request)
        {
            var contractor = await _contractorRepository.GetByIdAsync(id);
            if (contractor == null) throw new Exception("Contractor is not found");

            contractor = _mapper.Map(request, contractor);
            contractor.Technologies.Add(new ContractorTechnology{TechnologyId = request.MainTechnologyId, IsMain = true});
            _contractorRepository.Update(contractor);
            await _unitOfWork.SaveChangesAsync();
            
            var contractorDto = _mapper.Map<Contractor, TModel>(contractor);
            return new ResultResponse<TModel>(contractorDto);
        }

        public async Task<ListResponse<TModel>> GetAsync<TModel>(ListContractorsRequest request)
        {
            var filter = _mapper.Map<ListContractorsRequest, ContractorsFilter>(request);
            var sort = _mapper.Map<ListContractorsRequest, Sort>(request);
            var paging = _mapper.Map<ListContractorsRequest, Paging>(request);

            var contractors = await _contractorRepository.GetAsync(filter, sort, paging);
            var contractorsCount = await _contractorRepository.CountAsync(filter);

            var contractorsDtosList = _mapper.Map<List<Contractor>, List<TModel>>(contractors);
            return new ListResponse<TModel>(contractorsDtosList, contractorsCount);
        }

        public async Task<ResultResponse<TModel>> GetAsync<TModel>(int id)
        {
            var contractor = await _contractorRepository.GetByIdAsync(id);
            if (contractor == null) throw new Exception("Contractor is not found");

            var contractorDto = _mapper.Map<Contractor, TModel>(contractor);
            return new ResultResponse<TModel>(contractorDto);
        }

        public async Task DeleteAsync(int id)
        {
            var contractor = await _contractorRepository.GetByIdAsync(id);
            if (contractor == null) throw new Exception("Contractor is not found");

            _contractorRepository.Delete(contractor);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}