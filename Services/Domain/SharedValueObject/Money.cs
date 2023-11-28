public class Money
{
    public decimal Amount { get; }
    public Money(decimal amount)
    {
        if (amount < 0) throw new InvalidOperationException("Money cannot be negative.");
        Amount = amount;
    }

    public static Money operator -(Money left, Money right)
    => new Money(left.Amount - right.Amount);

    public static Money operator +(Money left, Money right)
    => new Money(left.Amount + right.Amount);

    public static bool operator <(Money left, Money right)
    => left.Amount < right.Amount;

    public static bool operator >(Money left, Money right)
    => left.Amount > right.Amount;

    public static bool operator <=(Money left, Money right)
    => left.Amount <= right.Amount;

    public static bool operator >=(Money left, Money right)
    => left.Amount >= right.Amount;

    public static implicit operator Money(decimal amount)
    => new Money(amount);

}