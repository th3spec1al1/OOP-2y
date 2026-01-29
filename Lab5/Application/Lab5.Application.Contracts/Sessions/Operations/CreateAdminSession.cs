namespace Lab5.Application.Contracts.Sessions.Operations;

public static class CreateAdminSession
{
    public sealed record Request(string SystemPassword);

    public abstract record Response
    {
        private Response() { }

        public sealed record Success(Guid SessionId) : Response;

        public sealed record InvalidPassword : Response;
    }
}