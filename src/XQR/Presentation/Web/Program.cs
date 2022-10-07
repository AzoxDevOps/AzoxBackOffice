namespace Azox.XQR.Presentation.Web
{
    using Azox.Core.Extensions;
    using Azox.XQR.Presentation.Web.Middlewares;

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
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();

            builder.Services.AddMemoryCache();

            builder.Services.RegisterConfigs(builder.Configuration);
            builder.Services.RegisterServices(builder.Configuration);
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