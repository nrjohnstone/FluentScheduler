namespace FluentScheduler.SimpleInjector.Tests
{
    public class DependencyB : IDependencyB
    {
        private readonly IDependencyA _depA;

        public DependencyB(IDependencyA depA)
        {
            _depA = depA;
        }
        public void DoWork()
        {
            _depA.DoWork();
        }
    }
}