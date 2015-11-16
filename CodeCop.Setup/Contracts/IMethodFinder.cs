using System.Reflection;

namespace CodeCop.Setup.Contracts
{
    public interface IMethodFinder
    {
        MethodInfo FindIn<TClass>(string name);
    }
}