namespace MyClasses
{
    public class OrderManager
    {
        ICounter counter;

        public OrderManager(ICounter counter)
        {
            this.counter = counter;
        }

        public int PlaceOrderAndGetOrderNumber()
        {
            // Imagine some actions to process the order

            this.counter.IncrementCount();
            return this.counter.Count;
        }
    }
}
