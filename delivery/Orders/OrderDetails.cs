namespace delivery
{
    public class OrderDetails
    {
        public Order Order { get; set; }
        public bool Eggs { get; set; }
        public bool Bacon { get; set; }
        public bool Toast { get; set; }

        public int Duration { get; set; }

        public OrderDetails(Order order) {
            Order = order;
            Eggs = false;  
            Bacon = false; 
            Toast = false;
        }

    }
}
