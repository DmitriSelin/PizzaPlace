using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PizzaPlaceDB.DAL.Context;

namespace PizzaPlace.BL.Data
{
    public static class DbRegistrator
    {
        public static IServiceCollection AddDatabase(IServiceCollection services, IConfiguration configuration) =>
            services.AddDbContext<PizzaPlaceContext>();
    }
}
