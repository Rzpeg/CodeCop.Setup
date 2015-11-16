using CodeCop.Core;
using CodeCop.Setup.Contracts;

namespace CodeCop.Setup.Infrastructure
{
    /// <summary>
    /// This type signalizes that the configuration has been completed and is ready to be applied to <see cref="CodeCop"/>.
    /// </summary>
    public class CopConfiguration
    {
        private readonly IContainer container;

        internal CopConfiguration(IContainer container)
        {
            this.container = container;
        }

        /// <summary>
        /// Activates the interceptor.
        /// </summary>
        public void Activate()
        {
            Cop.AsFluent();
            Cop.Intercept();
        }
    }
}