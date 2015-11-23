using System;
using Autofac;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using CodeCop.Setup.Autofac;
using CodeCop.Setup.Contracts;
using CodeCop.Setup.Enums;
using CodeCop.Setup.StructureMap;
using CodeCop.Setup.Unity;
using Microsoft.Practices.Unity;
using Ninject;

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

            DoMoreStuff();
            Console.WriteLine();

            DoBetterStuff();
            Console.WriteLine();

            InterceptedViaInjection();
            Console.WriteLine();

            #region Autofac adapter demo
            
            // autofac container
            var afContainerBuilder = new ContainerBuilder();

            afContainerBuilder
                .RegisterType<InterceptorForContainer>()
                .As<ITypedInterceptor>();

            var afContainer = afContainerBuilder.Build();

            // cop adapter
            var afCopAdapter = new AutofacContainerAdapter(afContainer);

            #endregion

            #region Castle.Windsor adapter demo

            var cwContainer = new WindsorContainer();

            cwContainer.Register(
                Component.For<ITypedInterceptor>()
                .ImplementedBy<InterceptorForContainer>()
                );

            var cwCopAdapter = new CodeCop.Setup.Castle.Windsor.CastleWindsorContainerAdapter(cwContainer);

            #endregion

            #region Ninject adapter demo

            var nContainer = new StandardKernel();

            nContainer
                .Bind<ITypedInterceptor>()
                .To<InterceptorForContainer>();

            var nCopAdapter = new CodeCop.Setup.Ninject.NinjectContainerAdapter(nContainer);

            #endregion

            #region StructureMap adapter demo

            var smContainer = new global::StructureMap.Container();

            smContainer
                .Configure(c =>
                {
                    c.For<ITypedInterceptor>()
                     .Use<InterceptorForContainer>();
                });

            var smCopAdapter = new StructureMapContainerAdapter(smContainer);

            #endregion

            #region Unity adapter demo

            var uContainer = new Microsoft.Practices.Unity.UnityContainer();

            uContainer.RegisterType<ITypedInterceptor, InterceptorForContainer>();

            var uCopAdapter = new UnityContainerAdapter(uContainer);

            #endregion

            Setup
                .Build(uCopAdapter) // pass the adapter
                .InterceptMethodIn<Program>(nameof(DoStuff), Intercept.Before,
                    ctx =>
                    {
                        Console.WriteLine("InterceptOn.Before > DoStuff !");
                        return null;
                    })
                .InterceptMethodIn<Program>(nameof(DoAnotherStuff), new MyInterceptor())
                .UseInterceptor(new ProgramTypedInterceptor())
                .Create()
                .Activate();

            DoStuff();
            Console.WriteLine();

            DoAnotherStuff();
            Console.WriteLine();

            DoMoreStuff();
            Console.WriteLine();

            DoBetterStuff();
            Console.WriteLine();

            InterceptedViaInjection();
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

        public static void DoMoreStuff()
        {
            Console.WriteLine(nameof(DoMoreStuff));
        }

        public static void DoBetterStuff()
        {
            Console.WriteLine(nameof(DoBetterStuff));
        }

        public static void InterceptedViaInjection()
        {
            Console.WriteLine(nameof(InterceptedViaInjection));
        }
    }
}