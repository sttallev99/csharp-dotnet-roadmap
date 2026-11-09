public class Program
{
    public static void Main(string[] args)
    {
        var firstName = Console.ReadLine();
        var lastName = Console.ReadLine();
        int.TryParse(Console.ReadLine(), out int age);
        var city = Console.ReadLine();

        Console.WriteLine($"You are {firstName} {lastName}, a {age}-years old person from {city}.");
    }
}