namespace Itmo.ObjectOrientedProgramming.Lab2.Formatting;

public class FileFormatter : IMessageFormatter
{
    private readonly string _filePath;

    public FileFormatter(string filePath)
    {
        _filePath = filePath;
    }

    public void WriteHeader(string header)
    {
        File.AppendAllText(_filePath, $"{header}\n");
    }

    public void WriteBody(string body)
    {
        File.AppendAllText(_filePath, $"{body}\n");
    }
}