﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EveryBodyCodes.Configurations;
using EveryBodyCodes.DataAccess;
using EveryBodyCodes.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace EveryBodyCodes
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
            services.AddMvc();

            services.Configure<CameraConfiguration>(Configuration.GetSection("Camera"));
            services.AddSwaggerGen();

            services.AddScoped<ICameraDataAccess, CameraCSVDataAccess>();
            services.AddScoped<ICameraService, CameraService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Camera API");
                c.RoutePrefix = string.Empty;
            });

            app.UseMvc();
        }
    }
}
