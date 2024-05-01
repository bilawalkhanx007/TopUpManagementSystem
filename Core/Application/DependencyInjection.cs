using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    /// <summary>
    /// Resolve All Depensency Related To Application Layer
    /// </summary>
    public static class DependencyInjection
    {
        /// <summary>
        /// This Method Will Inject Into Startup File.
        /// </summary>
        /// <param name="services"></param>
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            return services;
        }
    }
}
