using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ItSkillHouse.Contracts;
using ItSkillHouse.Contracts.User;
using ItSkillHouse.Models;
using ItSkillHouse.Models.Repositories;
using ItSkillHouse.Models.Services;

namespace ItSkillHouse.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<ResultResponse<TModel>> AddAsync<TModel>(AddUserRequest request)
        {
            var duplicate = await _userRepository.GetAsync(user => user.Email == request.Email);
            if (duplicate != null) throw new Exception("User with this email is already exist");
            
            var user = _mapper.Map<AddUserRequest, User>(request);
            await _userRepository.AddAsync(user);
            await _unitOfWork.SaveChangesAsync();
            
            var userDto = _mapper.Map<User, TModel>(user);
            return new ResultResponse<TModel>(userDto);
        }

        public async Task<ResultResponse<TModel>> EditAsync<TModel>(Guid id, EditUserRequest request)
        {
            var duplicate = await _userRepository.GetAsync(user => user.Email == request.Email && user.Id != id);
            if (duplicate != null) throw new Exception("User with this email is already exist");
            
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null) throw new Exception("User is not found");
            
            user = _mapper.Map(request, user);
            _userRepository.Update(user);
            await _unitOfWork.SaveChangesAsync();
            
            var userDto = _mapper.Map<User, TModel>(user);
            return new ResultResponse<TModel>(userDto);
        }

        public async Task<ListResponse<TModel>> GetAsync<TModel>(ListUsersRequest request)
        {
            var filter = _mapper.Map<ListUsersRequest, UsersFilter>(request);
            var sort = _mapper.Map<ListUsersRequest, Sort>(request);
            var paging = _mapper.Map<ListUsersRequest, Paging>(request);

            var users = await _userRepository.GetAsync(filter, sort, paging);
            var usersCount = await _userRepository.CountAsync(filter);

            var usersDtosList = _mapper.Map<List<User>, List<TModel>>(users);
            return new ListResponse<TModel>(usersDtosList, usersCount);
        }

        public async Task<ResultResponse<TModel>> GetAsync<TModel>(Guid id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null) throw new Exception("User is not found");

            var userDto = _mapper.Map<User, TModel>(user);
            return new ResultResponse<TModel>(userDto);
        }

        public async Task DeleteAsync(Guid id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null) throw new Exception("User is not found");

            _userRepository.Delete(user);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}