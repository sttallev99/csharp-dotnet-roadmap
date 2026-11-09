public class Program
{
    public static void Main(string[] args)
    {
        decimal basePrice = 7.61m;
        int discauntPercentage = 18;
        int.TryParse(Console.ReadLine(), out int squareMeters);

        decimal finalPrice = basePrice * squareMeters;
        decimal discaunt = finalPrice * discauntPercentage / 100;

        Console.WriteLine($"Final price: {finalPrice - discaunt:F2} currency units.");
        Console.WriteLine($"Discount: {discaunt:F2} currency units.");
    }
}