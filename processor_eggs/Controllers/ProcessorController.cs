[ApiController]
[EnableRateLimiting("concurrency")]
public class ProcessorController : Controller
{
    [Topic("orderpubsub", "eggs")]
    [HttpPost("orders")]
    public async Task<IActionResult> processOrder(Order order) 
    {
  
        Console.WriteLine("Eggs order received : " + order);

        await Task.Delay(TimeSpan.FromSeconds(1));

        using var client = new DaprClientBuilder().Build();
        await client.PublishEventAsync("orderpubsub", "eggs_ready", order);

        Console.WriteLine("Eggs done: " + order);

        return Ok();
    }

}

