namespace FluentScheduler.SimpleInjector.Tests
{
    public class MyJob : IJob
    {
        private readonly IDependencyA _depA;
        private readonly IDependencyB _depB;

        public MyJob(IDependencyA depA, IDependencyB depB)
        {
            _depA = depA;
            _depB = depB;
        }

        public void Execute()
        {
            _depA.DoWork();
            _depB.DoWork();
        }
    }
}
