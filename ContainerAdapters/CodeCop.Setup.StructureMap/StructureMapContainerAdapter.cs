using System.Collections.Generic;
using CodeCop.Setup.Contracts;

namespace CodeCop.Setup.StructureMap
{
    /// <summary>
    /// CodeCop IoC Container adapter for StructureMap.
    /// </summary>
    public class StructureMapContainerAdapter : IContainer
    {
        private readonly global::StructureMap.IContainer container;

        public StructureMapContainerAdapter(global::StructureMap.IContainer container)
        {
            this.container = container;
        }

        public TService Resolve<TService>()
        {
            return this.container.GetInstance<TService>();
        }

        public IEnumerable<TService> ResolveAll<TService>()
        {
            return this.container.GetAllInstances<TService>();
        }

        public void Register<TService>(TService service)
        {
            this.container.Configure(c =>
            {
                c.AddType(typeof(TService), service.GetType());
            });
        }
    }
}