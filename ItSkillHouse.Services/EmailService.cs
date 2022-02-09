using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ItSkillHouse.Contracts;
using ItSkillHouse.Contracts.Authentication;
using ItSkillHouse.Contracts.Email;
using ItSkillHouse.Models;
using ItSkillHouse.Models.Repositories;
using ItSkillHouse.Models.Services;

namespace ItSkillHouse.Services
{
    public class EmailService : IEmailService
    {
        private readonly IEmailRepository _emailRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmailService(IEmailRepository emailRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _emailRepository = emailRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        
        public async Task<ResultResponse<TModel>> AddAsync<TModel>(AddEmailRequest request, LoggedUserDto loggedUser)
        {
            var email = _mapper.Map<AddEmailRequest, Email>(request);
            email.SenderId = loggedUser.Id;
            
            await _emailRepository.AddAsync(email);
            await _unitOfWork.SaveChangesAsync();
            
            var emailDto = _mapper.Map<Email, TModel>(email);
            return new ResultResponse<TModel>(emailDto);
        }
        
        public async Task<ListResponse<TModel>> GetAsync<TModel>(ListEmailsRequest request)
        {
            var filter = _mapper.Map<ListEmailsRequest, EmailsFilter>(request);
            var sort = _mapper.Map<ListEmailsRequest, Sort>(request);
            var paging = _mapper.Map<ListEmailsRequest, Paging>(request);
            
            var emails = await _emailRepository.GetAsync(filter, sort, paging);
            var emailsCount = await _emailRepository.CountAsync(filter);

            var emailsDtosList = _mapper.Map<List<Email>, List<TModel>>(emails);
            return new ListResponse<TModel>(emailsDtosList, emailsCount);
        }
    }
}