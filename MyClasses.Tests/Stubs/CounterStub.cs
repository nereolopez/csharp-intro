namespace MyClasses.Tests.Stubs
{
    class CounterStub : ICounter
    {
        private int count = 1234;
        public int Count => this.count;

        public void IncrementCount() { }
    }
}
