[ApiController]
[EnableRateLimiting("concurrency")]
public class ProcessorController : Controller
{
    [Topic("orderpubsub", "toast")]
    [HttpPost("orders")]
    public async Task<IActionResult> processOrder(Order order) 
    {
  
        Console.WriteLine("Toast order received : " + order);

        await Task.Delay(TimeSpan.FromSeconds(1));

        using var client = new DaprClientBuilder().Build();
        await client.PublishEventAsync("orderpubsub", "toast_ready", order);

        Console.WriteLine("Toast done: " + order);

        return Ok();
    }

}

