using PhaseA3_WorkingDays;
using WorkingDays;

HashSet<DateOnly> holidays =
[
    new(2026, 12, 24), new(2026, 12, 25), new(2026, 12, 26), new(2027, 1, 1)
];
var start = new DateOnly(2026, 12, 21);
var inv = System.Globalization.CultureInfo.InvariantCulture;

Console.WriteLine("First 5 working days:");
foreach (var day in Calendar.WorkingDays(start, holidays).Take(5))
    Console.WriteLine($"  {day.ToString("ddd dd.MM.yyyy", inv)}");

var tenth = Calendar.WorkingDays(start, holidays).ElementAt(9);
Console.WriteLine($"10th working day: {tenth.ToString("dddd dd.MM.yyyy", inv)}");

try { var x = Calendar.WorkingDays(start, null!); Console.WriteLine("Not validated yet!"); }
catch (ArgumentNullException ex) { Console.WriteLine($"Error: {ex.Message}"); }