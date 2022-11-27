
using NLog;
using NLog.Web;
using SwitchAcademy;

var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("init main");

try
{
    var builder = WebApplication.CreateBuilder(args)
        .RegisterServices();


    builder.Logging.ClearProviders();
    builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
    builder.Logging.AddConsole();
    builder.Logging.AddDebug();
    builder.Logging.AddEventSourceLogger();
    builder.Host.UseNLog();

    // Add services to the container.

    //builder.Services.AddControllers();
    //// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    //builder.Services.AddEndpointsApiExplorer();
    //builder.Services.AddSwaggerGen();
    var app = builder.Build();

    //Create 
    using var scope = app.Services.CreateScope();
    //var dbInitializer = scope.ServiceProvider.GetRequiredService<IDbInitializer>();

    //app.SetUpMiddleware(dbInitializer).Run();
    app.SetUpMiddleware().Run();


}
catch (Exception exception)
{
    logger.Error(exception, "Stopped program because of exception");
    throw;
}
finally
{
    NLog.LogManager.Shutdown();
}

