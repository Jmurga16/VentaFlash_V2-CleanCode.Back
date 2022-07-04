using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Oferton.Entities.Interfaces;
using Oferton.Repositories.EFCore.DataContext;
using Oferton.Repositories.EFCore.Repositories;
using Oferton.UseCases.CreateOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oferton.IoC
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddOfertonServices(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<OfertonContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DB_Oferton_V2")));

            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddMediatR(typeof(CreateOrderInteractor));


            return services;
        }


    }
}
