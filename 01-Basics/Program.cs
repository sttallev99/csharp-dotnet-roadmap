Console.Write("Enter your name: ");
string? name = Console.ReadLine();
Console.Write("Enter your age: ");
int? age = Convert.ToInt32(Console.ReadLine());

if(age < 18)
{
    Console.WriteLine($"Hello {name} you are too young to vote.");
} else
{
    Console.WriteLine($"Hello {name} you are allowed to vote.");
}

