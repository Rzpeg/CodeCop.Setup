using System.Collections.Generic;
using CodeCop.Setup.Contracts;
using Ninject;

namespace CodeCop.Setup.Ninject
{
    /// <summary>
    /// CodeCop IoC Container adapter for Ninject.
    /// </summary>
    public class NinjectContainerAdapter : IContainer
    {
        private readonly IKernel kernel;

        public NinjectContainerAdapter(global::Ninject.IKernel kernel)
        {
            this.kernel = kernel;
        }

        public TService Resolve<TService>()
        {
            return this.kernel.Get<TService>();
        }

        public IEnumerable<TService> ResolveAll<TService>()
        {
            return this.kernel.GetAll<TService>();
        }

        public void Register<TService>(TService service)
        {
            this.kernel.Bind<TService>().To(service.GetType());
        }
    }
}