
for (int i = 1; i <= 50; i++) {
    var order = new Order(Guid.NewGuid(), i, DateTime.Now);
    using var client = new DaprClientBuilder().Build();

    // Publish an event/message using Dapr PubSub
    await client.PublishEventAsync("orderpubsub", "orders", order);
    await client.PublishEventAsync("orderpubsub", "bacon", order);
    await client.PublishEventAsync("orderpubsub", "eggs", order);
    await client.PublishEventAsync("orderpubsub", "toast", order);
    Console.WriteLine("Published data: " + order);

    await Task.Delay(TimeSpan.FromMilliseconds(200));
}

