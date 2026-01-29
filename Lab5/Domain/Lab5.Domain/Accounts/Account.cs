using Lab5.Domain.ResultTypes;
using Lab5.Domain.ValueObjects;

namespace Lab5.Domain.Accounts;

public class Account
{
    public Guid Id { get; }

    public AccountNumber Number { get; }

    public PinCode Pin { get; }

    public Money Balance { get; private set; }

    public Account(AccountNumber number, PinCode pinCode, Money? balance = null)
    {
        Id = Guid.NewGuid();
        Number = number;
        Pin = pinCode;
        Balance = balance ?? Money.Zero;
    }

    public TransactionResult Deposit(Money amount)
    {
        if (amount.Equals(Money.Zero))
            return new TransactionResult.Failure("Cannot deposit zero");

        Balance = Balance.Plus(amount);
        return new TransactionResult.Success(new TransactionItem(Id, TransactionType.Deposit, amount, Balance));
    }

    public TransactionResult Withdraw(Money amount)
    {
        if (amount.Equals(Money.Zero))
            return new TransactionResult.Failure("Cannot withdraw zero");
        if (amount.IsMoreThan(Balance))
            return new TransactionResult.Failure("Insufficient Funds");

        Balance = Balance.Minus(amount);
        return new TransactionResult.Success(new TransactionItem(Id, TransactionType.Withdraw, amount, Balance));
    }

    public bool VerifyPin(PinCode pin)
    {
        return Pin == pin;
    }
}