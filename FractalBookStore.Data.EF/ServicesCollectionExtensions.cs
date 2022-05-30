using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace FractalBookStore.Data.EF
{
    public static class ServicesCollectionExtensions
    {
        public static IServiceCollection AddEFRepository(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<StoreDBContext>(
                options =>
                {
                    options.UseSqlServer(connectionString);
                },
                ServiceLifetime.Transient
                );
            services.AddScoped<Dictionary<Type, StoreDBContext>>();
            services.AddSingleton<DbContextFactory>();
            services.AddSingleton<IBookRepository, BookRepository>();
            services.AddSingleton<IOrderRepository, OrderRepository>();
             
            return services;
        }
    }
}
