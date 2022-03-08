﻿using Microsoft.Extensions.DependencyInjection;
using PizzaPlaceDB.DAL;
using PizzaPlaceDB.DAL.Context;

namespace PizzaPlace.BL.Data
{
    public static class DbRegistrator
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services) =>
            services.AddDbContext<PizzaPlaceContext>()
            .AddRepositories();
    }
}