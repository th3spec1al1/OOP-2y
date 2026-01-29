using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Outputs;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Outputs.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.System;
using Itmo.ObjectOrientedProgramming.Lab4.Core.System.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsing;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsing.Iterators;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation;

public class Program
{
    public static void Main()
    {
        ISession session = new Session();
        IOutput output = new ConsoleOutput();

        BaseCommandParseLink parserChain = CreateParserChain();

        RunCommandLoop(session, parserChain, output);
    }

    private static ConnectParseLink CreateParserChain()
    {
        var connectParser = new ConnectParseLink();
        var disconnectParser = new DisconnectParseLink();
        var treeGotoParser = new TreeGoToParseLink();
        var treeListParser = new TreeListParseLink();
        var fileShowParser = new FileShowParseLink();
        var fileMoveParser = new FileMoveParseLink();
        var fileCopyParser = new FileCopyParseLink();
        var fileDeleteParser = new FileDeleteParseLink();
        var fileRenameParser = new FileRenameParseLink();

        connectParser
            .SetNext(disconnectParser)
            .SetNext(treeGotoParser)
            .SetNext(treeListParser)
            .SetNext(fileShowParser)
            .SetNext(fileMoveParser)
            .SetNext(fileCopyParser)
            .SetNext(fileDeleteParser)
            .SetNext(fileRenameParser);

        return connectParser;
    }

    private static void RunCommandLoop(ISession session, BaseCommandParseLink parserChain, IOutput output)
    {
        output.WriteLine("File System Lab work\n");

        while (true)
        {
            output.Write($"{session.ConnectionPath}> ");
            string? input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
                continue;

            if (input.Trim().Equals("exit", StringComparison.OrdinalIgnoreCase))
                break;

            var tokens = new CommandTokenIterator(input);
            ICommand? command = parserChain.Parse(tokens);

            if (command == null)
            {
                output.WriteLine($"Unknown command: {input}");
            }
            else
            {
                CommandExecuteResult result = command.Execute(session);
                if (result is CommandExecuteResult.Failure failureResult)
                {
                    output.WriteLine(failureResult.Error);
                }
                else
                {
                    output.WriteLine(string.Empty);
                }
            }
        }
    }
}