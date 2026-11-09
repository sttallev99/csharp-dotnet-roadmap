public class Program
{
    public static void Main(string[] args)
    {
        if(double.TryParse(Console.ReadLine(), out double bgnAmount))
        {
            double exchangeRate = 1.79549;
            double usdAmount = bgnAmount * exchangeRate;
            Console.WriteLine(usdAmount);
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }
    }
}