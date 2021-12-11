﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ItSkillHouse.Contracts;
using ItSkillHouse.Contracts.Note;
using ItSkillHouse.Models;
using ItSkillHouse.Models.Repositories;
using ItSkillHouse.Models.Services;

namespace ItSkillHouse.Services
{
    public class NoteService : INoteService
    {
        private readonly INoteRepository _noteRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public NoteService(INoteRepository noteRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _noteRepository = noteRepository;
        }
        
        public async Task<ResultResponse<TModel>> AddAsync<TModel>(AddNoteRequest request)
        {
            var note = _mapper.Map<AddNoteRequest, Note>(request);
            await _noteRepository.AddAsync(note);
            await _unitOfWork.SaveChangesAsync();
            
            var noteDto = _mapper.Map<Note, TModel>(note);
            return new ResultResponse<TModel>(noteDto);
        }

        public async Task<ResultResponse<TModel>> EditAsync<TModel>(int id, EditNoteRequest request)
        {
            var note = await _noteRepository.GetByIdAsync(id);
            if (note == null) throw new Exception("Note is not found");
            
            note = _mapper.Map(request, note);
            _noteRepository.Update(note);
            await _unitOfWork.SaveChangesAsync();
            
            var noteDto = _mapper.Map<Note, TModel>(note);
            return new ResultResponse<TModel>(noteDto);
        }

        public async Task<ListResponse<TModel>> GetAsync<TModel>()
        {
            var notes = await _noteRepository.GetAsync();
            var notesCount = await _noteRepository.CountAsync();

            var notesDtosList = _mapper.Map<List<Note>, List<TModel>>(notes);
            return new ListResponse<TModel>(notesDtosList, notesCount);
        }

        public async Task<ResultResponse<TModel>> GetAsync<TModel>(int id)
        {
            var note = await _noteRepository.GetByIdAsync(id);
            if (note == null) throw new Exception("Note is not found");

            var noteDto = _mapper.Map<Note, TModel>(note);
            return new ResultResponse<TModel>(noteDto);
        }

        public async Task DeleteAsync(int id)
        {
            var note = await _noteRepository.GetByIdAsync(id);
            if (note == null) throw new Exception("Note is not found");

            _noteRepository.Delete(note);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}