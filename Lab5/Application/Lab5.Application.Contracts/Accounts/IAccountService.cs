using Lab5.Application.Contracts.Accounts.Operations;

namespace Lab5.Application.Contracts.Accounts;

public interface IAccountService
{
    CreateAccount.Response Create(CreateAccount.Request request);

    Deposit.Response Deposit(Deposit.Request request);

    Withdraw.Response Withdraw(Withdraw.Request request);
}