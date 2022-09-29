using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Register.Data;
using System.Configuration;

namespace Register
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<RegisterContext>(options =>
    options.UseSqlServer(Configuration.GetConnectionString("RegisterContext") ?? throw new InvalidOperationException("Connection string 'RegisterContext' not found.")));
            services.AddControllers();

            // services.AddScoped<IStockRepository, StockRepository>();

            //services.AddScoped<IStockProvider, StockProvider>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My Stock API", Version = "v1" });
            });

        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Stock API V1"); });

            

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }



    }
}



