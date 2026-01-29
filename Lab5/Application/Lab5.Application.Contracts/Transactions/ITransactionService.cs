using Lab5.Application.Contracts.Transactions.Operations;

namespace Lab5.Application.Contracts.Transactions;

public interface ITransactionService
{
    GetHistory.Response GetHistory(GetHistory.Request request);
}