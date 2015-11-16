using System;
using CodeCop.Core;
using CodeCop.Core.Fluent;
using CodeCop.Setup.Contracts;
using CodeCop.Setup.Enums;

namespace CodeCop.Setup.Infrastructure
{
    /// <summary>
    /// Fluent API builder.
    /// </summary>
    public class CopBuilder
    {
        private readonly IContainer container;
        private readonly IMethodFinder methodFinder;

        internal CopBuilder(IContainer container, IMethodFinder methodFinder)
        {
            this.container = container;
            this.methodFinder = methodFinder;
        }

        /// <summary>
        /// Registers a new <see cref="IDataSource"/> containing hooks.
        /// </summary>
        /// <param name="configurator">Service configurator.</param>
        /// <returns><see cref="CopBuilder"/> instance.</returns>
        public CopBuilder ForDataSource(Action<ConfiguratorFor<IDataSource>> configurator)
        {
            configurator(new ConfiguratorFor<IDataSource>(this.container));
            return this;
        }

        /// <summary>
        /// Intercepts the specified method in the provided type.
        /// </summary>
        /// <typeparam name="TClass">Type containing the method to be intercepted.</typeparam>
        /// <param name="methodName">Name of the method.</param>
        /// <param name="interceptOn">Interception position. Use | to specify various interception positions. </param>
        /// <param name="onIntercepted">Function to execute. Return result is used only for <see cref="Intercept.Override"/> position. </param>
        /// <returns><see cref="CopBuilder"/> instance.</returns>
        public CopBuilder InterceptMethodIn<TClass>(
            string methodName, 
            Intercept interceptOn, 
            Func<InterceptionContext, object> onIntercepted)
            where TClass : class
        {
            var method = this.methodFinder.FindIn<TClass>(methodName);

            if (interceptOn.HasFlag(Intercept.Error))
            {
                method.OnError(ctx =>
                {
                    onIntercepted(ctx);
                });
            }

            if (interceptOn.HasFlag(Intercept.Before))
            {
                method.DecorateBefore(ctx =>
                {
                    onIntercepted(ctx);
                });
            }

            if (interceptOn.HasFlag(Intercept.Override))
            {
                method.Override(onIntercepted);
            }

            if (interceptOn.HasFlag(Intercept.After))
            {
                method.DecorateAfter(ctx =>
                {
                    onIntercepted(ctx);
                });
            }

           return this;
        }

        /// <summary>
        /// Intercepts the specified method in the provided type.
        /// </summary>
        /// <typeparam name="TClass">Type containing the method to be intercepted.</typeparam>
        /// <param name="methodName">Name of the method.</param>
        /// <param name="interceptor">Interceptor implementation.</param>
        /// <returns><see cref="CopBuilder"/> instance.</returns>
        public CopBuilder InterceptMethodIn<TClass>(
          string methodName,
          IInterceptor interceptor)
           where TClass : class
        {
            var method = typeof(TClass).GetMethod(methodName);

            method.OnError(interceptor.OnError);

            method.DecorateBefore(interceptor.OnBeforeExecute);
            method.DecorateAfter(interceptor.OnAfterExecute);
            method.Override(interceptor.OnOverride);

            return this;
        }

        /// <summary>
        /// Completes the current configuration.
        /// </summary>
        /// <returns><see cref="CopConfiguration"/> instance. Call .Activate to activate the interception.</returns>
        public CopConfiguration Create()
        {
            return new CopConfiguration(this.container);
        }
    }
}