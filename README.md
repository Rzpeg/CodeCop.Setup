# CodeCop.Setup
Fluent API Wrapper for [CodeCop][2]

What?
====

A Fluent API wrapper package for [CodeCop][2], enabling a clean way of configuring interceptors via code.

Why ?
====

The idea is to extend the existing API and to provide a lean alternative for those seeking for a more straightforward way of bootstrapping their hooks.

I also want to add some features missing from the [CodeCop][2], such as (but not limited to) loading hooks from various locations, including databases, files, and assemblies, integrating with your favourite IoC container and the likes. 

How ?
====

Everything resolves arround the configration API.
  
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

The sample console application CodeCop.Setup.Demo comes with the solution.
The documentation file is located in <b>Help</b> folder.

License
====

The package is licensed under under [The MIT License (MIT)][1].


[1]: http://opensource.org/licenses/MIT
[2]: http://getcodecop.com
