using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemComponents;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemComponents.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Paths;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;

public class LocalFileSystem : IFileSystem
{
    public DirectoryFileSystemComponent Root { get; }

    public LocalFileSystem(DirectoryFileSystemComponent? root = null)
    {
        Root = root ?? new DirectoryFileSystemComponent(new ComponentNameObject("root"));
    }

    public DirectoryFileSystemComponent? GetDirectoryByPath(PathObject path)
    {
        if (path.Value.Count == 0) return Root;

        IReadOnlyList<ComponentNameObject> processedPath = path.Value;
        DirectoryFileSystemComponent currentComponent = Root;

        foreach (ComponentNameObject currentName in processedPath)
        {
            bool found = false;
            foreach (IFileSystemComponent currentSubComponent in currentComponent.Components)
            {
                if (currentSubComponent is DirectoryFileSystemComponent currentDirectory
                    && currentDirectory.Name.IsEqual(currentName))
                {
                    found = true;
                    currentComponent = currentDirectory;
                    break;
                }
            }

            if (!found) return null;
        }

        return currentComponent;
    }

    public FileFileSystemComponent? GetFileByPath(PathObject path)
    {
        PathObject parentPath = path.GetParentPath();
        DirectoryFileSystemComponent? parentDirectory = GetDirectoryByPath(parentPath);
        if (parentDirectory is null) return null;

        foreach (IFileSystemComponent currentComponent in parentDirectory.Components)
        {
            if (currentComponent is FileFileSystemComponent currentFile)
            {
                if (currentFile.Name.IsEqual(path.Value[^1])) return currentFile;
            }
        }

        return null;
    }

    public FileContentObject? ReadFile(PathObject path)
    {
        FileFileSystemComponent? file = GetFileByPath(path);
        if (file is null) return null;

        return file.Content;
    }

    public CommandExecuteResult MoveFile(PathObject sourcePath, PathObject destDirectoryPath)
    {
        CommandExecuteResult result = CopyFile(sourcePath, destDirectoryPath);
        if (result is CommandExecuteResult.Failure failureResult) return failureResult;

        result = DeleteFile(sourcePath);
        return result;
    }

    public CommandExecuteResult CopyFile(PathObject sourcePath, PathObject destDirectoryPath)
    {
        FileFileSystemComponent? file = GetFileByPath(sourcePath);
        if (file is null) return new CommandExecuteResult.Failure("There is no file at this path");

        DirectoryFileSystemComponent? parentDirectory = GetDirectoryByPath(destDirectoryPath);
        if (parentDirectory is null) return new CommandExecuteResult.Failure("There is no directory at this path");

        parentDirectory.Add(file.Copy());
        return new CommandExecuteResult.Success();
    }

    public CommandExecuteResult DeleteFile(PathObject path)
    {
        PathObject parentPath = path.GetParentPath();
        DirectoryFileSystemComponent? parentDirectory = GetDirectoryByPath(parentPath);
        if (parentDirectory is null) return new CommandExecuteResult.Failure("There is no parent dir at this path");

        FileFileSystemComponent? file = GetFileByPath(path);
        if (file is null) return new CommandExecuteResult.Failure("There is no file at this path");

        parentDirectory.DeleteComponent(file);
        return new CommandExecuteResult.Success();
    }

    public CommandExecuteResult RenameFile(PathObject sourcePath, ComponentNameObject newName)
    {
        FileFileSystemComponent? file = GetFileByPath(sourcePath);
        if (file == null)
            return new CommandExecuteResult.Failure("There is no file at this path");

        file.Rename(newName);
        return new CommandExecuteResult.Success();
    }
}