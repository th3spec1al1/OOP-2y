namespace Lab5.Application.Contracts.Sessions.Operations;

public static class CreateUserSession
{
    public sealed record Request(int AccountNumber, int PinCode);

    public abstract record Response
    {
        private Response() { }

        public sealed record Success(Guid SessionId) : Response;

        public sealed record InvalidCredentials : Response;
    }
}