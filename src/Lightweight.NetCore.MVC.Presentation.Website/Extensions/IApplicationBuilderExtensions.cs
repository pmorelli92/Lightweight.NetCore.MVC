using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;

namespace Lightweight.NetCore.MVC.Presentation.Website.Extensions
{
    public static class IApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseStaticFilesInCurrentDirFolder(
            this IApplicationBuilder builder, string folderName)
        {
            return builder.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider($"{Directory.GetCurrentDirectory()}/{folderName}"),
                RequestPath = new PathString($"/{folderName}")
            });
        }
    }
}