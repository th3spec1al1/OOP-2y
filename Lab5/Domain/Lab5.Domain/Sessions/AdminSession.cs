namespace Lab5.Domain.Sessions;

public class AdminSession
{
    public Guid Id { get; }

    public AdminSession()
    {
        Id = Guid.NewGuid();
    }
}