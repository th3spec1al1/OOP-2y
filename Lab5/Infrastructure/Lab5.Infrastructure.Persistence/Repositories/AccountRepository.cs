using Lab5.Application.Abstractions.Persistence.Queries;
using Lab5.Application.Abstractions.Persistence.Repositories;
using Lab5.Domain.Accounts;

namespace Lab5.Infrastructure.Persistence.Repositories;

public class AccountRepository : IAccountRepository
{
    private readonly Dictionary<Guid, Account> _accounts = [];

    public void Add(Account account)
    {
        _accounts.Add(account.Id, account);
    }

    public IEnumerable<Account> Query(AccountQuery query)
    {
        IEnumerable<Account> result = _accounts.Values;

        if (query.Ids.Length > 0)
        {
            result = result.Where(a => query.Ids.Contains(a.Id));
        }

        if (query.Numbers.Length > 0)
        {
            result = result.Where(a => query.Numbers.Contains(a.Number));
        }

        return result;
    }
}