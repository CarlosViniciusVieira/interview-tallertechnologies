using interview_tallertechnologies.Application.UseCases.User.v1.Queries;
using interview_tallertechnologies.Data.Repositories;
using interview_tallertechnologies.Data.UnitOfwork;
using interview_tallertechnologies.Domain.Interfaces;

namespace interview_tallertechnologies.Api
{
    public static class Startup
    {
        public static void ConfigureServices(this IServiceCollection services)
        {


            services.AddAutoMapper(typeof(GetUserByUserNameQueryProfile).Assembly);

            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(GetUserByUserNameUseCase).Assembly);
                cfg.Lifetime = ServiceLifetime.Scoped;
            });

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }
    }
}
