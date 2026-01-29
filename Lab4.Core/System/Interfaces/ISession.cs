using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Paths;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.System.Interfaces;

public interface ISession
{
    IFileSystem? FileSystem { get; }

    PathObject ConnectionPath { get; }

    PathObject LocalPath { get; set; }

    CommandExecuteResult Connect(IFileSystem fileSystem, PathObject connectionPath);

    CommandExecuteResult Disconnect();

    CommandExecuteResult TreeGoTo(PathObject path);
}