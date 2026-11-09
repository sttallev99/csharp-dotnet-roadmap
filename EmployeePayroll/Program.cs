using EmployeePayroll;

List<Employee> staff =
[
    new Manager("Ana", 4000m, teamSize: 5),
    new Developer("Ivan", 3500m, yearsOfExperience: 3),
    new Employee("Maria", 2000m),
    new Intern("Petar", 1500m),
    new Employee("Georgi")
];

Console.WriteLine($"{"Name",-8}{"Role",-12}{"Pay",10}");
foreach (var e in staff)
    Console.WriteLine($"{e.Name,-8}{e.Role,-12}{e.CalculatePay(),10:N2}");

Console.WriteLine($"Total payroll: {staff.Sum(e => e.CalculatePay()):N2} €");
Console.WriteLine($"Highest paid: {staff.MaxBy(e => e.CalculatePay())!.Name}");
Console.WriteLine($"Managers: {staff.Count(e => e is Manager)}");
