namespace DotNetArchitecture.Presentation.Api.Messaging;

public class TestCommandHandler(ILogger<TestCommandHandler> logger) : IHandleMessages<TestCommand>
{
    public async Task Handle(TestCommand message, IMessageHandlerContext context)
    {
        await Task.Delay(1000, context.CancellationToken);
        logger.LogInformation("Message received!");
    }
}