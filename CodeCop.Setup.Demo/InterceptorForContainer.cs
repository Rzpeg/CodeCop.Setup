using System;
using System.Collections.Generic;
using CodeCop.Core;
using CodeCop.Setup.Contracts;

namespace CodeCop.Setup.Demo
{
    public class InterceptorForContainer : ITypedInterceptor
    {
        public void OnBeforeExecute(InterceptionContext context)
        {
            Console.WriteLine("InterceptorForContainer > OnBeforeExecute");
        }

        public void OnAfterExecute(InterceptionContext context)
        {
            Console.WriteLine("InterceptorForContainer > OnAfterExecute");
        }

        public void OnError(InterceptionContext context)
        {

        }

        public object OnOverride(InterceptionContext context)
        {
            Console.WriteLine("InterceptorForContainer > OnOverride");
            return null;
        }

        public IEnumerable<string> TargetMethods => new List<string>()
        {
            nameof(Program.InterceptedViaInjection)
        };

        public Type TargetType => typeof(Program);
    }
}