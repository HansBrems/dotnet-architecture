namespace DotNetArchitecture.Presentation.Api.Bootstrapping;

public static class CorsSetup
{
    private const string WebClientPolicy = "WebClientPolicy";
    
    public static IServiceCollection AddCorsSetup(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy(WebClientPolicy, builder =>
            {
                builder
                    .WithOrigins("http://localhost:4200")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();
            });
        });

        return services;
    }

    public static void UseCorsSetup(this IApplicationBuilder app)
    {
        app.UseCors(WebClientPolicy);
    }
}