namespace delivery
{
    public static class HandleOrder
    {
        public static void OrderReady(OrderStatus os)
        {
            if (os.IsReady)
            {
                var om = OrderList.OrderPerformance();
                Console.WriteLine($"---------------------> Order {os.SeqNr} ({os.Guid}) is ready in {os.Duration} seconds. " +
                    $"Pending orders: {om.Count}," +
                    $"Max waiting: {om.MaxWaiting} seconds");
            }
        }
    }
}
