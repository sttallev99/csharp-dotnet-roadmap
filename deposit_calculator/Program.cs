public class Program
{
    public static void Main(string[] args)
    {
        decimal.TryParse(Console.ReadLine(), out decimal balance);
        int.TryParse(Console.ReadLine(), out int months);
        double.TryParse(Console.ReadLine(), out double percentage);

        decimal montlyInterests = balance * ((decimal)percentage / 100) / 12;
        decimal finalBalance = balance + months * montlyInterests;

        Console.WriteLine(finalBalance);
    }
}