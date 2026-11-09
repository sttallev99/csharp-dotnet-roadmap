public class Program
{
    public static void Main(string[] args)
    {
        int.TryParse(Console.ReadLine(), out int totalPages);
        int.TryParse(Console.ReadLine(), out int pagesPerHour);
        int.TryParse(Console.ReadLine(), out int daysAvailable);

        int totalHoursNeeded = totalPages / pagesPerHour;
        double hoursPerDay = (double)totalHoursNeeded / daysAvailable;

        Console.WriteLine($"{hoursPerDay:F2}");
    }
}