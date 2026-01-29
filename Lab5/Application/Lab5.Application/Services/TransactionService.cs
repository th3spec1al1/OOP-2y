using Lab5.Application.Abstractions.Persistence.Queries;
using Lab5.Application.Abstractions.Persistence.Repositories;
using Lab5.Application.Contracts.Models;
using Lab5.Application.Contracts.Transactions;
using Lab5.Application.Contracts.Transactions.Operations;
using Lab5.Application.Mapping;
using Lab5.Domain.Sessions;

namespace Lab5.Application.Services;

public class TransactionService : ITransactionService
{
    private readonly ISessionRepository _sessionRepository;
    private readonly ITransactionRepository _transactionRepository;

    public TransactionService(ISessionRepository sessionRepository, ITransactionRepository transactionRepository)
    {
        _sessionRepository = sessionRepository;
        _transactionRepository = transactionRepository;
    }

    public GetHistory.Response GetHistory(GetHistory.Request request)
    {
        UserSession? session = _sessionRepository
            .QueryUsers(new SessionQuery([request.SessionId]))
            .SingleOrDefault();

        if (session is null)
            return new GetHistory.Response.InvalidSession();

        var query = new TransactionQuery([session.AccountId]);

        TransactionDto[] transactions = _transactionRepository
            .Query(query).Select(TransactionMappingExtensions.MapToDto).ToArray();

        return new GetHistory.Response.Success(transactions);
    }
}