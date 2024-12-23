namespace DotNetArchitecture.Presentation.Api.Messaging;

public class TestCommandHandler : IHandleMessages<TestCommand>
{
    public async Task Handle(TestCommand message, IMessageHandlerContext context)
    {
        Console.WriteLine("Message received!");
        await Task.Delay(2000, context.CancellationToken);
    }
}