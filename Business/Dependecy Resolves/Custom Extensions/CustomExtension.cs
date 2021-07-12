using Business.Abstract;
using Business.Concrete.Managers;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dependecy_Resolves.Custom_Extensions
{
    public static class CustomExtension
    {
        public static void AddContainerWithDependecies(this IServiceCollection services) 
        {
            services.AddScoped<ILocationService, LocationManager>();
            services.AddScoped<ILocationDal, EfLocationDal>();

       

        }
    }
}
