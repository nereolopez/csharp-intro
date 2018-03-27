namespace MyClasses
{
    public class Counter : ICounter
    {
        private int counter = 0;

        public int Count => this.counter;

        public void IncrementCount()
        {
            this.counter++;
        }
    }
}
