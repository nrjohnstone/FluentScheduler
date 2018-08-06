namespace FluentScheduler.SimpleInjector.Tests
{
    public class DependencyA : IDependencyA
    {
        private readonly SingletonCounter _counter;

        private int _callCount = 0;

        public DependencyA(SingletonCounter counter)
        {
            _counter = counter;
        }

        public void DoWork()
        {
            _callCount++;

            // To demonstrate this has been resolved "per request"
            // we increment the counter only if we have been called twice
            if (_callCount == 2)
            {
                _counter.Increment();
            }
        }
    }
}