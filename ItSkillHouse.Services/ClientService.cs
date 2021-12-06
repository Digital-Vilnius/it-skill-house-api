using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ItSkillHouse.Contracts;
using ItSkillHouse.Contracts.Client;
using ItSkillHouse.Models;
using ItSkillHouse.Models.Repositories;
using ItSkillHouse.Models.Services;

namespace ItSkillHouse.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ClientService(IClientRepository clientRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _clientRepository = clientRepository;
        }
        
        public async Task<ResultResponse<TModel>> AddAsync<TModel>(AddClientRequest request)
        {
            var duplicate = await _clientRepository.GetAsync(client => client.Name == request.Name);
            if (duplicate != null) throw new Exception("Client with this name is already created");
            
            var client = _mapper.Map<AddClientRequest, Client>(request);
            await _clientRepository.AddAsync(client);
            await _unitOfWork.SaveChangesAsync();
            
            var clientDto = _mapper.Map<Client, TModel>(client);
            return new ResultResponse<TModel>(clientDto);
        }

        public async Task<ResultResponse<TModel>> EditAsync<TModel>(Guid id, EditClientRequest request)
        {
            var duplicate = await _clientRepository.GetAsync(client => client.Name == request.Name && client.Id != id);
            if (duplicate != null) throw new Exception("Client with this name is already exist");
            
            var client = await _clientRepository.GetByIdAsync(id);
            if (client == null) throw new Exception("Client is not found");
            
            client = _mapper.Map(request, client);
            _clientRepository.Update(client);
            await _unitOfWork.SaveChangesAsync();
            
            var clientDto = _mapper.Map<Client, TModel>(client);
            return new ResultResponse<TModel>(clientDto);
        }

        public async Task<ListResponse<TModel>> GetAsync<TModel>()
        {
            var clients = await _clientRepository.GetAsync();
            var clientsCount = await _clientRepository.CountAsync();

            var clientsDtosList = _mapper.Map<List<Client>, List<TModel>>(clients);
            return new ListResponse<TModel>(clientsDtosList, clientsCount);
        }

        public async Task<ResultResponse<TModel>> GetAsync<TModel>(Guid id)
        {
            var client = await _clientRepository.GetByIdAsync(id);
            if (client == null) throw new Exception("Client is not found");

            var clientDto = _mapper.Map<Client, TModel>(client);
            return new ResultResponse<TModel>(clientDto);
        }

        public async Task DeleteAsync(Guid id)
        {
            var client = await _clientRepository.GetByIdAsync(id);
            if (client == null) throw new Exception("Client is not found");

            _clientRepository.Delete(client);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}