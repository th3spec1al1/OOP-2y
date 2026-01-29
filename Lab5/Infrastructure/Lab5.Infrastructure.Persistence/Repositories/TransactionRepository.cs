using Lab5.Application.Abstractions.Persistence.Queries;
using Lab5.Application.Abstractions.Persistence.Repositories;
using Lab5.Domain.Accounts;

namespace Lab5.Infrastructure.Persistence.Repositories;

public class TransactionRepository : ITransactionRepository
{
    private readonly List<TransactionItem> _transactions = [];

    public void Add(TransactionItem transaction)
    {
        _transactions.Add(transaction);
    }

    public IEnumerable<TransactionItem> Query(TransactionQuery query)
    {
        return _transactions.Where(t => query.AccountIds.Contains(t.AccountId));
    }
}