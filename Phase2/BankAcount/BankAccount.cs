using System;
using System.Collections.Generic;
using System.Text;

namespace BankAcount;

public class BankAccount
{
    private static int _lastAccountNumber = 0;
    private readonly List<Transaction> _transactions = new();

    public static int TotalAccounts { get; private set; }
    public string Number { get; }
    public string Owner { get; }
    public decimal Balance { get; private set; }
    public IReadOnlyList<Transaction> History => _transactions;

    public BankAccount(string owner, decimal initialDeposit = 0m)
    {
        if (string.IsNullOrWhiteSpace(owner))
            throw new ArgumentException("Owner is required!");
        if (initialDeposit < 0)
            throw new ArgumentOutOfRangeException(nameof(initialDeposit), "Initial deposit can't be negative.");

        _lastAccountNumber++;
        TotalAccounts++;
        Number = $"ACC-{_lastAccountNumber:D4}";

        Owner = owner.Trim();

        if(initialDeposit > 0)
        {
            Balance = initialDeposit;
            _transactions.Add(new Transaction(initialDeposit, "Initial deposit"));
        }
    }

    public void Deposit(decimal amount)
    {
        if (amount < 0)
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount must be positive.");

        Balance += amount;
        _transactions.Add(new Transaction(amount, "Deposit"));
    }

    public void Withdraw(decimal amount)
    {
        if(amount < 0)
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount must be positive.");
        if(!TryWithdraw(amount))
            throw new InvalidOperationException("Insufficient funds.");

    }

    public bool TryWithdraw(decimal amout)
    {
        if (amout < 0 || amout > Balance)
            return false;

        Balance -= amout;
        _transactions.Add(new Transaction(amout, "Withdrawal"));
        return true;
    }

    public override string ToString() => $"{Number} | {Owner} | {Balance:N2} $";
}

