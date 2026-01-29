using Lab5.Application.Contracts.Models;

namespace Lab5.Application.Contracts.Transactions.Operations;

public static class GetHistory
{
    public sealed record Request(Guid SessionId);

    public abstract record Response
    {
        private Response() { }

        public sealed record Success(IEnumerable<TransactionDto> Transactions) : Response;

        public sealed record InvalidSession : Response;
    }
}