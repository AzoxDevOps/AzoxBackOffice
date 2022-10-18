namespace Azox.XQR.Presentation.Web
{
    using Azox.Core.Extensions;
    using Azox.XQR.Presentation.Core.Middlewares;
    using Azox.XQR.Presentation.Web.Areas.Admin.Sitemap;

    using Microsoft.Extensions.FileProviders;
    using Serilog;
    using Serilog.Events;
    using System.Text;

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
            var logger = new LoggerConfiguration()
           .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
           .Enrich.FromLogContext()
           .WriteTo.Console()
           .WriteTo.File(
               path: Path.Combine(AppContext.BaseDirectory, "LogFiles", "XQRPresentationWeb.txt"),
               outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss.fff} {CorrelationId} {Level:u3}] {Username} {Message:lj}{NewLine}{Exception}",
               shared: true,
               rollingInterval: RollingInterval.Day,
               encoding: Encoding.UTF8)
           .CreateLogger();

            builder.Logging.ClearProviders();
            builder.Logging.AddSerilog(logger);

            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();

            builder.Services.AddMemoryCache();

            builder.Services.RegisterConfigs(builder.Configuration);
            builder.Services.RegisterServices(builder.Configuration);

            builder.Services.AddSingleton<MenuItemService>();
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
            app.UseRouting();
            app.UseAuthorization();
            app.UseAuthentication();
            app.MapBlazorHub();
            app.MapFallbackToAreaPage("~/Admin/{*catchall}", "/_AdminHost", "Admin");
            app.MapFallbackToPage("/_Host");
        }
    }
}