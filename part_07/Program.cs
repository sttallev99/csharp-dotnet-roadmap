public class Program
{
    public static void Main(string[] args)
    {
        int.TryParse(Console.ReadLine(), out int dogFoodPackages);
        int.TryParse(Console.ReadLine(), out int catFoodPackages);
        decimal DOG_FOOD_PRICE = 2.50m;
        decimal CAT_FOOD_PRICE = 4.00m;

        decimal totalCost = (dogFoodPackages * DOG_FOOD_PRICE) + (catFoodPackages * CAT_FOOD_PRICE);

        Console.WriteLine($"{totalCost:F1}  currency units.");
    }
}