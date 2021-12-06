using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ItSkillHouse.Contracts;
using ItSkillHouse.Contracts.Authentication;
using ItSkillHouse.Models;
using ItSkillHouse.Models.Repositories;
using ItSkillHouse.Models.Services;

namespace ItSkillHouse.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository _userRepository;
        private readonly IEncryptionService _encryptionService;
        private readonly ITokenRepository _tokenRepository;
        private readonly ITokenService _tokenService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AuthenticationService
        (
            IUserRepository userRepository,
            IMapper mapper,
            IUnitOfWork unitOfWork,
            IEncryptionService encryptionService,
            ITokenService tokenService,
            ITokenRepository tokenRepository
        )
        {
            _tokenService = tokenService;
            _encryptionService = encryptionService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userRepository = userRepository;
            _tokenRepository = tokenRepository;
        }

        public async Task<ResultResponse<Tokens>> LoginAsync(LoginRequest request)
        {
            var user = await _userRepository.GetAsync(user => user.Email == request.Email);
            if (user == null) throw new Exception("User is not found");

            var isPasswordValid = _encryptionService.VerifyHash(request.Password, user.PasswordHash, user.PasswordSalt);
            if (!isPasswordValid) throw new Exception("Password is not correct");

            var refreshToken = _tokenService.GenerateRefreshToken(user.Id);
            if (user.Tokens == null) user.Tokens = new List<Token>{ refreshToken }; 
            else user.Tokens.Add(refreshToken);

            user.LastLoginDate = DateTime.Now;
            _userRepository.Update(user);
            await _unitOfWork.SaveChangesAsync();
            
            var tokens = new Tokens { RefreshToken = refreshToken.Value, Token = _tokenService.GenerateToken(user.Id) };
            return new ResultResponse<Tokens>(tokens);
        }

        public async Task<ResultResponse<Tokens>> RegisterAsync(RegisterRequest request)
        {
            var duplicate = await _userRepository.GetAsync(user => user.Email == request.Email);
            if (duplicate != null) throw new Exception("User with this email is already exist");
            
            var user = _mapper.Map<RegisterRequest, User>(request);
            user.LastLoginDate = DateTime.Now;
            
            var refreshToken = _tokenService.GenerateRefreshToken();
            if (user.Tokens == null) user.Tokens = new List<Token>{ refreshToken }; 
            else user.Tokens.Add(refreshToken);
            
            user.PasswordSalt = _encryptionService.CreateSalt();
            user.PasswordHash = _encryptionService.CreateHash(request.Password, user.PasswordSalt);

            await _userRepository.AddAsync(user);
            await _unitOfWork.SaveChangesAsync();
            
            var tokens = new Tokens { RefreshToken = refreshToken.Value, Token = _tokenService.GenerateToken(user.Id) };
            return new ResultResponse<Tokens>(tokens);
        }

        public async Task<ResultResponse<Tokens>> RefreshToken(RefreshTokenRequest request)
        {
            var refreshToken = await _tokenRepository.GetValidRefreshToken(request.RefreshToken);
            if (refreshToken == null) throw new Exception("Valid token is not found");

            var newRefreshToken = _tokenService.GenerateRefreshToken(refreshToken.UserId);
            refreshToken.User.Tokens.Add(refreshToken);
            refreshToken.Revoked = DateTime.UtcNow;
            
            _tokenRepository.Update(refreshToken);
            await _tokenRepository.AddAsync(newRefreshToken);
            await _unitOfWork.SaveChangesAsync();
            
            var tokens = new Tokens { RefreshToken = newRefreshToken.Value, Token = _tokenService.GenerateToken(refreshToken.User.Id) };
            return new ResultResponse<Tokens>(tokens);
        }
    }
}