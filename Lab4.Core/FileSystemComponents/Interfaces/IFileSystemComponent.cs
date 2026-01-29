using Itmo.ObjectOrientedProgramming.Lab4.Core.ValueObjects;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Visitors.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemComponents.Interfaces;

public interface IFileSystemComponent
{
    ComponentNameObject Name { get; }

    void Accept(IFileSystemComponentVisitor visitor);

    bool IsEqual(IFileSystemComponent other);
}