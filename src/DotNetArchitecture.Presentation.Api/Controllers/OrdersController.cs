using DotNetArchitecture.Presentation.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNetArchitecture.Presentation.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class OrdersController(ILogger<OrdersController> logger) : ControllerBase
{
    [HttpGet(Name = "GetOrders")]
    public IEnumerable<Order> Get()
    {
        return Enumerable
            .Range(1, 5)
            .Select(index => new Order { Id = index })
            .ToArray();
    }
}