using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsing.FlagLinks;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsing.FlagLinks.CommandFlags;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsing.Iterators;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsing;

public abstract class BaseCommandWithFlagsParseLink : BaseCommandParseLink
{
    private readonly BaseFlagParseLink _flagParserChain = CreateFlagParserChain();

    protected IReadOnlyList<ICommandFlag> ParseFlags(CommandTokenIterator tokens)
    {
        var flags = new List<ICommandFlag>();

        while (tokens.MoveNext())
        {
            string current = tokens.Current;

            if (current.StartsWith('-'))
            {
                ICommandFlag? flag = _flagParserChain.Parse(current, tokens);
                if (flag != null)
                {
                    flags.Add(flag);
                }
                else
                {
                    throw new ArgumentException($"Unknown flag: {current}");
                }
            }
            else
            {
                break;
            }
        }

        return flags;
    }

    protected T GetFlagValue<T>(IReadOnlyList<ICommandFlag> flags, string flagName, T defaultValue)
    {
        ICommandFlag? flag = flags.FirstOrDefault(f => f.Name == flagName);
        if (flag == null || flag.Value == null) return defaultValue;

        return (T)Convert.ChangeType(flag.Value, typeof(T));
    }

    private static DepthFlagParseLink CreateFlagParserChain()
    {
        var depthParser = new DepthFlagParseLink();
        var modeParser = new FileSystemModeParseLink();
        var outputParser = new OutputModeParseLink();

        depthParser
            .SetNext(modeParser)
            .SetNext(outputParser);

        return depthParser;
    }
}