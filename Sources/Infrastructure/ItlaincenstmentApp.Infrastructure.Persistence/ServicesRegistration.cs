using ItlaincenstmentApp.Core.Domain.Interfaces;
using ItlaincenstmentApp.Infrastructure.Persistence.Context;
using ItlaincenstmentApp.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ItlaincenstmentApp.Infrastructure.Persistence
{
    public static class ServicesRegistration
    {
        // Extencion method - Decoration pattern 
        public static void AddPersistenceLaryerIoc(this IServiceCollection services, IConfiguration config)
        {
            #region Contexts
            if(config.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<InvestmentAppContext>(opt => opt.UseInMemoryDatabase("AppDb"));
            }
            else
            {
                var Connection = config
                    .GetConnectionString("DefaultConnection");
                services
                    .AddDbContext<InvestmentAppContext>(opt => opt
                        .UseSqlServer(Connection, m => m
                            .MigrationsAssembly(typeof(InvestmentAppContext).Assembly.FullName)),ServiceLifetime.Transient);
            }
            #endregion
            #region Respositories IOC
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<,>));
            services.AddTransient<IAssetRepository, AssetRepository>();
            services.AddTransient<IAssetTypeRepository, AssetTypeRepository>();
            services.AddTransient<IAssetHistoryRepositry, AssetHistoryRepositry>();
            services.AddTransient<IInvestmentAssetsRepository, InvestmentAssetsRepository>();
            services.AddTransient<IInvestmentPorfolioRepository, InvestmentPorfolioRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            #endregion
        }
    }
}
