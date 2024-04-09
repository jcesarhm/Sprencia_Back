using Microsoft.Extensions.DependencyInjection;
using SPRENCIA.Application.Contracts.Services;
using SPRENCIA.Application.Services;
using SPRENCIA.Infraestructure;
using SPRENCIA.Infraestructure.Contracts;
using SPRENCIA.Infraestructure.Repositories;

namespace SPRENCIA.CrossCutting.Configuration
{
    public  static class IoC
    {
        public static  IServiceCollection Register(this IServiceCollection services)
        {
            AddRepositories(services);
            AddServices(services);
            AddDbContext(services);

            return services;
        }

        public static IServiceCollection AddDbContext(IServiceCollection services)
        {
           services.AddTransient<SprenciaDbContext> ();

            return services;
        }

        private static IServiceCollection AddServices(IServiceCollection services)
        {
            //Establecer las conexiones de servicios
            services.AddTransient<IActivityService, ActivityService>();
            services.AddTransient<ICommentRepository, CommentRepository>();
            services.AddTransient<IScheduleRepository, ScheduleRepository>();
            
            return services;
        }

        private static IServiceCollection AddRepositories(IServiceCollection services)
        {
            //Establecer las conexiones de repositorios
            services.AddTransient<IActivityRepository, ActivityRepository>();
            services.AddTransient<ICommentRepository, CommentRepository>();
            services.AddTransient<IScheduleRepository, ScheduleRepository>();

            return services;
        }
    }
}
