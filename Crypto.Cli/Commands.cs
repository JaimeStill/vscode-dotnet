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