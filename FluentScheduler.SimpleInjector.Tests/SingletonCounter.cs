namespace FluentScheduler.SimpleInjector.Tests
{
    public class SingletonCounter
    {
        public int Value { get; private set; }

        public void Increment()
        {
            Value++;
        }
    }
}