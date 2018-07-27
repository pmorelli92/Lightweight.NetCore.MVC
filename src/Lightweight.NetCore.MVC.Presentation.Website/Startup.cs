using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.IO.Compression;
using Lightweight.NetCore.MVC.Presentation.Website.Extensions;
using WebMarkupMin.AspNet.Common.Compressors;
using WebMarkupMin.AspNetCore2;

namespace Lightweight.NetCore.MVC.Presentation.Website
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        private readonly IHostingEnvironment _environment;

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .AddEnvironmentVariablesSafe();

            _environment = env;
            _configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddWebMarkupMin(opt => opt.AllowCompressionInDevelopmentEnvironment = true)
                .AddXmlMinification()
                .AddHtmlMinification()
                .AddHttpCompression(options =>
                    options.CompressorFactories = new ICompressorFactory[] {
                        new GZipCompressorFactory(new GZipCompressionSettings { Level = CompressionLevel.Fastest })
                    }
                );

            // Development SSL
            // TODO: Set logic for production since this will only use dev certificate
            if (_environment.IsDevelopment() || _environment.IsStaging())
                services.Configure<MvcOptions>(opt => opt.Filters.Add(new RequireHttpsAttribute()));
            
            services.AddAntiforgery();
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app)
        {
            if (_environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStaticFilesInCurrentDirFolder("node_modules");
            }

            app.UseStaticFiles();
            app.UseWebMarkupMin();
            app.UseMvc(routeBuilder => Routing.ConfigureRoutes(routeBuilder));
        }
    }
}