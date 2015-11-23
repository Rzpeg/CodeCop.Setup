using System.Collections.Generic;
using System.Linq;
using CodeCop.Setup.Contracts;
using Microsoft.Practices.Unity;

namespace CodeCop.Setup.Unity
{
    /// <summary>
    /// CCodeCop IoC Container adapter for Unity.
    /// </summary>
    public class UnityContainerAdapter : IContainer
    {
        private readonly IUnityContainer container;

        public UnityContainerAdapter(global::Microsoft.Practices.Unity.IUnityContainer container)
        {
            this.container = container;
        }

        public TService Resolve<TService>()
        {
            return this.container.Resolve<TService>();
        }

        public IEnumerable<TService> ResolveAll<TService>()
        {
            var namedInstances = this.container.ResolveAll<TService>();
            var defaultInstance = this.container.Resolve<TService>();

            return namedInstances.Union(new List<TService>() { defaultInstance });
        }

        public void Register<TService>(TService service)
        {
            this.container.RegisterType(typeof (TService), service.GetType());
        }
    }
}