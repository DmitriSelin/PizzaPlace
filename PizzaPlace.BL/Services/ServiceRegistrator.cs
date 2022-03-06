using Microsoft.Extensions.DependencyInjection;

namespace PizzaPlace.BL.Services
{
    public static class ServiceRegistrator
    {
        public static IServiceCollection AddServices(this IServiceCollection services) => services
            .AddTransient<UserService>()
            ;
    }
}
