using AirportWebApi.BL.Services;
using AirportWebApi.DAL;
using AirportWebApi.DAL.Models;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Shared.Configs;

namespace AirportWebApi
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {

            var builder = new ConfigurationBuilder()
                   .SetBasePath(env.ContentRootPath)
                   .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                   .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<AirportContext>(options =>
                         options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            var config = new AutoMapperConfiguration().Configure().CreateMapper();
            services.AddSingleton(sp => config);

            services.AddScoped<IUow, Uow>();
            services.AddScoped<BaseService>();
            services.AddMvc().AddFluentValidation();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            app.UseCors(builder =>
            builder.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod().AllowCredentials().AllowAnyOrigin().SetIsOriginAllowedToAllowWildcardSubdomains());

            app.UseMvc();
        }
    }
}
