using Microsoft.Extensions.DependencyInjection;
using PizzaPlace.BL.Interfaces;

namespace PizzaPlace.BL.Services
{
    public static class ServiceRegistrator
    {
        public static IServiceCollection AddServices(this IServiceCollection services) => services
            .AddTransient<IUserService, UserService>()
            .AddTransient<IBasketService, BasketService>()
            ;
    }
}
