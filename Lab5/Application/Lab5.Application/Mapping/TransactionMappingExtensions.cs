using Lab5.Application.Contracts.Models;
using Lab5.Domain.Accounts;

namespace Lab5.Application.Mapping;

public static class TransactionMappingExtensions
{
    public static TransactionDto MapToDto(TransactionItem item)
    {
        return new TransactionDto(
            item.Id,
            TransactionTypeMappingExtensions.MapToDto(item.TransactionType),
            item.Amount.Amount,
            item.Time,
            item.ResultBalance.Amount);
    }
}