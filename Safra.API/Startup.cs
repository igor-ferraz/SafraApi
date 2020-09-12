using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Safra.API.Filters;
using Safra.Application.Services;
using Safra.Domain.Repositories;
using Safra.Domain.ApplicationServices;
using Safra.Infrastructure.Repositories;
using Safra.Domain.InfrastructureServices;
using Safra.Infrastructure.Services;

namespace Safra.API
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
            const string connectionString = "Data Source=localhost; Initial Catalog=Safra; Integrated Security=True;";

            services.AddControllers();
            services.AddScoped<AuthFilter>();
            services.AddScoped<IProductRepository, ProductRepository>(_ => new ProductRepository(connectionString));
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IHttpService, HttpService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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
