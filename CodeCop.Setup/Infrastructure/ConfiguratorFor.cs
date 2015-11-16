using System;
using CodeCop.Setup.Contracts;

namespace CodeCop.Setup.Infrastructure
{
    /// <summary>
    /// Generic configurator.
    /// </summary>
    /// <typeparam name="TService">The type of the t service.</typeparam>
    public class ConfiguratorFor<TService>
    {
        private readonly IContainer container;

        internal ConfiguratorFor(IContainer container)
        {
            this.container = container;
        }

        /// <summary>
        /// Registers the service in IoC container.
        /// </summary>
        /// <param name="factory">The service factory method.</param>
        public void Register(Func<TService> factory)
        {
            this.container.Register(factory());
        }
    }
}