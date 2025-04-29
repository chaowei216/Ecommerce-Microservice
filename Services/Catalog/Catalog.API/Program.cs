using Catalog.API.Configurations;
using Serilog;

var builder = WebApplication.CreateBuilder(args);


Log.Information($"Start {builder.Environment.ApplicationName} up");
try
{
    builder.Host.RegisterAppConfigurations();
    
    // Add services or configurations some service app to the container.
    builder.Services.AddInfrastructure(builder.Configuration);

    var app = builder.Build();
    
    app.UseInfrastructure(builder.Environment);
    
    app.Run();
}
catch (Exception ex)
{
    string type = ex.GetType().Name;
    if (type.Equals("StopTheHostException", StringComparison.Ordinal)) throw;

    Log.Fatal(ex, $"Unhandled exception: {ex.Message}");
}
finally
{
    Log.Information($"Shut down {builder.Environment.ApplicationName} complete");
    Log.CloseAndFlush();
}
