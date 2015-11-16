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
            return this.implementations[typeof (TService)].Cast<TService>();
        }

        public void Register<TService>(TService service)
        {
            if (!this.implementations.ContainsKey(typeof(TService)))
                this.implementations[typeof (TService)] = new List<dynamic>();

            this.implementations[typeof (TService)].Add(service);
        }
    }
}