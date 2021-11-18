namespace Nubi.Core.DependencyContainer
{
    using Microsoft.Extensions.DependencyInjection;
    using Nubi.Core.Application.Interfaces;
    using Nubi.Core.Application.Services;
    using Nubi.Core.Domain.Interfaces;
    using Nubi.Core.Infrastructure.Data.Repository;
    using System;
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IApiServices, ApiService>();
            //CleanArchitecture.Application
            services.AddScoped<IPaisService, PaisService>();
            services.AddScoped<IUserService, UserService>();
           
            //CleanArchitecture.Domain.Interfaces | CleanArchitecture.Infra.Data.Repositories
            //services.AddScoped<IRepository<User>, Repository<User>>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
