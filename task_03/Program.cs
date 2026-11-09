public class Program
{
    public static void Main(string[] args)
    {
        decimal.TryParse(Console.ReadLine(), out decimal inches);

        decimal centimeters = inches * 2.54m;

        Console.WriteLine(centimeters);
    }
}