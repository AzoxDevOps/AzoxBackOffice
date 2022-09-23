namespace Azox.XQR.Presentation
{
    using Azox.Core.Extensions;
    using Azox.XQR.Presentation.Middlewares;
    using Azox.XQR.Presentation.Services;

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

        private static void ConfigureServices(WebApplicationBuilder builder)
        {
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor()
                .AddCircuitOptions(options => options.DetailedErrors = true);

            builder.Services.AddMemoryCache();

            builder.Services.RegisterConfigs(builder.Configuration);
            builder.Services.RegisterServices(builder.Configuration);

            builder.Services.AddSingleton<InstallationService>();
        }

        private static void ConfigurePipelines(WebApplication app)
        {
            if (!app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseMiddleware<InstallationMiddleware>();

            app.UseRouting();
            app.MapRazorPages();
            app.MapBlazorHub();
            app.MapFallbackToAreaPage("~/Admin/{*catchall}", "/_AdminHost", "Admin");
            app.MapFallbackToPage("/_Host");

        }
    }
}
