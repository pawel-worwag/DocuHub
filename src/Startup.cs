using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DocuHub.DAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace DocuHub
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<KestrelServerOptions>(Configuration.GetSection("Kestrel"));
            services.AddMvc(options => {
                options.EnableEndpointRouting = false;
            });

            string connectionString = Configuration.GetValue<string>("Database:ConnectionString");
            int major = Configuration.GetValue<int>("Database:DbVersion:Major");
            int minor = Configuration.GetValue<int>("Database:DbVersion:Minor");
            int build = Configuration.GetValue<int>("Database:DbVersion:Build");
            ServerType type = Configuration.GetValue<ServerType>("Database:DbType");
            services.AddDbContextPool<DocuHubDbContext>(options => options
                .UseMySql(connectionString,
                     mySqlOptions => mySqlOptions
                     .ServerVersion(new Version(major, minor, build), type)));

            services.AddScoped<IRingBindersRepository,RingBindersRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseMvc();
        }
    }
}
