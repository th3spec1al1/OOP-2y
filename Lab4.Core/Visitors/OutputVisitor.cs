using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemComponents;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemComponents.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Outputs.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Visitors.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Visitors;

public class OutputVisitor : IFileSystemComponentVisitor
{
    private const string FileSymbol = "📄";
    private const string FolderSymbol = "📁";
    private const string IndentSymbol = " ";

    private readonly IOutput _output;
    private readonly int _maxDepth;

    private int _depth;

    public OutputVisitor(IOutput output, int maxDepth = 1)
    {
        _output = output;
        _maxDepth = maxDepth;
    }

    public void Visit(FileFileSystemComponent component)
    {
        _output.Write(string.Concat(Enumerable.Repeat(IndentSymbol, _depth)));
        _output.WriteLine(FileSymbol + component.Name);
    }

    public void Visit(DirectoryFileSystemComponent component)
    {
        if (_depth >= _maxDepth) return;

        _output.Write(string.Concat(Enumerable.Repeat(IndentSymbol, _depth)));
        _output.WriteLine(FolderSymbol + component.Name);

        _depth++;

        foreach (IFileSystemComponent child in component.Components)
            child.Accept(this);

        _depth--;
    }
}