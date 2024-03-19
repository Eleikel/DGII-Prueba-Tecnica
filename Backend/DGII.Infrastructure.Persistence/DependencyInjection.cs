using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using DGII.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using DGII.Core.Application.Interfaces.Repository;
using DGII.Infrastructure.Persistence.Repositories;
using DGII.Infrastructure.Persistence.Seed;

namespace DGII.Infrastructure.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {



            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration["ConnectionStrings:DefaultConnection"]);
            });


            #region Repositories
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IContribuyenteRepository, ContribuyenteRepository>();
            services.AddTransient<IComprobanteFiscalRepository, ComprobanteFiscalRepository>();

            #endregion

            return services;
        }
    }
}
