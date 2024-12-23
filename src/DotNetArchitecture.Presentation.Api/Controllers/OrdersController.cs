using DotNetArchitecture.Presentation.Api.Messaging;
using DotNetArchitecture.Presentation.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNetArchitecture.Presentation.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class OrdersController(IMessageSession messageSession, ILogger<OrdersController> logger) : ControllerBase
{
    [HttpGet(Name = "GetOrders")]
    public IEnumerable<Order> Get()
    {
        return Enumerable
            .Range(1, 5)
            .Select(index => new Order { Id = index })
            .ToArray();
    }

    [HttpPost(Name = "CreateOrder")]
    public async Task<IActionResult> Create()
    {
        await messageSession.Send(new TestCommand { Id = 5 });
        return Ok();
    }
}