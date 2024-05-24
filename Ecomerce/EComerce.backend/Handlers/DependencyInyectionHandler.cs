using ECommerce.backend.Data;
using ECommerce.backend.Repositories.Implementations;
using ECommerce.backend.Repositories.Interfaces;
using ECommerce.backend.UnitOfWork.Implementations;
using ECommerce.backend.UnitOfWork.Interfaces;
using System.Diagnostics.CodeAnalysis;

namespace ECommerce.backend.Handlers
{
    public class DependencyInyectionHandler
    {
        [ExcludeFromCodeCoverage]
        public static void DepencyInyectionConfig(IServiceCollection services)
        {
            services.AddTransient<Seedb>();

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(IGenericUnitOfWork<>), typeof(GenericUnitOfWork<>));
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<ICountyUnitOfWork, CountryUnitOfWork>();
            services.AddScoped<IStatesRepository, StateRepository>();
            services.AddScoped<IStatesUnitOfWork, StateUnitOfWork>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<ICityUnitOfWork, CityUnitOfWork>();
        }
    }
}
