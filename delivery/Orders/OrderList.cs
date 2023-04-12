using Google.Protobuf.WellKnownTypes;

namespace delivery
{
    public static class OrderList
    {
        private readonly static List<OrderDetails> Items = new();
        public static void RegisterOrder(Order order)
        {
            Items.Add(new OrderDetails(order));
        }

        public static OrderStatus OrderAssemble(Order order, bool? eggs=null, bool? bacon=null, bool? toast=null)
        {
            var od = Items.Find(od => od.Order._Guid.Equals(order._Guid)); 
            if (od == null) return new OrderStatus { IsReady = false};

            var duration = DateTime.Now.Subtract(od.Order._Time);

            od.Eggs = eggs ?? od.Eggs;
            od.Bacon = bacon ?? od.Bacon;
            od.Toast = toast ?? od.Toast;
            od.Duration = od.Eggs && od.Bacon && od.Toast ? duration.Seconds : od.Duration;

            return new OrderStatus { 
                    IsReady = od.Eggs && od.Bacon && od.Toast, 
                    Guid = od.Order._Guid, 
                    SeqNr = od.Order._SeqNr,
                    Duration = od.Duration
            };
        }

        public static OrderMetrics OrderPerformance()
        {
            var cnt = 0;
            var mw = 0;
            foreach (var item in Items)
            {
                cnt += item.Eggs && item.Bacon && item.Toast ? 0 : 1;
                mw = item.Duration > mw ? item.Duration : mw;
            }
            return new OrderMetrics(Count: cnt, MaxWaiting: mw);
        }

    }
}
