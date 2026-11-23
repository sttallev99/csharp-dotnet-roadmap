using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeePayroll;

public class Developer : Employee
{
    private const decimal BonusPerYear = 150m;

    public int YearsOfExperience { get; }

    public override string Role => "Developer";

    public Developer(string name, decimal baseSalary, int yearsOfExperience)
        : base(name, baseSalary)
    {
        if (yearsOfExperience < 0)
            throw new ArgumentOutOfRangeException(nameof(yearsOfExperience), "Experience can't be negative.");

        YearsOfExperience = yearsOfExperience;
    }

    public override decimal CalculatePay() =>
        base.CalculatePay() + YearsOfExperience * BonusPerYear;
}

