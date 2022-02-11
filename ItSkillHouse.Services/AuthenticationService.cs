﻿using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using ItSkillHouse.Contracts;
using ItSkillHouse.Contracts.Authentication;
using ItSkillHouse.Models;
using ItSkillHouse.Models.Repositories;
using ItSkillHouse.Models.Services;
using Microsoft.AspNetCore.Http;

namespace ItSkillHouse.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository _userRepository;
        private readonly IEncryptionService _encryptionService;
        private readonly ITokenService _tokenService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly HttpContext _httpContext;

        public AuthenticationService
        (
            IUserRepository userRepository,
            IMapper mapper,
            IUnitOfWork unitOfWork,
            IEncryptionService encryptionService,
            ITokenService tokenService,
            IHttpContextAccessor httpContextAccessor
        )
        {
            _tokenService = tokenService;
            _encryptionService = encryptionService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userRepository = userRepository;
            _httpContext = httpContextAccessor.HttpContext;
        }

        public async Task<ResultResponse<Tokens>> LoginAsync(LoginRequest request)
        {
            var user = await _userRepository.GetAsync(user => user.Email == request.Email);
            if (user == null) throw new Exception("User is not found");

            var isPasswordValid = _encryptionService.VerifyHash(request.Password, user.PasswordHash, user.PasswordSalt);
            if (!isPasswordValid) throw new Exception("Password is not correct");

            user.RefreshToken = _tokenService.GenerateRefreshToken();
            user.LastLoginDate = DateTime.Now;
            _userRepository.Update(user);
            await _unitOfWork.SaveChangesAsync();
            
            var tokens = new Tokens { RefreshToken = user.RefreshToken, Token = _tokenService.GenerateToken(user.Id) };
            return new ResultResponse<Tokens>(tokens);
        }

        public async Task<ResultResponse<Tokens>> RegisterAsync(RegisterRequest request)
        {
            var duplicate = await _userRepository.GetAsync(user => user.Email == request.Email);
            if (duplicate != null) throw new Exception("User with this email is already exist");
            
            var user = _mapper.Map<RegisterRequest, User>(request);
            user.LastLoginDate = DateTime.Now;
            user.RefreshToken = _tokenService.GenerateRefreshToken();
            user.PasswordSalt = _encryptionService.CreateSalt();
            user.PasswordHash = _encryptionService.CreateHash(request.Password, user.PasswordSalt);

            await _userRepository.AddAsync(user);
            await _unitOfWork.SaveChangesAsync();
            
            var tokens = new Tokens { RefreshToken = user.RefreshToken, Token = _tokenService.GenerateToken(user.Id) };
            return new ResultResponse<Tokens>(tokens);
        }

        public async Task<ResultResponse<Tokens>> RefreshToken(RefreshTokenRequest request)
        {
            var user = await _userRepository.GetAsync(user => user.RefreshToken == request.RefreshToken);
            if (user == null) throw new Exception("User is not found");

            user.RefreshToken = _tokenService.GenerateRefreshToken();
            _userRepository.Update(user);
            await _unitOfWork.SaveChangesAsync();
            
            var tokens = new Tokens { RefreshToken = user.RefreshToken, Token = _tokenService.GenerateToken(user.Id) };
            return new ResultResponse<Tokens>(tokens);
        }
        
        public async Task<LoggedUserDto> GetLoggedUserAsync()
        {
            if (_httpContext.User.Identity is not {IsAuthenticated: true}) return null;

            var id = _httpContext.User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier)?.Value;
            if (id == null) return null;

            var user = await _userRepository.GetAsync(user => user.Id == int.Parse(id));
            if (user == null) return null;

           return _mapper.Map<User, LoggedUserDto>(user);
        }
    }
}