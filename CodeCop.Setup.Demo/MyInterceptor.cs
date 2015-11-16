using System;
using CodeCop.Core;
using CodeCop.Setup.Contracts;

namespace CodeCop.Setup.Demo
{
    public class MyInterceptor : IInterceptor
    {
        public void OnBeforeExecute(InterceptionContext context)
        {
            Console.WriteLine("OnBeforeExecute > MyInterceptor ! ");
        }

        public void OnAfterExecute(InterceptionContext context)
        {
            Console.WriteLine("OnAfterExecute > MyInterceptor !");
        }

        public void OnError(InterceptionContext context)
        {
        }

        public object OnOverride(InterceptionContext context)
        {
            Console.WriteLine("OnOverride > MyInterceptor !");
            return null;
        }
    }
}