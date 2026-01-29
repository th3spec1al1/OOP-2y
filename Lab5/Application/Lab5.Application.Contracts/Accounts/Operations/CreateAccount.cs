namespace Lab5.Application.Contracts.Accounts.Operations;

public static class CreateAccount
{
    public sealed record Request(int AccountNumber, int PinCode);

    public abstract record Response
    {
        private Response() { }

        public sealed record Success(Guid AccountId) : Response;

        public sealed record AccountAlreadyExists : Response;
    }
}