using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ItSkillHouse.Contracts;
using ItSkillHouse.Contracts.Rate;
using ItSkillHouse.Models;
using ItSkillHouse.Models.Repositories;
using ItSkillHouse.Models.Services;

namespace ItSkillHouse.Services
{
    public class RateService : IRateService
    {
        private readonly IRateRepository _rateRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RateService(IRateRepository rateRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _rateRepository = rateRepository;
        }
        
        public async Task<ResultResponse<TModel>> AddAsync<TModel>(AddRateRequest request)
        {
            var rate = _mapper.Map<AddRateRequest, Rate>(request);
            await _rateRepository.AddAsync(rate);
            await _unitOfWork.SaveChangesAsync();
            
            var rateNoteDto = _mapper.Map<Rate, TModel>(rate);
            return new ResultResponse<TModel>(rateNoteDto);
        }

        public async Task<ResultResponse<TModel>> EditAsync<TModel>(Guid id, EditRateRequest request)
        {
            var rate = await _rateRepository.GetByIdAsync(id);
            if (rate == null) throw new Exception("Rate is not found");
            
            rate = _mapper.Map(request, rate);
            _rateRepository.Update(rate);
            await _unitOfWork.SaveChangesAsync();
            
            var rateDto = _mapper.Map<Rate, TModel>(rate);
            return new ResultResponse<TModel>(rateDto);
        }

        public async Task<ListResponse<TModel>> GetAsync<TModel>()
        {
            var rates = await _rateRepository.GetAsync();
            var ratesCount = await _rateRepository.CountAsync();

            var ratesDtosList = _mapper.Map<List<Rate>, List<TModel>>(rates);
            return new ListResponse<TModel>(ratesDtosList, ratesCount);
        }

        public async Task<ResultResponse<TModel>> GetAsync<TModel>(Guid id)
        {
            var rate = await _rateRepository.GetByIdAsync(id);
            if (rate == null) throw new Exception("Rate is not found");

            var rateDto = _mapper.Map<Rate, TModel>(rate);
            return new ResultResponse<TModel>(rateDto);
        }

        public async Task DeleteAsync(Guid id)
        {
            var rate = await _rateRepository.GetByIdAsync(id);
            if (rate == null) throw new Exception("Rate is not found");

            _rateRepository.Delete(rate);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}