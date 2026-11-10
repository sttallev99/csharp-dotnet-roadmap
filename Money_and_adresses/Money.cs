using System;
using System.Collections.Generic;
using System.Text;

namespace Money_and_adresses;

public readonly record struct Money(decimal Amount, string Currency)
{
    public string Currency { get; init; } = !string.IsNullOrWhiteSpace(Currency)
        ? Currency.Trim().ToUpperInvariant()
        : throw new ArgumentException("Currency is required");

    public static Money Euro(decimal amount) => new Money(amount, "EUR");

    public static Money operator +(Money a, Money b)
    {
        EnsureSameCurrency(a, b);
        return a with { Amount = a.Amount + b.Amount };
    }

    public static Money operator -(Money a, Money b)
    {
        EnsureSameCurrency(a, b);
        return a with { Amount = a.Amount - b.Amount };
    }

    public static Money operator *(Money m, int quantity) => m with { Amount = m.Amount * quantity };
    public static Money operator *(int quantity, Money m) => m with { Amount = quantity * m.Amount };

    public static bool operator >(Money a, Money b)
    {
        EnsureSameCurrency(a, b);
        return a.Amount > b.Amount;
    }
    public static bool operator <(Money a, Money b)
    {
        EnsureSameCurrency(a, b);
        return a.Amount < b.Amount;
    }

    private static void EnsureSameCurrency(Money a, Money b)
    {
        if(a.Currency != b.Currency)
        {
            throw new InvalidOperationException($"Can't mix {a.Currency} and {b.Currency}.");
        }
    }

    public override string ToString() => $"{Amount:N2} {Currency}";
}

