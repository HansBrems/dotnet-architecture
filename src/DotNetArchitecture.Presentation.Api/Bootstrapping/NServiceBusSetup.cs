using DotNetArchitecture.Presentation.Api.Messaging;

namespace DotNetArchitecture.Presentation.Api.Bootstrapping;

public static class NServiceBusSetup
{
    public static void UseNServiceBusSetup(this WebApplicationBuilder builder)
    {
        var endpointConfiguration = new EndpointConfiguration("DotNetArchitecture.Presentation.Api");
        endpointConfiguration.UseSerialization<SystemJsonSerializer>();
        endpointConfiguration.EnableInstallers();
        
        var transport = endpointConfiguration.UseTransport<RabbitMQTransport>();
        transport.UseConventionalRoutingTopology(QueueType.Quorum);
        transport.ConnectionString("host=localhost");
        transport.Routing().RouteToEndpoint(
            messageType: typeof(TestCommand),
            destination: "DotNetArchitecture.Presentation.Api");
        
        // endpointConfiguration.SendOnly();

        builder.UseNServiceBus(endpointConfiguration);
    }
}