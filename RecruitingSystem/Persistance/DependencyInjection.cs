using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Application.Common.Interfaces;

namespace Persistance
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistanceDependencies(this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<RecruitingSystemDbContext>(opt => opt.UseSqlServer(connectionString));

            services.AddScoped<IReqruitingSystemDbContext, RecruitingSystemDbContext>();

            return services;
        }
    }
}
