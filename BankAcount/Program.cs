using BankAcount;

var ana = new BankAccount("Ana", 100m);
var ivan = new BankAccount("Ivan");

ana.Deposit(50m);
ana.Withdraw(30m);
bool ok = ivan.TryWithdraw(20m);

Console.WriteLine(ana);
Console.WriteLine(ivan);
Console.WriteLine($"Ivan withdrew: {ok}");
Console.WriteLine($"Total accounts: {BankAccount.TotalAccounts}");

Console.WriteLine("Ana's history:");
foreach (var t in ana.History)
    Console.WriteLine($"  {t.Amount,8:+0.00;-0.00}  {t.Description}");

try { ana.Withdraw(500m); }
catch (InvalidOperationException ex) { Console.WriteLine($"Error: {ex.Message}"); }

try { ana.Deposit(-5m); }
catch (ArgumentOutOfRangeException) { Console.WriteLine("Error: Amount must be positive."); }

try { new BankAccount(""); }
catch (ArgumentException ex) { Console.WriteLine($"Error: {ex.Message}"); }