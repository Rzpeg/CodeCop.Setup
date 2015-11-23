using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using IContainer = CodeCop.Setup.Contracts.IContainer;

namespace CodeCop.Setup.Autofac
{
    /// <summary>
    /// CodeCop IoC Container adapter for Autofac.
    /// </summary>
    public class AutofacContainerAdapter : IContainer
    {
        private readonly global::Autofac.IContainer container;

        public AutofacContainerAdapter(global::Autofac.IContainer container)
        {
            this.container = container;
        }

        public TService Resolve<TService>()
        {
            return this.container.Resolve<TService>();
        }

        public IEnumerable<TService> ResolveAll<TService>()
        {
            return this.container.Resolve<IEnumerable<TService>>();
        }

       public void Register<TService>(TService service)
        {
            var builder = new ContainerBuilder();

            builder
                .RegisterType(service.GetType())
                .As<TService>();

            builder.Update(this.container);
        }

        public IEnumerable<object> ResolveAll(Type service)
        {
            var collectionType = typeof (IEnumerable<>).MakeGenericType(service);
            var instances = this.container.Resolve(collectionType);
            return ((IEnumerable<object>) instances) ?? Enumerable.Empty<object>();
        }
    }
}