using System.Threading;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using Xunit;

namespace FluentScheduler.SimpleInjector.Tests
{
    public class SimpleInjectorTests
    {
        [Fact]
        public void Run()
        {
            Container container = new Container();
            SingletonCounter counter = new SingletonCounter();

            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            // Simulate a "per request" dependency,
            // that is we want the same instance of for
            // the entire object graph of the IJob
            container.Register<IDependencyA, DependencyA>(Lifestyle.Scoped);

            // Normal transient dependency that uses DependencyA 
            container.Register<IDependencyB, DependencyB>();

            // MyJob is transient and uses DependencyA directly as well
            // as DependencyB
            container.Register<MyJob>();

            container.RegisterInstance(counter);

            JobManager.Initialize();
            JobManager.JobFactory = new JobFactorySimpleInjector(container);

            JobManager.AddJob<MyJob>(schedule => schedule.ToRunNow());

            // act
            JobManager.Start();

            while (counter.Value == 0)
            {
                Thread.Sleep(20);
            }

            // assert

            // Counter should only have been incremented once
            Assert.Equal(1, counter.Value);
        }
    }
}