using Microsoft.Extensions.DependencyInjection;

namespace DixitOnline.Core
{
    public interface IModule
    {
        IServiceCollection ConfigureModule(IServiceCollection services);
    }
}
