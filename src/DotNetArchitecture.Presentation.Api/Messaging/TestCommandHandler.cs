namespace DotNetArchitecture.Presentation.Api.Messaging;

public class TestCommandHandler : IHandleMessages<TestCommand>
{
    public Task Handle(TestCommand message, IMessageHandlerContext context)
    {
        Console.WriteLine("Message received!");
        return Task.CompletedTask;
    }
}