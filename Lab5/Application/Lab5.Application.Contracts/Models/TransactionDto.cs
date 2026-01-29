namespace Lab5.Application.Contracts.Models;

public record TransactionDto(Guid Id, TransactionTypeDto Type, decimal Amount, DateTime Date, decimal ResultBalance);