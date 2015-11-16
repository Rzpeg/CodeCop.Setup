using System.Reflection;
using CodeCop.Setup.Contracts;

namespace CodeCop.Setup.Infrastructure
{
    internal class MethodFinder : IMethodFinder
    {
        public MethodInfo FindIn<TClass>(string name)
        {
            return typeof (TClass).GetMethod(name);
        }
    }
}