namespace FluentScheduler
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// A job factory.
    /// </summary>
    public interface IJobFactory
    {
        /// <summary>
        /// Return a scoped job factory for lifecycle management of dependencies
        /// </summary>
        IScopedJobFactory GetScope();
    }

    /// <summary>
    /// A scoped job factory that is able to manage the lifecycle
    /// requirements of any instances created and is disposed of once a job
    /// has executed
    /// </summary>
    public interface IScopedJobFactory : IDisposable
    {
        /// <summary>
        /// Instantiate a job of the given type.
        /// </summary>
        /// <typeparam name="T">Type of the job to instantiate</typeparam>
        /// <returns>The instantiated job</returns>
        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter",
            Justification = "The 'T' requirement is on purpose.")]
        IJob GetJobInstance<T>() where T : IJob;
    }

    internal class JobFactory : IJobFactory, IScopedJobFactory
    {
        IJob IScopedJobFactory.GetJobInstance<T>()
        {
            return Activator.CreateInstance<T>();
        }

        public IScopedJobFactory GetScope()
        {
            return new JobFactory();
        }

        public void Dispose()
        {
        }
    }
}
