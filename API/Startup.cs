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
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped(typeof(IGenericRepository<>), (typeof(GenericRepository<>)));
            services.AddAutoMapper(typeof(MappingProfiles));
            services.AddControllers();
            services.AddDbContext<StoreContext>(x => x.UseSqlite(_config.GetConnectionString("DefaultConnection")));
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        // "This is where we add Middleware" Lecture 2.8
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            // Ordering of middleware is IMPORTANT  - Adding use of static files here
            // wwwroot folder will eventually hold angular project
            app.UseStaticFiles();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
