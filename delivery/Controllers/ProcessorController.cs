using delivery;
using System.Text.Json.Serialization;

[ApiController]
public class ProcessorController : Controller
{
    [Topic("orderpubsub", "orders")]
    [HttpPost("orders")]
    public async Task<IActionResult> ProcessOrder(Order order)  
    {
        OrderList.RegisterOrder(order);
        await Task.Delay(TimeSpan.FromMilliseconds(100));
        Console.WriteLine("Order received : " + order);

        return Ok();
    }

    [Topic("orderpubsub", "eggs_ready")]
    [HttpPost("eggs")]
    public IActionResult EggsReady(Order order) 
    {
        Console.WriteLine("...eggs received : " + order);

        HandleOrder.OrderReady(OrderList.OrderAssemble(order, eggs: true));

        return Ok();
    }

    [Topic("orderpubsub", "bacon_ready")]
    [HttpPost("bacon")]
    public IActionResult BaconReady(Order order)  
    {
        Console.WriteLine("...bacon received : " + order);

        HandleOrder.OrderReady(OrderList.OrderAssemble(order, bacon: true));

        return Ok();
    }

    [Topic("orderpubsub", "toast_ready")]
    [HttpPost("toast")]
    public IActionResult ToastReady(Order order) 
    {
        Console.WriteLine("...toast received : " + order);

        HandleOrder.OrderReady(OrderList.OrderAssemble(order, toast: true));

        return Ok();
    }

    [HttpPost("pending")]
    public IActionResult PendingOrders()
    {
        var cnt = OrderList.OrderPerformance();

        return Ok(cnt);
    }

}

