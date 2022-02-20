using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ItSkillHouse.Contracts;
using ItSkillHouse.Models;
using ItSkillHouse.Models.Repositories;
using ItSkillHouse.Models.Services;

namespace ItSkillHouse.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<ListResponse<TModel>> GetAsync<TModel>()
        {
            var recruiters = await _userRepository.GetAsync();
            var recruitersCount = await _userRepository.CountAsync();

            var recruitersDtosList = _mapper.Map<List<User>, List<TModel>>(recruiters);
            return new ListResponse<TModel>(recruitersDtosList, recruitersCount);
        }
    }
}