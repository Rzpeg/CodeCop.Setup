using System;
using System.Collections.Generic;

namespace CodeCop.Setup.Contracts
{
    public interface ITypedInterceptor : IInterceptor
    {
        Type TargetType { get; }
        IEnumerable<string> TargetMethods { get; }
    }
}