using Crypto.Cli;
using System.CommandLine;

var root = Commands.Initialize();
await root.InvokeAsync(args);