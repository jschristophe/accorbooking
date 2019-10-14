﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccorBooking.Entity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;

namespace AccorBooking_API_HOTEL
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //services.AddDbContext<AccorBookingContext>(options => options.UseSqlServer(configuration.GetConnectionString(nameof(BooksContext))));

            //services.AddDbContext<AccorBookingContext>(options => {
            //    options.UseSqlServer(Configuration.GetConnectionString("AccorCatalogConnectionString"));
            //});

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            var pathBase = "appline-catalog";
            app.UsePathBase($"/{pathBase.TrimStart('/')}");
            if (env.IsDevelopment())    
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            //app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
