namespace DotNetArchitecture.Presentation.Api.Bootstrapping;

public static class CorsSetup
{
    public static IServiceCollection AddCorsSetup(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("WebUI", builder =>
            {
                builder
                    .WithOrigins("http://localhost:4200")
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });
        });

        return services;
    }

    public static void UseCorsSetup(this IApplicationBuilder app)
    {
        app.UseCors("WebUI");
    }
}