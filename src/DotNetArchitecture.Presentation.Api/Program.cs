using DotNetArchitecture.Presentation.Api.Bootstrapping;
using DotNetArchitecture.Presentation.Api.Hubs;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

Log.Information("Starting up!");

var builder = WebApplication.CreateBuilder(args);
ConfigureServices(builder.Services, builder.Configuration);

builder.UseNServiceBusSetup();

var webApp = builder.Build();
ConfigureMiddleware(webApp);
webApp.Run();

void ConfigureServices(IServiceCollection services, ConfigurationManager configuration)
{
    services.AddControllers();
    services.AddEndpointsApiExplorer();
    services.AddCors();
    services.AddSignalR();
    services.AddSwaggerGen();
    services.AddSerilogSetup(configuration);
}

void ConfigureMiddleware(WebApplication app)
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    
    app.UseCorsSetup();
    app.UseHttpsRedirection();
    app.UseAuthorization();
    app.MapControllers();
    app.MapHub<ProductHub>("/hubs/products");
}
