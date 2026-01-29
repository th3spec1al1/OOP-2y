namespace Lab5.Application.Contracts.Accounts.Operations;

public static class Withdraw
{
    public sealed record Request(Guid SessionId, decimal Amount);

    public abstract record Response
    {
        private Response() { }

        public sealed record Success(decimal NewBalance) : Response;

        public sealed record InvalidSession : Response;

        public sealed record InvalidAmount : Response;
    }
}