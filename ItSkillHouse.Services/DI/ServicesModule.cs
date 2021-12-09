using ItSkillHouse.Models.Services;
using ItSkillHouse.Services.Mapper;
using Microsoft.Extensions.DependencyInjection;

namespace ItSkillHouse.Services.DI
{
    public static class ServicesModule
    {
        public static void RegisterDependencies(IServiceCollection services)
        {
            services.AddAutoMapper(configure => {
                configure.AddProfile<BaseProfile>();
                configure.AddProfile<AuthenticationProfile>();
                configure.AddProfile<RoleProfile>();
                configure.AddProfile<UserProfile>();
                configure.AddProfile<TechnologyProfile>();
                configure.AddProfile<ClientProfile>();
                configure.AddProfile<ClientProjectProfile>();
                configure.AddProfile<NoteProfile>();
                configure.AddProfile<ContractorProfile>();
                configure.AddProfile<RecruiterProfile>();
                configure.AddProfile<ContractProfile>();
                configure.AddProfile<TagProfile>();
            }, typeof(ServicesModule));
            
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<ITechnologyService, TechnologyService>();
            services.AddScoped<IEncryptionService, EncryptionService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IClientProjectService, ClientProjectService>();
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<INoteService, NoteService>();
            services.AddScoped<IRateService, RateService>();
            services.AddScoped<IContractorService, ContractorService>();
            services.AddScoped<IRecruiterService, RecruiterService>();
            services.AddScoped<IContractService, ContractService>();
            services.AddScoped<ITagService, TagService>();
        }
    }
}