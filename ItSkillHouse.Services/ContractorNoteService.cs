using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ItSkillHouse.Contracts;
using ItSkillHouse.Contracts.ContractorNote;
using ItSkillHouse.Models;
using ItSkillHouse.Models.Repositories;
using ItSkillHouse.Models.Services;

namespace ItSkillHouse.Services
{
    public class ContractorNoteService : IContractorNoteService
    {
        private readonly IContractorNoteRepository _contractorNoteRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ContractorNoteService(IContractorNoteRepository contractorNoteRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _contractorNoteRepository = contractorNoteRepository;
        }
        
        public async Task<ResultResponse<TModel>> AddAsync<TModel>(AddContractorNoteRequest request)
        {
            var contractorNote = _mapper.Map<AddContractorNoteRequest, ContractorNote>(request);
            await _contractorNoteRepository.AddAsync(contractorNote);
            await _unitOfWork.SaveChangesAsync();
            
            var contractorNoteDto = _mapper.Map<ContractorNote, TModel>(contractorNote);
            return new ResultResponse<TModel>(contractorNoteDto);
        }

        public async Task<ResultResponse<TModel>> EditAsync<TModel>(Guid id, EditContractorNoteRequest request)
        {
            var contractorNote = await _contractorNoteRepository.GetByIdAsync(id);
            if (contractorNote == null) throw new Exception("Contractor note is not found");
            
            contractorNote = _mapper.Map(request, contractorNote);
            _contractorNoteRepository.Update(contractorNote);
            await _unitOfWork.SaveChangesAsync();
            
            var contractorNoteDto = _mapper.Map<ContractorNote, TModel>(contractorNote);
            return new ResultResponse<TModel>(contractorNoteDto);
        }

        public async Task<ListResponse<TModel>> GetAsync<TModel>()
        {
            var contractorNotes = await _contractorNoteRepository.GetAsync();
            var contractorNotesCount = await _contractorNoteRepository.CountAsync();

            var contractorNotesDtosList = _mapper.Map<List<ContractorNote>, List<TModel>>(contractorNotes);
            return new ListResponse<TModel>(contractorNotesDtosList, contractorNotesCount);
        }

        public async Task<ResultResponse<TModel>> GetAsync<TModel>(Guid id)
        {
            var contractorNote = await _contractorNoteRepository.GetByIdAsync(id);
            if (contractorNote == null) throw new Exception("Contractor note is not found");

            var contractorNoteDto = _mapper.Map<ContractorNote, TModel>(contractorNote);
            return new ResultResponse<TModel>(contractorNoteDto);
        }

        public async Task DeleteAsync(Guid id)
        {
            var contractorNote = await _contractorNoteRepository.GetByIdAsync(id);
            if (contractorNote == null) throw new Exception("Contractor note is not found");

            _contractorNoteRepository.Delete(contractorNote);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}