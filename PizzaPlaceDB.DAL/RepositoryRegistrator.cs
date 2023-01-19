using Microsoft.Extensions.DependencyInjection;
using PizzaPlace.BL.Interfaces;
using PizzaPlaceDB.DAL.Entities;

namespace PizzaPlaceDB.DAL
{
    public static class RepositoryRegistrator
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services) => services
            .AddTransient<IRepository<Basket>, BasketRepository>()
            .AddTransient<IRepository<Bonus>, DbRepository<Bonus>>()
            .AddTransient<IRepository<Category>, DbRepository<Category>>()
            .AddTransient<IRepository<Discount>, DbRepository<Discount>>()
            .AddTransient<IRepository<Food>, FoodRepository>()
            .AddTransient<IRepository<User>, UserRepository>()
            ;
    }
}