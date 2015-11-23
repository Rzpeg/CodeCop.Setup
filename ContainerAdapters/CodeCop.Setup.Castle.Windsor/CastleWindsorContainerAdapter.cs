using System.Collections.Generic;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using CodeCop.Setup.Contracts;

namespace CodeCop.Setup.Castle.Windsor
{
    /// <summary>
    /// CodeCop IoC Container adapter for Castle Windsor.
    /// </summary>
    public class CastleWindsorContainerAdapter : IContainer
    {
        private readonly IWindsorContainer container;

        public CastleWindsorContainerAdapter(global::Castle.Windsor.IWindsorContainer container)
        {
            this.container = container;
        }

        public TService Resolve<TService>()
        {
            return this.container.Resolve<TService>();
        }

        public IEnumerable<TService> ResolveAll<TService>()
        {
            return this.container.ResolveAll<TService>();
        }

        public void Register<TService>(TService service)
        {
            this.container.Register(
                Component.For(typeof (TService)).ImplementedBy(service.GetType())
                );
        }
    }
}