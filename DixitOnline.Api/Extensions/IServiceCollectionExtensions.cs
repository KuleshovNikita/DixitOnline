using DixitOnline.Core;
using Microsoft.Extensions.DependencyInjection;

namespace DixitOnline.Api.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddModule<TModule>(this IServiceCollection services) 
            where TModule: IModule, new()
        {
            var module = new TModule();
            module.ConfigureModule(services);

            return services;
        }
    }
}
