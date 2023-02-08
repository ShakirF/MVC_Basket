using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StateManagements.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateManagements.Models
{
    public static class GlobalConfiguration
    {
        
        public static IServiceCollection ModelsConfiguration(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<StateManagementContext>(options => options.UseSqlServer(configuration.GetConnectionString("default")));

            return services;
        }
    }
}
