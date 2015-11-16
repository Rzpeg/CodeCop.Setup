using CodeCop.Core.Contracts;

namespace CodeCop.Setup.Contracts
{
    /// <summary>
    /// Complex interceptor contract
    /// </summary>
    public interface IInterceptor : ICopIntercept, ICopErrorHandle, ICopOverride
    {
         
    }
}