using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.FileProviders;

namespace Gui;

public static class Gui
{
    public static void UseGuiDefaultFiles(this WebApplication app, string path)
    {
        app.UseDefaultFiles(new DefaultFilesOptions
        {
            FileProvider = new PhysicalFileProvider(Path.Combine(path, "wwwroot"))
        });
    }

    public static void UseGuiStaticFiles(this WebApplication app, string path)
    {
        app.UseStaticFiles(new StaticFileOptions
        {
            FileProvider = new PhysicalFileProvider(Path.Combine(path, "wwwroot")),
            RequestPath = ""
        });
    }

    public static void UseGuiTypeScriptFiles(this WebApplication app, string path)
    {
        app.UseStaticFiles(new StaticFileOptions
        {
            FileProvider = new PhysicalFileProvider(Path.Combine(path, "scripts")),
            RequestPath = "/scripts"
        });
    }
}