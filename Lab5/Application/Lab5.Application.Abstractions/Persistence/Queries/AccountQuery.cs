using Lab5.Domain.ValueObjects;

namespace Lab5.Application.Abstractions.Persistence.Queries;

public record AccountQuery(Guid[] Ids, AccountNumber[] Numbers);