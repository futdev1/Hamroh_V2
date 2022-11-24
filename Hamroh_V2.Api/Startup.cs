using Hamroh_V2.Data.Contexts;
using Hamroh_V2.Data.IRepositories;
using Hamroh_V2.Data.Repositories;
using Hamroh_V2.Service.Helpers;
using Hamroh_V2.Service.Interfaces;
using Hamroh_V2.Service.Mappers;
using Hamroh_V2.Service.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Hamroh_V2.Api
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

            services.AddDbContext<Hamroh_V2DbContext>(p =>
            {
                p.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));
            });
            //second label for clientRepository
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Hamroh_V2.Api", Version = "v1" });
            });

            services.AddControllers().AddNewtonsoftJson();
            services.AddHttpContextAccessor();

            services.AddAutoMapper(typeof(MappingProfile));

            #region registration of services and repositories

            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IClientRepository, ClientRepository>();

            services.AddScoped<IDriverAdService, DriverAdService>();
            services.AddScoped<IDriverAdRepository, DriverAdRepository>();

            services.AddScoped<IDriverService, DriverService>();
            services.AddScoped<IDriverRepository, DriverRepository>();

            services.AddScoped<IClientAdService, ClientAdService>();
            services.AddScoped<IClientAdRepository, ClientAdRepository>();
            #endregion
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment() || env.IsProduction())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Hamroh_V2.Api v1"));
            }

            if (app.ApplicationServices.GetService<IHttpContextAccessor>() != null)
            {
                HttpContextHelper.Accessor = app.ApplicationServices.GetRequiredService<IHttpContextAccessor>();
            }


            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
