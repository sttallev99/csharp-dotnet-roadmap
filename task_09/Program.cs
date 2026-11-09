public class Program
{
    public static void Main(string[] args)
    {
        if(int.TryParse(Console.ReadLine(), out int quareMeters))
        {
            decimal baseServicePrice = 7.61m;
            int discountPercentage = 18;

            decimal basePrice = quareMeters * baseServicePrice;
            decimal discount = basePrice * discountPercentage / 100;
            decimal finalPrice = basePrice - discount;

            Console.WriteLine($"Final price: {finalPrice:F2} currency units.");
            Console.WriteLine($"Discount: {discount:F2} currency units.");
        }
        else
        {
            Console.WriteLine("Wrong square meter value provided.");
        }
    }
}