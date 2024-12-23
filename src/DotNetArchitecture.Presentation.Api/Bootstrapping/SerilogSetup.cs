using Serilog;

namespace DotNetArchitecture.Presentation.Api.Bootstrapping;

public static class SerilogSetup
{
    public static IServiceCollection AddSerilogSetup(this IServiceCollection services,
        ConfigurationManager configuration)
    {
        services.AddSerilog((s, lc) => lc
            .ReadFrom.Configuration(configuration)
            .ReadFrom.Services(s));

        return services;
    }
}