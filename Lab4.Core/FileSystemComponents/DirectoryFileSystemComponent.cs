using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemComponents.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ValueObjects;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Visitors.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemComponents;

public class DirectoryFileSystemComponent : IFileSystemComponent
{
    private readonly List<IFileSystemComponent> _subDirectoriesAndFiles;

    public ComponentNameObject Name { get; private set; }

    public DirectoryFileSystemComponent(
        ComponentNameObject name,
        IReadOnlyList<IFileSystemComponent>? subDirectoriesAndFiles = null)
    {
        Name = name;
        _subDirectoriesAndFiles = subDirectoriesAndFiles != null ? subDirectoriesAndFiles.ToList() : [];
    }

    public IEnumerable<IFileSystemComponent> Components => _subDirectoriesAndFiles.AsReadOnly();

    public void Accept(IFileSystemComponentVisitor visitor)
    {
        visitor.Visit(this);
    }

    public void Add(IFileSystemComponent component)
    {
        _subDirectoriesAndFiles.Add(component);
    }

    public void DeleteComponent(IFileSystemComponent component)
    {
        IFileSystemComponent? needComponent = null;
        foreach (IFileSystemComponent currentComponent in _subDirectoriesAndFiles)
        {
            if (currentComponent.IsEqual(component))
            {
                needComponent = currentComponent;
                break;
            }
        }

        if (needComponent is null) return;
        _subDirectoriesAndFiles.Remove(needComponent);
    }

    public bool IsEqual(IFileSystemComponent other)
    {
        if (other is FileFileSystemComponent) return false;

        return Name.IsEqual(other.Name);
    }
}