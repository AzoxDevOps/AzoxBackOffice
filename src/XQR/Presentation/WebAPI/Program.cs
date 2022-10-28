namespace Azox.XQR.Presentation.WebAPI
{
    using Azox.Core.Extensions;

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
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.RegisterConfigs(builder.Configuration);
            builder.Services.RegisterServices(builder.Configuration);
        }

        static void ConfigurePipelines(WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

        }
    }
}