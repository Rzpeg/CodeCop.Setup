using System;
using System.Collections.Generic;
using CodeCop.Core;
using CodeCop.Setup.Contracts;

namespace CodeCop.Setup.Demo
{
    public class ProgramTypedInterceptor : ITypedInterceptor
    {
        public void OnBeforeExecute(InterceptionContext context)
        {
            Console.WriteLine("ProgramTypedInterceptor > OnBeforeExecute");
        }

        public void OnAfterExecute(InterceptionContext context)
        {
            Console.WriteLine("ProgramTypedInterceptor > OnAfterExecute");
        }

        public void OnError(InterceptionContext context)
        {

        }

        public object OnOverride(InterceptionContext context)
        {
            Console.WriteLine("ProgramTypedInterceptor > OnOverride");
            return null;
        }

        public IEnumerable<string> TargetMethods => new List<string>()
        {
            nameof(Program.DoMoreStuff),
            nameof(Program.DoBetterStuff)
        };

        public Type TargetType => typeof (Program);
    }
}