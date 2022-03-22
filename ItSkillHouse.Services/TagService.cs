using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ItSkillHouse.Contracts;
using ItSkillHouse.Contracts.Tag;
using ItSkillHouse.Models;
using ItSkillHouse.Models.Repositories;
using ItSkillHouse.Models.Services;

namespace ItSkillHouse.Services
{
    public class TagService : ITagService
    {
        private readonly ITagRepository _tagRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TagService(ITagRepository tagRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _tagRepository = tagRepository;
        }

        public async Task<ResultResponse<TModel>> AddAsync<TModel>(SaveTagRequest request)
        {
            var duplicate = await _tagRepository.GetAsync(tag => tag.Name == request.Name);
            if (duplicate != null) throw new Exception("Tag with this name is already exist");
            
            var tag = _mapper.Map<SaveTagRequest, Tag>(request);
            await _tagRepository.AddAsync(tag);
            await _unitOfWork.SaveChangesAsync();
            
            var tagDto = _mapper.Map<Tag, TModel>(tag);
            return new ResultResponse<TModel>(tagDto);
        }

        public async Task<ListResponse<TModel>> GetAsync<TModel>()
        {
            var tags = await _tagRepository.GetAsync();
            var tagsCount = await _tagRepository.CountAsync();

            var tagsDtosList = _mapper.Map<List<Tag>, List<TModel>>(tags);
            return new ListResponse<TModel>(tagsDtosList, tagsCount);
        }
    }
}