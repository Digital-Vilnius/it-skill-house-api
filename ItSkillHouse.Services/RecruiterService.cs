using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ItSkillHouse.Contracts;
using ItSkillHouse.Contracts.Recruiter;
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
        
        public async Task<ResultResponse<TModel>> AddAsync<TModel>(AddRecruiterRequest request)
        {
            var duplicate = await _recruiterRepository.GetAsync(recruiter => recruiter.User.Recruiter != null);
            if (duplicate != null) throw new Exception("Recruiter for this user is already created");
            
            var recruiter = _mapper.Map<AddRecruiterRequest, Recruiter>(request);
            await _recruiterRepository.AddAsync(recruiter);
            await _unitOfWork.SaveChangesAsync();
            
            var recruiterDto = _mapper.Map<Recruiter, TModel>(recruiter);
            return new ResultResponse<TModel>(recruiterDto);
        }

        public async Task<ResultResponse<TModel>> EditAsync<TModel>(Guid id, EditRecruiterRequest request)
        {
            var recruiter = await _recruiterRepository.GetByIdAsync(id);
            if (recruiter == null) throw new Exception("Recruiter is not found");
            
            recruiter = _mapper.Map(request, recruiter);
            _recruiterRepository.Update(recruiter);
            await _unitOfWork.SaveChangesAsync();
            
            var recruiterDto = _mapper.Map<Recruiter, TModel>(recruiter);
            return new ResultResponse<TModel>(recruiterDto);
        }

        public async Task<ListResponse<TModel>> GetAsync<TModel>(ListRecruitersRequest request)
        {
            var filter = _mapper.Map<ListRecruitersRequest, RecruitersFilter>(request);
            var sort = _mapper.Map<ListRecruitersRequest, Sort>(request);
            var paging = request.Skip.HasValue ?_mapper.Map<ListRecruitersRequest, Paging>(request) : null;

            var recruiters = await _recruiterRepository.GetAsync(filter, sort, paging);
            var recruitersCount = await _recruiterRepository.CountAsync(filter);

            var recruitersDtosList = _mapper.Map<List<Recruiter>, List<TModel>>(recruiters);
            return new ListResponse<TModel>(recruitersDtosList, recruitersCount);
        }

        public async Task<ResultResponse<TModel>> GetAsync<TModel>(Guid id)
        {
            var recruiter = await _recruiterRepository.GetByIdAsync(id);
            if (recruiter == null) throw new Exception("Recruiter is not found");

            var recruiterDto = _mapper.Map<Recruiter, TModel>(recruiter);
            return new ResultResponse<TModel>(recruiterDto);
        }

        public async Task DeleteAsync(Guid id)
        {
            var recruiter = await _recruiterRepository.GetByIdAsync(id);
            if (recruiter == null) throw new Exception("Recruiter is not found");

            _recruiterRepository.Delete(recruiter);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}