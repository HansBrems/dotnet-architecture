using Microsoft.AspNetCore.SignalR;

namespace DotNetArchitecture.Presentation.Api.Hubs;

public class ProductHub(ILogger<ProductHub> logger) : Hub
{
    public override Task OnConnectedAsync()
    {
        logger.LogInformation("Client connected");
        return Task.CompletedTask;
    }
    
    public override Task OnDisconnectedAsync(Exception? exception)
    {
        logger.LogInformation("Client disconnected");
        return Task.CompletedTask;
    }
}