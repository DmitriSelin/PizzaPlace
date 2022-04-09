using Microsoft.Extensions.DependencyInjection;
using PizzaPlaceDB.DAL;
using PizzaPlaceDB.DAL.Context;

namespace PizzaPlace.BL.Data
{
    public static class DbRegistrator
    {
        /// <summary>Adding database context and repositories</summary>
        public static IServiceCollection AddDatabase(this IServiceCollection services) =>
            services.AddDbContext<PizzaPlaceContext>()
            .AddRepositories();
    }
}