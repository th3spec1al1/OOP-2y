using Lab5.Application.Contracts.Accounts;
using Lab5.Application.Contracts.Sessions;
using Lab5.Application.Contracts.Transactions;
using Lab5.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Lab5.Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services)
    {
        services.AddSingleton<IAccountService, AccountService>();
        services.AddSingleton<ISessionService, SessionService>();
        services.AddSingleton<ITransactionService, TransactionService>();

        return services;
    }
}