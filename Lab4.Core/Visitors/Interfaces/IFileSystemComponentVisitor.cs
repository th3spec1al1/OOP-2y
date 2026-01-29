using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemComponents;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Visitors.Interfaces;

public interface IFileSystemComponentVisitor
{
    void Visit(FileFileSystemComponent component);

    void Visit(DirectoryFileSystemComponent component);
}