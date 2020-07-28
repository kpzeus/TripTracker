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
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Swashbuckle.Swagger;
using TripTracker.Service.Data;
using TripTracker.Service.Models;

namespace TripTracker.Service
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
            //services.AddTransient<Repository>();
            
            services.AddMvc();

            services.AddDbContext<TripContext>(options => options.UseSqlite("Data Source=Trip.db"));

            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();

            if (env.IsDevelopment() || env.IsStaging())
            {

                app.UseSwaggerUI(options =>
                        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Trip Tracker v1")
                );

            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            TripContext.SeedData(app.ApplicationServices);

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
