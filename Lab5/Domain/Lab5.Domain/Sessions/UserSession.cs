namespace Lab5.Domain.Sessions;

public class UserSession
{
    public Guid Id { get; }

    public Guid AccountId { get; }

    public UserSession(Guid accountId)
    {
        Id = Guid.NewGuid();
        AccountId = accountId;
    }
}