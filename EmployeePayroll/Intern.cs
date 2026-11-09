using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeePayroll;

public sealed class Intern : Employee
{
    public override string Role => "Intern";

    public Intern(string name, decimal baseSalary)
        : base(name, baseSalary)
    {
    }

    public override decimal CalculatePay() => base.CalculatePay() * 0.5m;
}
