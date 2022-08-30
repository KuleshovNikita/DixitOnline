using DixitOnline.Core;
using Microsoft.Extensions.DependencyInjection;

namespace DixitOnline.DataAccess.Modules
{
    public class DataAccessModule : IModule
    {
        public IServiceCollection ConfigureModule(IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            return services;
        }
    }
}
