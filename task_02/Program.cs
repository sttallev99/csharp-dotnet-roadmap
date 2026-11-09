public class Program
{
    public static void Main(string[] args)
    {
        int.TryParse(Console.ReadLine(), out int width);
        int.TryParse(Console.ReadLine(), out int height);

        int total = width * height;

        Console.WriteLine(total);
    }
}