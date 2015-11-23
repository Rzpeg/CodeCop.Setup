using System;
using System.Collections.Generic;
using System.Linq;
using CodeCop.Setup.Contracts;

namespace CodeCop.Setup.DependencyResolution
{
    internal class InternalContainer : IContainer
    {

        private readonly Dictionary<Type, List<dynamic>> implementations = new Dictionary<Type, List<dynamic>>();

        public TService Resolve<TService>()
        {
            return this.implementations[typeof (TService)].Last();
        }

        public IEnumerable<TService> ResolveAll<TService>()
        {
            if (this.implementations.ContainsKey(typeof(TService)))
                return this.implementations[typeof (TService)].Cast<TService>();

            return Enumerable.Empty<TService>();
        }

        public void Register<TService>(TService service)
        {
            if (!this.implementations.ContainsKey(typeof (TService)))
                this.implementations[typeof (TService)] = new List<dynamic>();

            this.implementations[typeof (TService)].Add(service);
        }

        public IEnumerable<object> ResolveAll(Type service)
        {
            if (this.implementations.ContainsKey(service))
                return this.implementations[service];

            return Enumerable.Empty<object>();
        }
    }
}