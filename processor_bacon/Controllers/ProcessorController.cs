[ApiController]
[EnableRateLimiting("concurrency")]
public class ProcessorController : Controller
{
    [Topic("orderpubsub", "bacon")]
    [HttpPost("orders")]
    public async Task<IActionResult> processOrder(Order order)
    {
  
        Console.WriteLine("Bacon order received : " + order);

        await Task.Delay(TimeSpan.FromMilliseconds(800));

        using var client = new DaprClientBuilder().Build();
        await client.PublishEventAsync("orderpubsub", "bacon_ready", order);

        Console.WriteLine("Bacon done: " + order);

        return Ok();
    }

}

