using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemComponents;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Paths;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.System.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.System;

public class Session : ISession
{
    public IFileSystem? FileSystem { get; private set; }

    public PathObject ConnectionPath { get; private set; } = new PathObject();

    public PathObject LocalPath { get; set; } = new PathObject();

    public CommandExecuteResult Connect(IFileSystem fileSystem, PathObject connectionPath)
    {
        if (fileSystem.GetDirectoryByPath(connectionPath) is null)
            return new CommandExecuteResult.Failure("Connection path not found");

        FileSystem = fileSystem;
        ConnectionPath = connectionPath;
        return new CommandExecuteResult.Success();
    }

    public CommandExecuteResult Disconnect()
    {
        FileSystem = null;
        ConnectionPath = new PathObject();
        LocalPath = new PathObject();
        return new CommandExecuteResult.Success();
    }

    public CommandExecuteResult TreeGoTo(PathObject path)
    {
        if (FileSystem is null)
            return new CommandExecuteResult.Failure("The session is not connected to the file system.");

        DirectoryFileSystemComponent? directory = FileSystem.GetDirectoryByPath(path);
        if (directory is null)
            return new CommandExecuteResult.Failure("Not found directory at this path");

        LocalPath = path;
        return new CommandExecuteResult.Success();
    }
}