using Infrastructure.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces;
using AutoMapper;
using API.Helpers;
using API.Middleware;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using API.Errors;
using Microsoft.OpenApi.Models;
using API.Extensions;
using StackExchange.Redis;
using Infrastructure.Identity;

namespace API
{
    public class Startup
    {
        // Specific lecturer preferences?  readonly _config?

        // Private fields get underscores as convention
        private readonly IConfiguration _config;

        // keys and values - database?
        public Startup(IConfiguration config)
        {
            _config = config;
        }

        //  Commented out below line when _config was instantiated and private readonly
        //public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // "Dependency injection container"
        public void ConfigureServices(IServiceCollection services)
        {   
            // ordering of how things fire in here doesn't really matter
            
            services.AddAutoMapper(typeof(MappingProfiles));
            services.AddControllers();
            services.AddDbContext<StoreContext>(x => x.UseSqlite(_config.GetConnectionString("DefaultConnection")));
            
            services.AddDbContext<AppIdentityDbContext>(x => {
                x.UseSqlite(_config.GetConnectionString("IdentityConnection"));
            });
            
            services.AddSingleton<IConnectionMultiplexer>(c => {
                var configuration = ConfigurationOptions.Parse(_config.GetConnectionString("Redis"), true);
                return ConnectionMultiplexer.Connect(configuration);
            });

            services.AddApplicationServices();
            services.AddIdentityServices(_config);
            services.AddSwaggerDocumentation();
            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200");
                });
            });
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        // "This is where we add Middleware" Lecture 2.8
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<ExceptionMiddleware>();

            app.UseStatusCodePagesWithReExecute("/errors/{0}");

            app.UseHttpsRedirection();

            app.UseRouting();
            // Ordering of middleware is IMPORTANT  - Adding use of static files here
            // wwwroot folder will eventually hold angular project
            // UseStaticFiles hosts image files in wwwroot
            app.UseStaticFiles();

            app.UseCors("CorsPolicy");

            app.UseAuthentication();
            app.UseAuthorization();

            // Swagger middleware extensions were moved to SwaggerServiceExtensions.cs

            app.UseSwaggerDocumentation();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
