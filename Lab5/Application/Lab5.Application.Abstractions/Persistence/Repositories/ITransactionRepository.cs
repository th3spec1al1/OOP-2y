using Lab5.Application.Abstractions.Persistence.Queries;
using Lab5.Domain.Accounts;

namespace Lab5.Application.Abstractions.Persistence.Repositories;

public interface ITransactionRepository
{
    void Add(TransactionItem transaction);

    IEnumerable<TransactionItem> Query(TransactionQuery query);
}