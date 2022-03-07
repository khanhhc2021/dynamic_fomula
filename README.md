# Dynamic Formula (Supports .Net 6)
 What's new in .NET 6

.NET 6 delivers the final parts of the .NET unification plan that started with [.NET 5](dotnet-5.md). .NET 6 unifies the SDK, base libraries, and runtime across mobile, desktop, IoT, and cloud apps. In addition to this unification, the .NET 6 ecosystem offers:

- **Simplified development**: Getting started is easy. New language features in [C# 10](../../csharp/whats-new/csharp-10.md) reduce the amount of code you need to write. And investments in the web stack and minimal APIs make it easy to quickly write smaller, faster microservices.

- **Better performance**: .NET 6 is the fastest full stack web framework, which lowers compute costs if you're running in the cloud.

- **Ultimate productivity**: .NET 6 and [Visual Studio 2022](/visualstudio/releases/2022/release-notes) provide hot reload, new git tooling, intelligent code editing, robust diagnostics and testing tools, and better team collaboration.

.NET 6 will be [supported for three years](https://dotnet.microsoft.com/platform/support/policy/dotnet-core) as a long-term support (LTS) release.

*Preview* features are disabled by default. They are also not supported for use in production and may be removed in a future version. The new <xref:System.Runtime.Versioning.RequiresPreviewFeaturesAttribute> is used to annotate preview APIs, and a corresponding analyzer alerts you if you're using these preview APIs.

.NET 6 is supported by Visual Studio 2022 and Visual Studio 2022 for Mac (and later versions).

This article does not cover all of the new features of .NET 6. To see all of the new features, and for further information about the features listed in this article, see the [Announcing .NET 6](https://devblogs.microsoft.com/dotnet/announcing-net-6) blog post.

## Performance

.NET 6 includes numerous performance improvements. This section lists some of the improvements&mdash;in [FileStream](#filestream), [profile-guided optimization](#profile-guided-optimization), and [AOT compilation](#crossgen2). For detailed information, see the [Performance improvements in .NET 6](https://devblogs.microsoft.com/dotnet/performance-improvements-in-net-6/) blog post.



# Dynamic Formula Wraper of Flee (Supports .Net Core 2.0)
 Fast Lightweight Expression Evaluator.
 Convert this project vb.net to c#.
  
 ## Project Description
Flee is an expression parser and evaluator for the .NET framework. It allows you to compute the value of string expressions such as sqrt(a^2 + b^2) at runtime. It uses a custom compiler, strongly-typed expression language, and lightweight codegen to compile expressions directly to IL. This means that expression evaluation is extremely fast and efficient.

## Features
* Fast and efficient expression evaluation
* Small, lightweight library
* Compiles expressions to IL using a custom compiler, lightweight codegen, and the DynamicMethod class
* Expressions (and the IL generated for them) are garbage-collected when no longer used
* Does not create any dynamic assemblies that stay in memory
* Backed by a comprehensive suite of unit tests
* Culture-sensitive decimal point
* Fine-grained control of what types an expression can use
* Supports all arithmetic operations including the power (^) operator
* Supports string, char, boolean, and floating-point literals
* Supports 32/64 bit, signed/unsigned, and hex integer literals
* Features a true conditional operator
* Supports short-circuited logical operations
* Supports arithmetic, comparison, implicit, and explicit overloaded operators
* Variables of any type can be dynamically defined and used in expressions
* CalculationEngine: Reference other expressions in an expression and recalculate in natural order
* Expressions can index arrays and collections, access fields and properties, and call functions on various types
* Generated IL can be saved to an assembly and viewed with a disassembler

### Installing Flee

You should install [Flee with NuGet](https://www.nuget.org/packages/Flee):

    Install-Package Flee
    
Or via the .NET Core command line interface:

    dotnet add package Flee
    
## NuGet Packages

| Name  | NuGet |
| :---  | :---  |
| [Flee](https://www.nuget.org/packages/Flee)                       | [![Flee](https://img.shields.io/badge/nuget-v1.2.2-blue.svg)](https://www.nuget.org/packages/Flee)                 

## More information
* [Examples](https://github.com/mparlak/Flee/wiki/Examples) to learn how to create and evaluate expressions.

## License
Flee is licensed under the LGPL. This means that as long as you dynamically link (ie: add a reference) to the officially released assemblies, you can use it in commercial and non-commercial applications.

## Building a sample

Build any .NET Core sample using the .NET Core CLI, which is installed with [the .NET Core SDK](https://www.microsoft.com/net/download). Then run
these commands from the CLI in the directory of any sample:

```console
dotnet build
dotnet run
```

These will install any needed dependencies, build the project, and run
the project respectively.

Multi-project samples have instructions in their root directory in
a `README.md` file.  

Except where noted, all samples build from the command line on
any platform supported by .NET Core. There are a few samples that are
specific to Visual Studio and require Visual Studio 2017 or later. In
addition, some samples show platform-specific features and will require
a specific platform. Other samples and snippets require the .NET Framework
and will run on Windows platforms, and will need the Developer Pack for
the target Framework version.

## Run your sample:

1. Go to the sample folder and build to check for errors:

    ```console
    dotnet build
    ```

2. Run your sample:

    ```console
    dotnet run
    ```

3. Call Api 
POST: https://localhost:7275/formula
Model Test: Data/test.json: 
 ```json
   {
        "name": "TinhPhiBHNangCao",
        "data": {
                "cost": 100000,
                "package": "VTA"
        },
        "formula": [
                {
                        "Id": "888DF05A-B1F8-4436-A5DF-55D36AAE0C5F",
                        "Name": "TinhPhiBH",
                        "DisplayName": "Phi goi bao hiem",
                        "Formulas": [
                                {
                                        "Id": "1EDED4DB-D388-4089-A17B-A15338EF2891",
                                        "Expression": "Cost +100000",
                                        "Condition": "Package = \"VTA\"",
                                        "ExpressionVariables": [
                                                {
                                                        "Name": "Cost",
                                                        "Type": 1
                                                }
                                        ],
                                        "ConditionVariables": [
                                                {
                                                        "Name": "Package",
                                                        "Type": 1
                                                }
                                        ]
                                },
                                {
                                        "Id": "1EDED4DB-D388-4089-A17B-A15338EF2891",
                                        "Expression": "Cost +50000",
                                        "Condition": "Package <> \"VTA\"",

                                        "ExpressionVariables": [
                                                {
                                                        "Name": "Cost",
                                                        "Type": 1
                                                }
                                        ],
                                        "ConditionVariables": [
                                                {
                                                        "Name": "Package",
                                                        "Type": 1
                                                }
                                        ]
                                }
                        ]
                },
                {
                        "Id": "53D3FB6E-D3AA-49D0-BABC-E9F9614223BC",
                        "Name": "TinhPhiBHNangCao",
                        "DisplayName": "Phi goi bao hiem PLUS",
                        "Formulas": [
                                {
                                        "Id": "7043351A-279C-4E12-BBAD-314B7D6933F5",
                                        "Expression": "TinhPhiBH + 200000",
                                        "Condition": "Package = \"VTA\"",
                                        "IsDefault": false,
                                        "ExpressionVariables": [
                                                {
                                                        "Name": "TinhPhiBH",
                                                        "Type": 0
                                                }
                                        ],
                                        "ConditionVariables": [
                                                {
                                                        "Name": "Package",
                                                        "Type": 1
                                                }
                                        ]
                                },
                                {
                                        "Id": "30D1399C-1290-4BCE-9681-FB0AB0B905BD",
                                        "Expression": "TinhPhiBH + 300000",
                                        "Condition": "Package <> \"VTA\"",

                                        "ExpressionVariables": [
                                                {
                                                        "Name": "TinhPhiBH",
                                                        "Type": 0
                                                }
                                        ],
                                        "ConditionVariables": [
                                                {
                                                        "Name": "Package",
                                                        "Type": 1
                                                }
                                        ]
                                }
                        ]
                }
        ]
}
    ```
