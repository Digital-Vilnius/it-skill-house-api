using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ItSkillHouse.Contracts;
using ItSkillHouse.Contracts.ClientProject;
using ItSkillHouse.Models;
using ItSkillHouse.Models.Repositories;
using ItSkillHouse.Models.Services;

namespace ItSkillHouse.Services
{
    public class ClientProjectService : IClientProjectService
    {
        private readonly IClientProjectRepository _clientProjectRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ClientProjectService(IClientProjectRepository clientProjectRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _clientProjectRepository = clientProjectRepository;
        }
        
        public async Task<ResultResponse<TModel>> AddAsync<TModel>(AddClientProjectRequest request)
        {
            var duplicate = await _clientProjectRepository.GetAsync(clientProject => clientProject.Name == request.Name);
            if (duplicate != null) throw new Exception("Client project with this name is already created");
            
            var clientProject = _mapper.Map<AddClientProjectRequest, ClientProject>(request);
            await _clientProjectRepository.AddAsync(clientProject);
            await _unitOfWork.SaveChangesAsync();
            
            var clientProjectDto = _mapper.Map<ClientProject, TModel>(clientProject);
            return new ResultResponse<TModel>(clientProjectDto);
        }

        public async Task<ResultResponse<TModel>> EditAsync<TModel>(int id, EditClientProjectRequest request)
        {
            var duplicate = await _clientProjectRepository.GetAsync(clientProject => clientProject.Name == request.Name && clientProject.Id != id);
            if (duplicate != null) throw new Exception("Client project with this name is already exist");
            
            var clientProject = await _clientProjectRepository.GetByIdAsync(id);
            if (clientProject == null) throw new Exception("Client project is not found");
            
            clientProject = _mapper.Map(request, clientProject);
            _clientProjectRepository.Update(clientProject);
            await _unitOfWork.SaveChangesAsync();
            
            var clientProjectDto = _mapper.Map<ClientProject, TModel>(clientProject);
            return new ResultResponse<TModel>(clientProjectDto);
        }

        public async Task<ListResponse<TModel>> GetAsync<TModel>()
        {
            var clientProjects = await _clientProjectRepository.GetAsync();
            var clientProjectsCount = await _clientProjectRepository.CountAsync();

            var clientProjectsDtosList = _mapper.Map<List<ClientProject>, List<TModel>>(clientProjects);
            return new ListResponse<TModel>(clientProjectsDtosList, clientProjectsCount);
        }

        public async Task<ResultResponse<TModel>> GetAsync<TModel>(int id)
        {
            var clientProject = await _clientProjectRepository.GetByIdAsync(id);
            if (clientProject == null) throw new Exception("Client project is not found");

            var clientProjectDto = _mapper.Map<ClientProject, TModel>(clientProject);
            return new ResultResponse<TModel>(clientProjectDto);
        }

        public async Task DeleteAsync(int id)
        {
            var clientProject = await _clientProjectRepository.GetByIdAsync(id);
            if (clientProject == null) throw new Exception("Client project is not found");

            _clientProjectRepository.Delete(clientProject);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}