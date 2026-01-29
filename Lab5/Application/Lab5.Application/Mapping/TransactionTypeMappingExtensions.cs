using Lab5.Application.Contracts.Models;
using Lab5.Domain.Accounts;

namespace Lab5.Application.Mapping;

public static class TransactionTypeMappingExtensions
{
    public static TransactionTypeDto MapToDto(TransactionType type)
    {
        return type switch
        {
            TransactionType.Deposit => TransactionTypeDto.Deposit,
            TransactionType.Withdraw => TransactionTypeDto.Withdraw,
            _ => TransactionTypeDto.Unknown,
        };
    }
}