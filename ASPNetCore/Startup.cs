using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace aspnetcore
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
            services.AddControllers();
            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<AspNetCore.ApplicationDbContext>(options => options.UseSqlServer(connectionString));
             services.AddMvc(op => op.EnableEndpointRouting = false);
            services.AddCors(options =>
            {
            options.AddPolicy("VueCorsPolicy", builder =>
                {
                builder
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials()
                    .WithOrigins("http://localhost:8080");
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline. IHostingEnvironment env
        public void Configure(IApplicationBuilder app, IWebHostEnvironment  env, AspNetCore.ApplicationDbContext dbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("VueCorsPolicy");

            // app.UseHttpsRedirection();

            // app.UseRouting();

            // app.UseAuthorization();

            // app.UseEndpoints(endpoints =>
            // {
            //     endpoints.MapControllers();
            // });
            dbContext.Database.EnsureCreated();
             app.UseMvc();
        }
    }
}
