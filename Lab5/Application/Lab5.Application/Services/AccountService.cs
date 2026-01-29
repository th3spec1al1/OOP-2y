using Lab5.Application.Abstractions.Persistence.Queries;
using Lab5.Application.Abstractions.Persistence.Repositories;
using Lab5.Application.Contracts.Accounts;
using Lab5.Application.Contracts.Accounts.Operations;
using Lab5.Domain.Accounts;
using Lab5.Domain.ResultTypes;
using Lab5.Domain.Sessions;
using Lab5.Domain.ValueObjects;

namespace Lab5.Application.Services;

public class AccountService : IAccountService
{
    private readonly IAccountRepository _accountRepository;
    private readonly ISessionRepository _sessionRepository;
    private readonly ITransactionRepository _transactionRepository;

    public AccountService(
        IAccountRepository accountRepository,
        ISessionRepository sessionRepository,
        ITransactionRepository transactionRepository)
    {
        _accountRepository = accountRepository;
        _sessionRepository = sessionRepository;
        _transactionRepository = transactionRepository;
    }

    public CreateAccount.Response Create(CreateAccount.Request request)
    {
        var query = new AccountQuery(Ids: [], Numbers: [new AccountNumber(request.AccountNumber)]);

        if (_accountRepository.Query(query).Any())
            return new CreateAccount.Response.AccountAlreadyExists();

        var account = new Account(new AccountNumber(request.AccountNumber), new PinCode(request.PinCode));

        _accountRepository.Add(account);

        return new CreateAccount.Response.Success(account.Id);
    }

    public Deposit.Response Deposit(Deposit.Request request)
    {
        UserSession? session = _sessionRepository
            .QueryUsers(new SessionQuery([request.SessionId]))
            .SingleOrDefault();

        if (session is null)
            return new Deposit.Response.InvalidSession();

        var accountQuery = new AccountQuery(Ids: [session.AccountId], Numbers: []);

        Account account = _accountRepository.Query(accountQuery).Single();

        TransactionResult result = account.Deposit(new Money(request.Amount));

        if (result is TransactionResult.Failure)
            return new Deposit.Response.InvalidAmount();

        var success = (TransactionResult.Success)result;
        _transactionRepository.Add(success.TransactionItem);

        return new Deposit.Response.Success(success.TransactionItem.ResultBalance.Amount);
    }

    public Withdraw.Response Withdraw(Withdraw.Request request)
    {
        UserSession? session = _sessionRepository
            .QueryUsers(new SessionQuery([request.SessionId]))
            .SingleOrDefault();

        if (session is null)
            return new Withdraw.Response.InvalidSession();

        var accountQuery = new AccountQuery(Ids: [session.AccountId], Numbers: []);

        Account account = _accountRepository.Query(accountQuery).Single();

        TransactionResult result = account.Withdraw(new Money(request.Amount));

        if (result is TransactionResult.Failure)
            return new Withdraw.Response.InvalidAmount();

        var success = (TransactionResult.Success)result;
        _transactionRepository.Add(success.TransactionItem);

        return new Withdraw.Response.Success(success.TransactionItem.ResultBalance.Amount);
    }
}