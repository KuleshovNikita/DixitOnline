using DixitOnline.Business.Services;
using DixitOnline.Business.Services.Interfaces;
using DixitOnline.Core;
using Microsoft.Extensions.DependencyInjection;

namespace DixitOnline.Business.Modules
{
    public class BusinessModule : IModule
    {
        public IServiceCollection ConfigureModule(IServiceCollection services)
        {
            services.AddScoped<IPlayerService, PlayerService>();
            services.AddScoped<IRoomService, RoomService>();

            return services;
        }
    }
}
