using ItSkillHouse.Models.Repositories;
using ItSkillHouse.Repositories.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ItSkillHouse.Repositories.DI
{
    public static class RepositoriesModule
    {
        public static void RegisterDependencies(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SqlContext>(options => options.UseSqlServer(configuration.GetConnectionString("SqlContext")));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<ITechnologyRepository, TechnologyRepository>();
            services.AddScoped<IClientProjectRepository, ClientProjectRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IContractorRepository, ContractorRepository>();
            services.AddScoped<IContractorTechnologyRepository, ContractorTechnologyRepository>();
            services.AddScoped<IContractRepository, ContractRepository>();
            services.AddScoped<IRateRepository, RateRepository>();
            services.AddScoped<IContractorNoteRepository, ContractorNoteRepository>();
            services.AddScoped<IRecruiterRepository, RecruiterRepository>();
            services.AddScoped<ITokenRepository, TokenRepository>();
        }
    }
}