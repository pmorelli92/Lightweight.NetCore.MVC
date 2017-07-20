using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.IO.Compression;
using WebMarkupMin.AspNet.Common.Compressors;
using WebMarkupMin.AspNetCore1;

namespace Lightweight.NetCore.MVC.Presentation.Website
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddWebMarkupMin()
                .AddXmlMinification()
                .AddHtmlMinification()
                .AddHttpCompression(options =>
                    options.CompressorFactories = new[] {
                        new GZipCompressorFactory(new GZipCompressionSettings { Level = CompressionLevel.Fastest })
                    }
                );

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseStaticFiles();
            app.UseWebMarkupMin();
            app.UseMvc(routeBuilder => Routing.ConfigureRoutes(routeBuilder));
        }
    }
}