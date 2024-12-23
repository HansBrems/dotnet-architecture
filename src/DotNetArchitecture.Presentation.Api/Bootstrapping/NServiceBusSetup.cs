using DotNetArchitecture.Presentation.Api.Messaging;

namespace DotNetArchitecture.Presentation.Api.Bootstrapping;

public static class NServiceBusSetup
{
    public static void UseNServiceBusSetup(this WebApplicationBuilder builder)
    {
        var endpointConfiguration = new EndpointConfiguration("DotNetArchitecture.Presentation.Api");
        var transport = endpointConfiguration.UseTransport(new LearningTransport());
        transport.RouteToEndpoint(
            assembly: typeof(TestCommand).Assembly,
            destination: "DotNetArchitecture.Presentation.Api");

        endpointConfiguration.UseSerialization<SystemJsonSerializer>();
        // endpointConfiguration.SendOnly();

        builder.UseNServiceBus(endpointConfiguration);
    }
}