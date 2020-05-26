using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TRobles.OA.C.Common.ImplementRepos;
using TRobles.OA.C.Common.Interfaces;
using TRobles.OA.C.Repository;
using TRobles.OA.C.Service;

namespace TRobles.OA.C.API.MiddleWare
{
    public static class IoCContaner
    { 
        public static IServiceCollection AddDependency(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));

            services.AddTransient<IUserService, UserService>();
            return services;
        }
    }
}
