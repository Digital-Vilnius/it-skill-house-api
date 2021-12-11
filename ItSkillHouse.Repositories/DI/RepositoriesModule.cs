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
            services.AddScoped<ITechnologyRepository, TechnologyRepository>();
            services.AddScoped<IContractorRepository, ContractorRepository>();
            services.AddScoped<INoteRepository, NoteRepository>();
            services.AddScoped<IRecruiterRepository, RecruiterRepository>();
            services.AddScoped<ITokenRepository, TokenRepository>();
            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<IProfessionRepository, ProfessionRepository>();
        }
    }
}