using GameCenter.BLL.Services;
using GameCenter.DAL;
using GameCenter.DAL.Entities;
using GameCenter.DAL.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace GameCenter.Web.Configuration
{
    public static class DependencyInjectionExtensions
    {
        [ExcludeFromCodeCoverage]
        public static IServiceCollection AddMyServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<UnitOfWork>();
            services.AddScoped<Context>();

            services.AddScoped<IUserRepository<User>, UserRepository>();
            services.AddScoped<IOrderRepository<Order>, OrderRepository>();
            services.AddScoped<IProductRepository<Product>, ProductRepository>();

            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IUserService, UserService>();


            services.AddAutoMapper(typeof(Startup));

            return services;
        }
    }
}
