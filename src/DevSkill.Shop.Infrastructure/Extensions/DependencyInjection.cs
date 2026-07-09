using DevSkill.Shop.Application.Contracts;
using DevSkill.Shop.Infrastructure.Data;
using DevSkill.Shop.Infrastructure.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevSkill.Shop.Infrastructure.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureDependency(this IServiceCollection services)
        {

            services.AddScoped<IApplicationUnitOfWork, ApplicationUnitOfWork>();
            services.AddScoped<ITeamMemberRepository, TeamMemberRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            

            return services;
        }
    }
}
