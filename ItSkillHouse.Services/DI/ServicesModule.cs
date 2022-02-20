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
                configure.AddProfile<TechnologyProfile>();
                configure.AddProfile<NoteProfile>();
                configure.AddProfile<ContractorProfile>();
                configure.AddProfile<UserProfile>();
                configure.AddProfile<TagProfile>();
                configure.AddProfile<ProfessionProfile>();
                configure.AddProfile<EventProfile>();
            }, typeof(ServicesModule));

            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<ITechnologyService, TechnologyService>();
            services.AddScoped<INoteService, NoteService>();
            services.AddScoped<IContractorService, ContractorService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITagService, TagService>();
            services.AddScoped<IProfessionService, ProfessionService>();
            services.AddScoped<IEventService, EventService>();
            services.AddScoped<IEmailService, EmailService>();
        }
    }
}