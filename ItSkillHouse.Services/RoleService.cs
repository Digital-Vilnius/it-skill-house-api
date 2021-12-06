using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ItSkillHouse.Contracts;
using ItSkillHouse.Contracts.Role;
using ItSkillHouse.Models;
using ItSkillHouse.Models.Repositories;
using ItSkillHouse.Models.Services;

namespace ItSkillHouse.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RoleService(IRoleRepository roleRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _roleRepository = roleRepository;
        }
        
        public async Task<ResultResponse<TModel>> AddAsync<TModel>(AddRoleRequest request)
        {
            var duplicate = await _roleRepository.GetAsync(role => role.Name == request.Name);
            if (duplicate != null) throw new Exception("Role with this name is already exist");
            
            var role = _mapper.Map<AddRoleRequest, Role>(request);
            await _roleRepository.AddAsync(role);
            await _unitOfWork.SaveChangesAsync();
            
            var roleDto = _mapper.Map<Role, TModel>(role);
            return new ResultResponse<TModel>(roleDto);
        }

        public async Task<ResultResponse<TModel>> EditAsync<TModel>(Guid id, EditRoleRequest request)
        {
            var duplicate = await _roleRepository.GetAsync(role => role.Name == request.Name && role.Id != id);
            if (duplicate != null) throw new Exception("Role with this name is already exist");
            
            var role = await _roleRepository.GetByIdAsync(id);
            if (role == null) throw new Exception("Role is not found");
            
            role = _mapper.Map(request, role);
            _roleRepository.Update(role);
            await _unitOfWork.SaveChangesAsync();
            
            var roleDto = _mapper.Map<Role, TModel>(role);
            return new ResultResponse<TModel>(roleDto);
        }

        public async Task<ListResponse<TModel>> GetAsync<TModel>()
        {
            var roles = await _roleRepository.GetAsync();
            var rolesCount = await _roleRepository.CountAsync();

            var rolesDtosList = _mapper.Map<List<Role>, List<TModel>>(roles);
            return new ListResponse<TModel>(rolesDtosList, rolesCount);
        }

        public async Task<ResultResponse<TModel>> GetAsync<TModel>(Guid id)
        {
            var role = await _roleRepository.GetByIdAsync(id);
            if (role == null) throw new Exception("Role is not found");

            var roleDto = _mapper.Map<Role, TModel>(role);
            return new ResultResponse<TModel>(roleDto);
        }

        public async Task DeleteAsync(Guid id)
        {
            var role = await _roleRepository.GetByIdAsync(id);
            if (role == null) throw new Exception("Role is not found");

            _roleRepository.Delete(role);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}