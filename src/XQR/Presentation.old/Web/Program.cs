namespace Azox.XQR.Presentation.Web
{
    using Azox.Core.Extensions;
    using Azox.XQR.Presentation.Core.Middlewares;

    using Microsoft.Extensions.FileProviders;

    class Program
    {
        static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
            ConfigureServices(builder);
            WebApplication app = builder.Build();
            ConfigurePipelines(app);
            app.Run();
        }

        static void ConfigureServices(WebApplicationBuilder builder)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();

            builder.Services.AddMemoryCache();

            builder.Services.RegisterConfigs(builder.Configuration);
            builder.Services.RegisterServices(builder.Configuration);

            if (!builder.Environment.IsDevelopment())
            {
                builder.WebHost.UseStaticWebAssets();
            }
        }

        static void ConfigurePipelines(WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMiddleware<InstallationMiddleware>();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            StaticFileOptions themeStaticFileOptions = new();
            themeStaticFileOptions.FileProvider = new PhysicalFileProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "wwwroot"));
            themeStaticFileOptions.RequestPath = "/_themes";

            app.UseStaticFiles(themeStaticFileOptions);

            app.UseRouting();
            app.UseAuthorization();
            app.UseAuthentication();
            app.MapBlazorHub();
            app.MapFallbackToAreaPage("~/Admin/{*catchall}", "/_AdminHost", "Admin");
            app.MapFallbackToPage("/_Host");
        }
    }
}