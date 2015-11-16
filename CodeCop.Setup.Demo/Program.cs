using System;
using CodeCop.Setup.Enums;

namespace CodeCop.Setup.Demo
{

    internal class Program
    {
        private static void Main(string[] args)
        {

            DoStuff();
            Console.WriteLine();

            DoAnotherStuff();
            Console.WriteLine();

            Setup
                .Build()
                .InterceptMethodIn<Program>(nameof(DoStuff), Intercept.Before,
                    ctx =>
                    {
                        Console.WriteLine("InterceptOn.Before > DoStuff !");
                        return null;
                    })
                .InterceptMethodIn<Program>(nameof(DoStuff), Intercept.After,
                    ctx =>
                    {
                        Console.WriteLine("InterceptOn.After > DoStuff !");
                        return null;
                    })
                .InterceptMethodIn<Program>(nameof(DoStuff), Intercept.Override,
                    ctx =>
                    {
                        Console.WriteLine("InterceptOn.Override > DoStuff !");
                        return null;
                    })
                .InterceptMethodIn<Program>(nameof(DoAnotherStuff), new MyInterceptor())
                .Create()
                .Activate();

            DoStuff();
            Console.WriteLine();

            DoAnotherStuff();
            Console.WriteLine();
        }

        public static void DoStuff()
        {
            Console.WriteLine(nameof(DoStuff));
        }

        public static void DoAnotherStuff()
        {
            Console.WriteLine(nameof(DoAnotherStuff));
        }
    }
}