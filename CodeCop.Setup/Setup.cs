using CodeCop.Setup.Contracts;
using CodeCop.Setup.DependencyResolution;
using CodeCop.Setup.Infrastructure;

namespace CodeCop.Setup
{
    /// <summary>
    /// Entry point for Fluent API builder.
    /// </summary>
    public static class Setup
    {
        /// <summary>
        /// Initializes a new builder using the internal IoC container.
        /// </summary>
        /// <returns>A new CopBuilder instance which enables Fluent API.</returns>
        public static CopBuilder Build()
        {
            return new CopBuilder(
                new InternalContainer(), 
                new MethodFinder());
        }

        /// <summary>
        /// Initializes a new builder using the provided IoC container.
        /// </summary>
        /// <returns>A new CopBuilder instance which enables Fluent API.</returns>
        public static CopBuilder Build(IContainer container)
        {
            return new CopBuilder(
                container, 
                new MethodFinder());
        }
    }
}