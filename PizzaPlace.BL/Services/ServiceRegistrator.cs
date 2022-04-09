using Microsoft.Extensions.DependencyInjection;
using PizzaPlace.BL.Interfaces;

namespace PizzaPlace.BL.Services
{
    public static class ServiceRegistrator
    {
        /// <summary>Adding services</summary>
        public static IServiceCollection AddServices(this IServiceCollection services) => services
            .AddTransient<IUserService, UserService>()
            .AddTransient<IBasketService, BasketService>()
            .AddTransient<ISaleService, SaleService>()
            ;
    }
}
