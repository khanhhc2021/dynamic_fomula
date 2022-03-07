# Flee (Supports .Net Core 2.0)
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

## Creating new samples

If you wish to add a code sample:

1. Your sample **must be part of a buildable project**. Where possible, the projects should build on all platforms supported by .NET Core. Exceptions to this are samples that demonstrate a platform-specific feature or platform-specific tool.

2. Your sample should conform to the [runtime coding style](https://github.com/dotnet/runtime/blob/main/docs/coding-guidelines/coding-style.md) to maintain consistency.

    - Additionally, we prefer the use of `static` methods rather than instance methods when demonstrating something that doesn't require instantiating a new object.

3. Your sample should include **appropriate exception handling**. It should handle all exceptions that are likely to be thrown in the context of the sample. For example, a sample that calls the [Console.ReadLine](https://docs.microsoft.com/dotnet/api/system.console.readline) method to retrieve user input should use appropriate exception handling when the input string is passed as an argument to a method. Similarly, if your sample expects a method call to fail, the resulting exception must be handled. Always handle the specific exceptions thrown by the method, rather than base class exceptions such as [Exception](https://docs.microsoft.com/dotnet/api/system.exception) or [SystemException](https://docs.microsoft.com/dotnet/api/system.systemexception).

4. If your sample builds a standalone package, you must include the runtimes used by our CI build system, in addition to any runtimes used by your sample:

    - `win7-x64`
    - `win8-x64`
    - `win81-x64`
    - `ubuntu.16.04-x64`

We will have a CI system in place to build these projects shortly.

To create a sample:

1. File an [issue](https://github.com/dotnet/docs/issues) or add a comment to an existing one that you are working on it.
2. Write the topic that explains the concepts demonstrated in your sample (example: `docs/standard/linq/where-clause.md`).
3. Write your sample (example: *WhereClause-Sample1.cs*).
4. Create a *Program.cs* with a Main entry point that calls your samples. If there is already one there, add the call to your sample:

    ```csharp
    public class Program
    {
        public void Main(string[] args)
        {
            WhereClause1.QuerySyntaxExample();

            // Add the method syntax as an example.
            WhereClause1.MethodSyntaxExample();
        }
    }
    ```

5. Don't check in the solution file if it contains only one project.

To build and run your sample:

1. Go to the sample folder and build to check for errors:

    ```console
    dotnet build
    ```

2. Run your sample:

    ```console
    dotnet run
    ```

3. Add a *README.md* to the root directory of your sample.

   This should include a brief description of the code, and refer people to the article that references the sample.