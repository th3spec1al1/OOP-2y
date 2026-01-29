using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemComponents;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Paths;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.Interfaces;

public interface IFileSystem
{
    DirectoryFileSystemComponent Root { get; }

    DirectoryFileSystemComponent? GetDirectoryByPath(PathObject path);

    FileFileSystemComponent? GetFileByPath(PathObject path);

    FileContentObject? ReadFile(PathObject path);

    CommandExecuteResult MoveFile(PathObject sourcePath, PathObject destDirectoryPath);

    CommandExecuteResult CopyFile(PathObject sourcePath, PathObject destDirectoryPath);

    CommandExecuteResult DeleteFile(PathObject path);

    CommandExecuteResult RenameFile(PathObject sourcePath, ComponentNameObject newName);
}
