using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Oferton.Entities.Exceptions;
using Oferton.IoC;
using Oferton.Repositories.EFCore.DataContext;
using Oferton.WebExceptionsPresenter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oferton.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers(options =>
            options.Filters.Add(new ApiExceptionFilterAttribute(
                new Dictionary<Type, IExceptionHandler>
                {
                    {typeof(GeneralException), new GeneralExceptionHandler()},
                    {typeof(ValidationException), new ValidationExceptionHandler() }
                    }
                )));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Oferton.WebApi", Version = "v1" });
            });

            services.AddOfertonServices(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, OfertonContext ofertonContext)
        {
            if (env.IsDevelopment())
            {
                app.UseCors(options =>
                {
                    options.WithOrigins("http://localhost:4200", "http://localhost:4500");
                    options.AllowAnyMethod();
                    options.AllowAnyHeader();
                });

                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "OfertonAPI v1"));
                
                if (ofertonContext.Database.GetPendingMigrations().Count() > 0)
                {
                    ofertonContext.Database.Migrate();
                }

            }
            else
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "OfertonAPI v2");
                    c.RoutePrefix = string.Empty;
                });

                app.UseCors(options =>
                {
                    options.WithOrigins("https://oferton-ic.azurewebsites.net");
                    options.AllowAnyMethod();
                    options.AllowAnyHeader();
                });
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
