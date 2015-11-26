# CodeCop.Setup
Fluent API Wrapper for [CodeCop][2]

What?
====

A Fluent API wrapper package for [CodeCop][2], providing an alternative way of configuring interceptors using the code.

Why ?
====

The idea is to extend the existing API and to provide a lean alternative for those seeking for a more straightforward way of bootstrapping their hooks.

I also want to add some features missing from the [CodeCop][2], such as (but not limited to) loading hooks from various locations, including databases, files, and assemblies, integrating with your favourite IoC container and the likes. 

How ?
====

Everything resolves arround the configuration API.
  
    Setup
        .Build()
        .InterceptMethodIn<Program>(nameof(DoStuff), Intercept.Before,
            ctx =>
            {
                Console.WriteLine("InterceptOn.Before > DoStuff !");
                return null;
            })
        .InterceptMethodIn<Program>(nameof(DoAnotherStuff), new MyInterceptor())
        .Create()
        .Activate();

You can also use your favourite IoC container containing registrations for your interceptors (<b>ITypedInterceptor</b>).
To do so, install the adapter package (available for [Autofac][4], [StructureMap][5], [Unity][6], [Castle.Windsor][7] and [Ninject][8]). 

Example:

 
    var containerBuilder = new ContainerBuilder();

    containerBuilder
        .RegisterType<MyInterceptor>()
        .As<ITypedInterceptor>();

     var container = containerBuilder.Build();
     var copAdapter = new CodeCop.Setup.Autofac.AutofacContainerAdapter(container);
     
     Setup
         .Build(copAdapter)
         .Create()
         .Activate();

You can also combine IoC registered interceptors and fluent-api.

     Setup
           .Build(copAdapter)
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


The sample console application CodeCop.Setup.Demo can be found [Here][3] .
The documentation file is located in <b>Help</b> folder.

License
====

The package is licensed under under [The MIT License (MIT)][1].


[1]: http://opensource.org/licenses/MIT
[2]: http://getcodecop.com
[3]: https://github.com/Rzpeg/CodeCop.Setup.Demo
[4]: https://www.nuget.org/packages/CodeCop.Setup.Autofac
[5]: https://www.nuget.org/packages/CodeCop.Setup.StructureMap
[6]: https://www.nuget.org/packages/CodeCop.Setup.Unity
[7]: https://www.nuget.org/packages/CodeCop.Setup.Castle.Windsor
[8]: https://www.nuget.org/packages/CodeCop.Setup.Ninject
