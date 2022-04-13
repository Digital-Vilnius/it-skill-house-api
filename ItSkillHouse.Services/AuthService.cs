using System;
using System.Threading.Tasks;
using ItSkillHouse.Models.Repositories;
using ItSkillHouse.Models.Services;
using Microsoft.Graph;
using User = ItSkillHouse.Models.User;

namespace ItSkillHouse.Services;

public class AuthService : IAuthService
{
    private readonly GraphServiceClient _graphServiceClient;
    private readonly IUserRepository _userRepository;
        
    public AuthService(IUserRepository userRepository, GraphServiceClient graphServiceClient)
    {
        _userRepository = userRepository;
        _graphServiceClient = graphServiceClient;
    }
    
    public async Task<User> GetCurrentUserAsync()
    {
        var currentUser = await _graphServiceClient.Me.Request().GetAsync();
        
        var user = await _userRepository.GetAsync(user => user.Email == currentUser.UserPrincipalName);
        if (user == null) throw new Exception("User is not found");

        return user;
    }
}