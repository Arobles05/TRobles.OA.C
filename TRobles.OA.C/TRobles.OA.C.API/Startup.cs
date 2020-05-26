using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TRobles.OA.C.API.Helpers;
using TRobles.OA.C.API.MiddleWare;
using TRobles.OA.C.Repository;

namespace TRobles.OA.C.API
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
            // services.AddControllersWithViews();
            services.AddCors();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddControllers().AddControllersAsServices();

            var appSettingsSection = Configuration.GetSection("AppSettings");
            var connectionStrings = Configuration.GetSection("ConnectionStrings");

            services.Configure<AppSettings>(appSettingsSection);
            services.Configure<ConnectionString>(connectionStrings);

            var appSettings = appSettingsSection.Get<AppSettings>();
            var connections = connectionStrings.Get<ConnectionString>();


            var conexion = connectionStrings.Get<ConnectionString>();
            var secrect = appSettings.Secret;

            services.AddDbContext<ApplicationContext>(options =>
            {
                var connection = new SqlConnection(connections.DefaultConnection);

                options.UseSqlServer(connection);
            });

            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(conexion.DefaultConnection));

            //Inyeccion de los servicion con el contenedor
            IoCContaner.AddDependency(services);
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
