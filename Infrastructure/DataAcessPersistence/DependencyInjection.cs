using DataAcessPersistence.Context;
using DataAcessPersistence.Service;
using DataAcessPersistence.UnitOfWork;
using Domain.Abstructions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessPersistence
{
    /// <summary>
    /// Resolve All Depensency Related To Persistence Layer
    /// </summary>
    public static class DependencyInjection
    {
        /// <summary>
        /// This Method Will Inject Into Startup File.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DBConnection"),
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());



            services.AddScoped<IUnitOfWork, DataAcessPersistence.UnitOfWork.UnitOfWork>();
            services.AddScoped<IBalanceManagementAppUnitOfWork, BalanceManagementAppUnitOfWork>();



            services.AddHttpClient();
            services.AddSingleton<IBalanceManangementAppService, BalanceManangementAppService>();


            return services;
        }
    }
}
