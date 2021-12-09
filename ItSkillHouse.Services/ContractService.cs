using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ItSkillHouse.Contracts;
using ItSkillHouse.Contracts.Contract;
using ItSkillHouse.Models;
using ItSkillHouse.Models.Repositories;
using ItSkillHouse.Models.Services;

namespace ItSkillHouse.Services
{
    public class ContractService : IContractService
    {
        private readonly IContractRepository _contractRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ContractService(IContractRepository contractRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _contractRepository = contractRepository;
        }
        
        public async Task<ResultResponse<TModel>> AddAsync<TModel>(AddContractRequest request)
        {
            var contract = _mapper.Map<AddContractRequest, Contract>(request);
            await _contractRepository.AddAsync(contract);
            await _unitOfWork.SaveChangesAsync();
            
            var contractDto = _mapper.Map<Contract, TModel>(contract);
            return new ResultResponse<TModel>(contractDto);
        }

        public async Task<ResultResponse<TModel>> EditAsync<TModel>(int id, EditContractRequest request)
        {
            var contract = await _contractRepository.GetByIdAsync(id);
            if (contract == null) throw new Exception("Contract is not found");
            
            contract = _mapper.Map(request, contract);
            _contractRepository.Update(contract);
            await _unitOfWork.SaveChangesAsync();
            
            var contractDto = _mapper.Map<Contract, TModel>(contract);
            return new ResultResponse<TModel>(contractDto);
        }

        public async Task<ListResponse<TModel>> GetAsync<TModel>()
        {
            var contracts = await _contractRepository.GetAsync();
            var contractsCount = await _contractRepository.CountAsync();

            var contractsDtosList = _mapper.Map<List<Contract>, List<TModel>>(contracts);
            return new ListResponse<TModel>(contractsDtosList, contractsCount);
        }

        public async Task<ResultResponse<TModel>> GetAsync<TModel>(int id)
        {
            var contract = await _contractRepository.GetByIdAsync(id);
            if (contract == null) throw new Exception("Contract is not found");

            var contractDto = _mapper.Map<Contract, TModel>(contract);
            return new ResultResponse<TModel>(contractDto);
        }

        public async Task DeleteAsync(int id)
        {
            var contract = await _contractRepository.GetByIdAsync(id);
            if (contract == null) throw new Exception("Contract is not found");

            _contractRepository.Delete(contract);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}