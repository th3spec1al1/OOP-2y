using Lab5.Application.Abstractions.Persistence.Queries;
using Lab5.Application.Abstractions.Persistence.Repositories;
using Lab5.Application.Contracts.Sessions;
using Lab5.Application.Contracts.Sessions.Operations;
using Lab5.Domain.Accounts;
using Lab5.Domain.Sessions;
using Lab5.Domain.ValueObjects;

namespace Lab5.Application.Services;

public class SessionService : ISessionService
{
    private const string AdminPassword = "admin";

    private readonly IAccountRepository _accountRepository;
    private readonly ISessionRepository _sessionRepository;

    public SessionService(IAccountRepository accountRepository, ISessionRepository sessionRepository)
    {
        _accountRepository = accountRepository;
        _sessionRepository = sessionRepository;
    }

    public CreateUserSession.Response CreateUserSession(CreateUserSession.Request request)
    {
        var query = new AccountQuery(Ids: [], Numbers: [new AccountNumber(request.AccountNumber)]);

        Account? account = _accountRepository.Query(query).SingleOrDefault();

        if (account is null)
            return new CreateUserSession.Response.InvalidCredentials();

        var pinCode = new PinCode(request.PinCode);
        if (!account.VerifyPin(pinCode))
            return new CreateUserSession.Response.InvalidCredentials();

        var session = new UserSession(account.Id);

        _sessionRepository.AddUser(session);

        return new CreateUserSession.Response.Success(session.Id);
    }

    public CreateAdminSession.Response CreateAdminSession(CreateAdminSession.Request request)
    {
        if (request.SystemPassword != AdminPassword)
            return new CreateAdminSession.Response.InvalidPassword();

        var session = new AdminSession();

        _sessionRepository.AddAdmin(session);

        return new CreateAdminSession.Response.Success(session.Id);
    }
}