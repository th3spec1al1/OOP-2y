using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemComponents.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ValueObjects;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Visitors.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemComponents;

public class FileFileSystemComponent : IFileSystemComponent
{
    public ComponentNameObject Name { get; private set; }

    public FileContentObject Content { get; }

    public FileFileSystemComponent(ComponentNameObject name, FileContentObject content)
    {
        Name = name;
        Content = content;
    }

    public void Rename(ComponentNameObject newName)
    {
        Name = newName;
    }

    public FileFileSystemComponent Copy()
    {
        return new FileFileSystemComponent(Name, Content);
    }

    public void Accept(IFileSystemComponentVisitor visitor)
    {
        visitor.Visit(this);
    }

    public bool IsEqual(IFileSystemComponent other)
    {
        if (other is DirectoryFileSystemComponent) return false;

        return Name.IsEqual(other.Name);
    }
}