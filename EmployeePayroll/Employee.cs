using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeePayroll;

public class Employee
{
    public string Name { get; }
    public decimal BaseSalary { get; }
    public virtual string Role => "Employee";

    public Employee(string name, decimal baseSalary)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Name cannot be null or whitespace.", nameof(name));
        }
        if (baseSalary < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(baseSalary), "Salary can't be negative.");
        }

        Name = name.Trim();
        BaseSalary = baseSalary;
    }

    public Employee(string name): this(name, 1000m)
    {

    }

    public virtual decimal CalculatePay() => BaseSalary;

    public override string ToString() => $"{Name} ({Role}): {CalculatePay():N2} €";

}
