using System;
using SimpleInjector;

namespace FluentScheduler.SimpleInjector
{
    internal class ScopedJobFactorySimpleInjector : IScopedJobFactory
    {
        private readonly Scope _scope;

        public ScopedJobFactorySimpleInjector(Scope scope)
        {
            _scope = scope;
        }

        public void Dispose()
        {
            _scope.Dispose();
        }

        public IJob GetJobInstance<T>() where T : IJob
        {
            // TODO: This interface should also have the constraint of class
            Type t = typeof(T);
            return (IJob) _scope.GetInstance(t);
        }
    }
}