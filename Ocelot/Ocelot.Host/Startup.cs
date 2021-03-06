﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NLog;
using NLog.Extensions.Logging;
using NLog.Web;
using Ocelot.Core.LogProvide;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Provider.Consul;
using LogLevel = Microsoft.Extensions.Logging.LogLevel;

namespace Ocelot.Host
{
    public class Startup
    {
        private readonly IConfigurationRoot _appConfiguration;
        private readonly IHostingEnvironment _env;
        public Startup(IHostingEnvironment env)
        {
            _env = env;

            //_env.ConfigureNLog("Nlog.config");

 
            _appConfiguration = _env.GetAppConfiguration();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddOcelot(_env.GetAppConfiguration())
                .AddConsul();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            // loggerFactory.AddNLog();

            // LogManager.GetCurrentClassLogger().Error("sdsdsdsd");

            //loggerFactory.AddProvider(new ShawnLoggerProvider(new ShanwLoggerConfig
            //{
            //    Color = ConsoleColor.Blue,
            //    LogLevel = LogLevel.Information
            //}));

            

            app.UseHttpsRedirection();
            app.UseOcelot().Wait();
            app.UseMvc();
        }
    }
}
