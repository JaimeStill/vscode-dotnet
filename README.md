# Using `dotnet` in VS Code

* [Prerequisites](#prerequisites)
* [Settings](#settings)
* [dotnet CLI](#dotnet-cli)
* [Project Initialization](#project-initialization)
    * [Solution](#solution)
    * [Class Library](#class-library)
    * [CLI App](#cli-app)
    * [Execution](#execution)
* [Debugging](#debugging)

## Prerequisites
[Back to Top](#using-dotnet-in-vs-code)

Before beginning, ensure that the latest versions of the following applications are installed:

* [.NET SDK](https://dotnet.microsoft.com/en-us/download)
* [VS Code](https://code.visualstudio.com/)

Once installed, ensure the [C# Extension](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp) is added to VS Code.

## Settings
[Back to Top](#using-dotnet-in-vs-code)

Settings can be adjusted by pressing <kbd>F1</kbd>, typing *Settings*, and clicking the resulting *Preferences: Open Settings (UI)* or *Preferences: Open Settings (JSON)*.

> If configuring the settings through the UI, the desired settings can be easily found with the searchbar.

Ensure the following OmniSharp settings are enabled:

**UI Settings**  

* **OmniSharp**: Enable Roslyn Analyzers
    * Enables support for roslyn analyzers, code fixes and rulesets.
    * See [Overview of Source Code Analysis](https://docs.microsoft.com/en-us/visualstudio/code-quality/roslyn-analyzers-overview?view=vs-2022)
* **OmniSharp**: Use Modern .NET
    * Use OmniSharp biuld for .NET 6. This version **does not** support non-SDK style .NET Framework projects, including Unity. SDK-style Framework, .NET Core, and .NET 5+ projects should see significant performance improvements.

**JSON Settings**
```json
{
    "omnisharp.enableRoslynAnalyzers": true,
    "omnisharp.useModernNet": true
}
```

> If at any point the features provided by OmniSharp do not seem to be working, you can restart the OmniSharp server by pressing <kbd>F1</kbd> to open the command palette and executing ***OmniSharp**: Restart OmniSharp*.

**Further Resources**  
* [VS Code Settings](https://code.visualstudio.com/docs/getstarted/settings)
* [C# Programming with Visual Studio Code](https://code.visualstudio.com/docs/languages/csharp)
* [GitHub - omnisharp-vscode](https://github.com/OmniSharp/omnisharp-vscode) - C# Extension Repository

## `dotnet` CLI

> In VS Code, the keyboard shortcut <kbd>Ctrl + ~</kbd> will open up the terminal.

When the .NET SDK is installed, so also is the [dotnet CLI](https://docs.microsoft.com/en-us/dotnet/core/tools/). The `dotnet` command can be used to easily scaffold out and manage a .NET project.

You can discover the features supported by `dotnet` by appending `-h` to the end of any command:

`dotnet h`  

```
.NET SDK (6.0.201)
Usage: dotnet [runtime-options] [path-to-application] [arguments]

Execute a .NET application.

runtime-options:
  --additionalprobingpath <path>   Path containing probing policy and assemblies to probe for.
  --additional-deps <path>         Path to additional deps.json file.
  --depsfile                       Path to <application>.deps.json file.
  --fx-version <version>           Version of the installed Shared Framework to use to run the application.
  --roll-forward <setting>         Roll forward to framework version  (LatestPatch, Minor, LatestMinor, Major, LatestMajor, Disable).
  --runtimeconfig                  Path to <application>.runtimeconfig.json file.

path-to-application:
  The path to an application .dll file to execute.

Usage: dotnet [sdk-options] [command] [command-options] [arguments]

Execute a .NET SDK command.

sdk-options:
  -d|--diagnostics  Enable diagnostic output.
  -h|--help         Show command line help.
  --info            Display .NET information.
  --list-runtimes   Display the installed runtimes.
  --list-sdks       Display the installed SDKs.
  --version         Display .NET SDK version in use.

SDK commands:
  add               Add a package or reference to a .NET project.
  build             Build a .NET project.
  build-server      Interact with servers started by a build.
  clean             Clean build outputs of a .NET project.
  format            Apply style preferences to a project or solution.
  help              Show command line help.
  list              List project references of a .NET project.
  msbuild           Run Microsoft Build Engine (MSBuild) commands.
  new               Create a new .NET project or file.
  nuget             Provides additional NuGet commands.
  pack              Create a NuGet package.
  publish           Publish a .NET project for deployment.
  remove            Remove a package or reference from a .NET project.
  restore           Restore dependencies specified in a .NET project.
  run               Build and run a .NET project output.
  sdk               Manage .NET SDK installation.
  sln               Modify Visual Studio solution files.
  store             Store the specified assemblies in the runtime package store.
  test              Run unit tests using the test runner specified in a .NET project.
  tool              Install or manage tools that extend the .NET experience.
  vstest            Run Microsoft Test Engine (VSTest) commands.
  workload          Manage optional workloads.

Additional commands from bundled tools:
  dev-certs         Create and manage development certificates.
  fsi               Start F# Interactive / execute F# scripts.
  sql-cache         SQL Server cache command-line tools.
  user-secrets      Manage development user secrets.
  watch             Start a file watcher that runs a command when files change.

Run 'dotnet [command] --help' for more information on a command.
```

The `dotnet new` command provides options that are available when scaffolding new .NET assets:

`dotnet new -h`

```
Usage: new [options]

Options:
  -h, --help                     Displays help for this command.
  -l, --list <PARTIAL_NAME>      Lists templates containing the specified template name. If no name is specified, lists all templates.
  -n, --name                     The name for the output being created. If no name is specified, the name of the output directory is used.
  -o, --output                   Location to place the generated output.
  -i, --install                  Installs a source or a template package.
  -u, --uninstall                Uninstalls a source or a template package.
  --interactive                  Allows the internal dotnet restore command to stop and wait for user input or action (for example to complete authentication).
  --add-source, --nuget-source   Specifies a NuGet source to use during install.
  --type                         Filters templates based on available types. Predefined values are "project" and "item".
  --dry-run                      Displays a summary of what would happen if the given command line were run if it would result in a template creation.
  --force                        Forces content to be generated even if it would change existing files.
  -lang, --language              Filters templates based on language and specifies the language of the template to create.
  --update-check                 Check the currently installed template packages for updates.
  --update-apply                 Check the currently installed template packages for update, and install the updates.
  --search <PARTIAL_NAME>        Searches for the templates on NuGet.org.
  --author <AUTHOR>              Filters the templates based on the template author. Applicable only with --search or --list | -l option.
  --package <PACKAGE>            Filters the templates based on NuGet package ID. Applies to --search.
  --columns <COLUMNS_LIST>       Comma separated list of columns to display in --list and --search output.
                                 The supported columns are: language, tags, author, type.
  --columns-all                  Display all columns in --list and --search output.
  --tag <TAG>                    Filters the templates based on the tag. Applies to --search and --list.
  --no-update-check              Disables checking for the template package updates when instantiating a template.
```

For a list of all of the .NET resources that can be scaffolded using `dotnet`:

`dotnet new --list`

```
These templates matched your input: 

Template Name                                 Short Name           Language    Tags                                 
--------------------------------------------  -------------------  ----------  -------------------------------------
ASP.NET Core Empty                            web                  [C#],F#     Web/Empty                            
ASP.NET Core gRPC Service                     grpc                 [C#]        Web/gRPC                             
ASP.NET Core Web API                          webapi               [C#],F#     Web/WebAPI                           
ASP.NET Core Web App                          webapp,razor         [C#]        Web/MVC/Razor Pages                  
ASP.NET Core Web App (Model-View-Controller)  mvc                  [C#],F#     Web/MVC                              
ASP.NET Core with Angular                     angular              [C#]        Web/MVC/SPA                          
ASP.NET Core with React.js                    react                [C#]        Web/MVC/SPA                          
ASP.NET Core with React.js and Redux          reactredux           [C#]        Web/MVC/SPA                          
Blazor Server App                             blazorserver         [C#]        Web/Blazor                           
Blazor WebAssembly App                        blazorwasm           [C#]        Web/Blazor/WebAssembly/PWA           
Class Library                                 classlib             [C#],F#,VB  Common/Library                       
Console App                                   console              [C#],F#,VB  Common/Console                       
dotnet gitignore file                         gitignore                        Config                               
Dotnet local tool manifest file               tool-manifest                    Config                               
EditorConfig file                             editorconfig                     Config                               
global.json file                              globaljson                       Config                               
MSTest Test Project                           mstest               [C#],F#,VB  Test/MSTest                          
MVC ViewImports                               viewimports          [C#]        Web/ASP.NET                          
MVC ViewStart                                 viewstart            [C#]        Web/ASP.NET                          
NuGet Config                                  nugetconfig                      Config                               
NUnit 3 Test Item                             nunit-test           [C#],F#,VB  Test/NUnit                           
NUnit 3 Test Project                          nunit                [C#],F#,VB  Test/NUnit                           
Protocol Buffer File                          proto                            Web/gRPC                             
Razor Class Library                           razorclasslib        [C#]        Web/Razor/Library/Razor Class Library
Razor Component                               razorcomponent       [C#]        Web/ASP.NET                          
Razor Page                                    page                 [C#]        Web/ASP.NET                          
Solution File                                 sln                              Solution                             
Web Config                                    webconfig                        Config                               
Windows Forms App                             winforms             [C#],VB     Common/WinForms                      
Windows Forms Class Library                   winformslib          [C#],VB     Common/WinForms                      
Windows Forms Control Library                 winformscontrollib   [C#],VB     Common/WinForms                      
Worker Service                                worker               [C#],F#     Common/Worker/Web                    
WPF Application                               wpf                  [C#],VB     Common/WPF                           
WPF Class library                             wpflib               [C#],VB     Common/WPF                           
WPF Custom Control Library                    wpfcustomcontrollib  [C#],VB     Common/WPF                           
WPF User Control Library                      wpfusercontrollib    [C#],VB     Common/WPF                           
xUnit Test Project                            xunit                [C#],F#,VB  Test/xUnit
```

**Further Reading**  
* [Global `dotnet` tools](https://docs.microsoft.com/en-us/dotnet/core/tools/global-tools)
* [`dotnet` tools on NuGet](https://www.nuget.org/packages?packagetype=dotnettool)

## Project Initialization
[Back to Top](#using-dotnet-in-vs-code)

> The project that follows is drastically simplified just to demonstrate the intended concepts. For a more robust example that this project was inspired by, see [crypto-cli](https://github.com/JaimeStill/cryptography/tree/main/crypto-cli).

The following project will demonstrate the most common `dotnet` commands that I have encountered when scaffolding out a .NET solution, excluding the Entity Framework `dotnet ef` commands provided by the [`dotnet-ef`](https://docs.microsoft.com/en-us/ef/core/cli/dotnet) global tools package. Entity Framework is beyond the scope of this project.

The solution will contain the following structure:

* vscode-dotnet/
    * Crypto.Core/
        * Crypto.Core.csproj
        * Crypto.cs
    * Crypto.Cli/
        * crypto.csproj
            * Project Reference - Crypto.Core
            * Package Reference - [System.CommandLine](https://github.com/dotnet/command-line-api)
            * Package Reference - [System.CommandLine.NamingConventionBinder](https://github.com/dotnet/command-line-api/issues/1537)
        * Program.cs
        * Commands.cs
    * Crypto.sln

### Solution
[Back to Top](#using-dotnet-in-vs-code)

To generate the `vscode-dotnet` directory, as well as the `Crypto.sln` solution file, execute the following command from a terminal pointing to the location you want to generate the project:

```PowerShell
dotnet new sln -n Crypto -o vscode-dotnet
```

This specifies that a **Solution** file named **Crypto** should be generated in the directory **vscode-dotnet** relative to the current path:

![dotnet-new-sln](https://user-images.githubusercontent.com/14102723/170581746-235be9a6-d8ea-407c-a4e5-474bb1d2f96a.png)

### Class Library
[Back to Top](#using-dotnet-in-vs-code)

From a terminal pointed to the `vscode-dotnet` directory, run the following commands:

```PowerShell
dotnet new classlib -n Crypto.Core

dotnet sln add Crypto.Core
```

This will scaffold out a **Class Library** project and add it to the **Crypto** solution:

![dotnet-new-classlib](https://user-images.githubusercontent.com/14102723/170582210-305f0123-a324-4c77-8b7d-23079f939100.png)

Change the name of **Class1.cs** to **Crypto.cs** and provide it with the following code:

```cs
namespace Crypto.Core;

public static class Generator
{
    /*
        This is intentionally verbose to facilitate
        debugging in the final step.
    */
    public static string GenerateNft()
    {        
        var guid = Guid.NewGuid();
        var nft = $"Newly Generated NFT (don't right-click): {guid}";
        return nft;
    }
}

```

### CLI App
[Back to Top](#using-dotnet-in-vs-code)

From a terminal pointed to the `vscode-dotnet` dirctory, execute the following commands:

```PowerShell
dotnet new console -n crypto -o Crypto.Cli

dotnet sln add 
```

This will scaffold out a **Console App** project and add it to the **Crypto** solution:

![dotnet-new-console](https://user-images.githubusercontent.com/14102723/170594312-7df93110-475b-4f9d-994e-e56534e233cc.png)

The **Crypto.Cli** project needs to specify two dependencies:

1. A reference to the internal **Crypto.Core** class library.
2. The [**System.CommandLine**](https://github.com/dotnet/command-line-api) NuGet Package.
3. The [**System.CommandLine.NamingConventionBinder**](https://github.com/dotnet/command-line-api/issues/1537) NuGet Package.

To add the dependencies to the **Crypto.Cli** project, execute the following commands:

```PowerShell
dotnet add Crypto.Cli reference Crypto.Core

dotnet add Crypto.Cli package System.CommandLine --prerelease
dotnet add Crypto.Cli package System.CommandLine.NamingConventionBinder --prerelease
```

After executing these commands, the **crypto.csproj** file should look similar to this:

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <ItemGroup>
    <ProjectReference Include="..\Crypto.Core\Crypto.Core.csproj" />
  </ItemGroup>

  <ItemGroup>
    <PackageReference Include="System.CommandLine" Version="2.0.0-beta3.22114.1" />
    <PackageReference Include="System.commandLine.NamingConventionBinder" Version="2.0.0-beta3.22114.1" />
  </ItemGroup>

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net6.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>

</Project>
```

Add a **Commands.cs** file with the following contents:

```cs
namespace Crypto.Cli;

using Crypto.Core;
using System.CommandLine;
using System.CommandLine.NamingConventionBinder;

public static class Commands
{
    public static RootCommand Initialize() =>
        BuildCommands()
            .BuildRootCommand();

    public static RootCommand BuildRootCommand(this List<Command> commands)
    {
        var root = new RootCommand("Crypo CLI");
        commands.ForEach(command => root.AddCommand(command));
        return root;
    }

    static List<Command> BuildCommands() => new()
    {
        BuildGenerateNft()
    };

    static Command BuildGenerateNft() =>
        BuildCommand(
            "generate-nft",
            "Generate something useless",
            new Action(() => Console.WriteLine(Generator.GenerateNft()))
        );

    static Command BuildCommand(string name, string description, Delegate @delegate, List<Option>? options = null)
    {
        var command = new Command(name, description)
        {
            Handler = CommandHandler.Create(@delegate)
        };

        if (options is not null)
            options.ForEach(option => command.AddOption(option));

        return command;
    }
}
```

Replace the generated **Program.cs** contents with the following:

> If the following looks confusing, see [top-level statements](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-9.0/top-level-statements)

```cs
using Crypto.Cli;
using System.CommandLine;

var root = Commands.Initialize();
await root.InvokeAsync(args);
```

### Execution

> In VS Code, the keyboard shortcut <kbd>Ctrl + ~</kbd> will open up the terminal.  
>
> To open a new split terminal, use the keyboard shortcut <kbd>Ctrl + Shift + 5</kbd> while focused in a terminal window.

In a terminal pointed at `vscode-dotnet`, execute the following:

```PowerShell
dotnet build
```

Open a new split terminal window, change directory to `vscode-dotnet/Crypto.Cli/bin/Debug/net6.0` and execute the following:

```PowerShell
.\crypto.exe -h
```

This should render the following help dialog:

```
Description:
  Crypo CLI

Usage:
  crypto [command] [options]

Options:
  --version       Show version information
  -?, -h, --help  Show help and usage information

Commands:
  generate-nft  Generate something useless
```

Execute the following:

```
.\crypto.exe generate-nft
```

This should output a 

## Debugging

To generate a debug config, press <kbd>Ctrl + Shift + D</kbd> to open the **Run and Debug** view in the sidebar, then click the *create a launch.json* file:

![image](https://user-images.githubusercontent.com/14102723/170599729-38afeb62-00fd-4bc7-aec2-5c463524e409.png)

In the *Select environment* prompt, select **.NET 5+ and .NET Core**.

![image](https://user-images.githubusercontent.com/14102723/170600157-b892c534-fafc-4a3c-b243-73b484444d81.png)

This will generate the following directory + files:

* .vscode/
    * launch.json
    * tasks.json

In **launch.json**, within the `configurations.args` array, add the value `"generate-nft"`. This will ensure that argument is passed in when debugging is initiated.

**launch.json**

```js
{
    "version": "0.2.0",
    "configurations": [
        {
            "name": ".NET Core Launch (console)",
            "type": "coreclr",
            "request": "launch",
            "preLaunchTask": "build",
            "program": "${workspaceFolder}/Crypto.Cli/bin/Debug/net6.0/crypto.dll",
            "args": [
                "generate-nft"
            ],
            "cwd": "${workspaceFolder}/Crypto.Cli",
            "console": "internalConsole",
            "stopAtEntry": false
        },
        {
            "name": ".NET Core Attach",
            "type": "coreclr",
            "request": "attach"
        }
    ]
}
```

**configurations.preLaunchTask** specifies the value `build`. This is defined inside of **tasks.json**:

```js
{
    "version": "2.0.0",
    "tasks": [
        {
            "label": "build",
            "command": "dotnet",
            "type": "process",
            "args": [
                "build",
                "${workspaceFolder}/Crypto.Cli/crypto.csproj",
                "/property:GenerateFullPaths=true",
                "/consoleloggerparameters:NoSummary"
            ],
            "problemMatcher": "$msCompile"
        },
        {
            "label": "publish",
            "command": "dotnet",
            "type": "process",
            "args": [
                "publish",
                "${workspaceFolder}/Crypto.Cli/crypto.csproj",
                "/property:GenerateFullPaths=true",
                "/consoleloggerparameters:NoSummary"
            ],
            "problemMatcher": "$msCompile"
        },
        {
            "label": "watch",
            "command": "dotnet",
            "type": "process",
            "args": [
                "watch",
                "run",
                "--project",
                "${workspaceFolder}/Crypto.Cli/crypto.csproj"
            ],
            "problemMatcher": "$msCompile"
        }
    ]
}
```

At *line 9* of **Crypto.Core/Generator.cs**, press <kbd>F9</kbd> to set a breakpoint, then press <kbd>F5</kbd> to initiate debugging.

The `crypto` CLI app should launch with the `generate-nft` argument, and execution should pause at the set breakpoint:

![debugging](https://user-images.githubusercontent.com/14102723/170602473-48bb1c03-dd61-4d5a-9d19-567c311f7e46.png)

**Further Reading**  
* [VS Code Debugging](https://code.visualstudio.com/docs/editor/debugging)