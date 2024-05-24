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
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(IGenericUnitOfWork<>), typeof(GenericUnitOfWork<>));

        }
    }
}
