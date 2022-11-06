using GreenSharing.API.Repositories;
using GreenSharing.API.Repositories.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreenSharing.API
{
    public static class BootStrap
    { 
       /// <summary>
       /// Injects the business access layer.
       /// </summary>
       /// <param name="services">The services.</param>
        public static void BootStrapRepositories(this IServiceCollection services)
        {
            //REPOSITORIES (I)GenericRepositories - Contains every generic method.
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            //REPOSITORIES (I)ClassRepositories - Contains custom methods targeted at the Class
            services.AddScoped(typeof(IAccountRepository), typeof(AccountRepository));
            //services.AddScoped(typeof(IEventRepository), typeof(IEventRepository));
        }
    }
}
