using System;
using System.Collections;
using System.Collections.Generic;

namespace CodeCop.Setup.Contracts
{
    /// <summary>
    /// IoC container contract.
    /// </summary>
    public interface IContainer
    {
        /// <summary>
        /// Resolves the service of the given type.
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <returns>Requested service implementation.</returns>
        TService Resolve<TService>();

        /// <summary>
        /// Resolves all the services of the given type.
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <returns>IEnumerable&lt;TService&gt;. containing all registered implementation of the requested service.</returns>
        IEnumerable<TService> ResolveAll<TService>();

        /// <summary>
        /// Registers the specified service as implemented interfaces.
        /// </summary>
        /// <param name="service">The requested service(s) implementation.</param>
        void Register(object service);

        /// <summary>
        /// Resolves all the services of the given type.
        /// </summary>
        /// <param name="service">The type.</param>
        /// <returns>IEnumerable&lt;System.Object&gt; containing all registered implementation of the requested service.</returns>
        IEnumerable<object> ResolveAll(Type service);
    }
}