using System;
using SimpleInjector;
using SimpleInjector.Lifestyles;

namespace FluentScheduler.SimpleInjector
{
    public class JobFactorySimpleInjector : IJobFactory
    {
        private readonly Container _container;

        public JobFactorySimpleInjector(Container container)
        {
            if (container == null) throw new ArgumentNullException(nameof(container));
            _container = container;
        }
        
        public IScopedJobFactory GetScope()
        {
            var scope = AsyncScopedLifestyle.BeginScope(_container);
            return new ScopedJobFactorySimpleInjector(scope);
        }
    }
}
