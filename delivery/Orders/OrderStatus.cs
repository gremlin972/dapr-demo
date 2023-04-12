namespace delivery
{
    public class OrderStatus
    {
        public Guid? Guid { get; set; }
        public int SeqNr { get; set; }
        public bool IsReady { get; set; }

        public int Duration { get; set; }
    }
}
