public class Program
{
    public static void Main(string[] args)
    {
        var name = Console.ReadLine();
        int.TryParse(Console.ReadLine(), out int projectsCount);

        int totalHours = projectsCount * 3;
        Console.WriteLine($"{name} will need {totalHours} hours to complete {projectsCount} project(s).");
    }
}
