using DGII.Core.Application.Interfaces.Service;
using DGII.Core.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace DGII.Core.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IContribuyenteService, ContribuyenteService>();
            services.AddTransient<IComprobanteFiscalService, ComprobanteFiscalService>();

            return services;

        }

        public static IServiceCollection AddVmMaping(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }

    }
}
