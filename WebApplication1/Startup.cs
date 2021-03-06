using System;
using System.IO.Compression;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SnapObjects.Data;
using SnapObjects.Data.SqlServer;
using SnapObjects.Data.AspNetCore;
using DWNet.Data.AspNetCore;

namespace WebApplication1
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
            services.AddControllers(m =>
            {
                m.UseCoreIntegrated();
                m.UsePowerBuilderIntegrated();
            });

            // Uncomment the following line to connect to the SQL server database.
            // Note: Replace "ContextName" with the configured context name; replace "key" with the database connection name that exists in appsettings.json. The sample code is as follows:
            // services.AddDataContext<ContextName>(m => m.UseSqlServer(Configuration["ConnectionStrings:key"]));

            // Uncomment the following line to connect to the Oracle database.
            // Note: Replace "ContextName" with the configured context name; replace "key" with the database connection name that exists in appsettings.json. The sample code is as follows:
            // services.AddDataContext<ContextName>(m => m.UseOracle(Configuration["ConnectionStrings:key"]));

            // Uncomment the following line to connect to the PostGreSql database.
            // Note: Replace "ContextName" with the configured context name; replace "key" with the database connection name that exists in appsettings.json. The sample code is as follows:
            // services.AddDataContext<ContextName>(m => m.UsePostgreSql(Configuration["ConnectionStrings:key"]));

            // Uncomment the following line to connect to the ODBC database.
            // Note: Replace "ContextName" with the configured context name; replace "key" with the database connection name that exists in appsettings.json. The sample code is as follows:
            // services.AddDataContext<ContextName>(m => m.UseOdbc(Configuration["ConnectionStrings:key"]));

            services.AddGzipCompression(CompressionLevel.Fastest);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
			if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

			// Adds middleware for redirecting HTTP Requests to HTTPS.
            // app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
			
            app.UseResponseCompression();

            app.UseDataWindow();
        }
    }
}