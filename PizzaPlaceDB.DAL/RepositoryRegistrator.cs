using Microsoft.Extensions.DependencyInjection;
using PizzaPlace.BL.Interfaces;
using PizzaPlaceDB.DAL.Entities;

namespace PizzaPlaceDB.DAL
{
    public static class RepositoryRegistrator
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services) => services
            .AddTransient<IRepository<Admin>, DbRepository<Admin>>()
            .AddTransient<IRepository<Basket>, DbRepository<Basket>>()
            .AddTransient<IRepository<Bonus>, DbRepository<Bonus>>()
            .AddTransient<IRepository<Category>, DbRepository<Category>>()
            .AddTransient<IRepository<Discount>, DbRepository<Discount>>()
            .AddTransient<IRepository<Food>, DbRepository<Food>>()
            .AddTransient<IRepository<Order>, DbRepository<Order>>()
            .AddTransient<IRepository<User>, DbRepository<User>>()
            ;
    }
}