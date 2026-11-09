public class Program
{
    public static void Main(string[] args)
    {
        if(decimal.TryParse(Console.ReadLine(), out decimal radians))
        {
            decimal degrees = radians * (180 / (decimal)Math.PI);
            Console.WriteLine($"{degrees:F0}");
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }
    }
}