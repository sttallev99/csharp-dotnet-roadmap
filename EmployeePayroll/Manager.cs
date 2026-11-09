using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeePayroll;

public class Manager: Employee
{
    private const decimal BonusPerTeamMember = 100m;

    public int TeamSize { get; }

    public override string Role => "Manager";

    public Manager(string name, decimal baseSalary, int teamSize) : base(name, baseSalary)
    {
        if (teamSize < 0)
            throw new ArgumentOutOfRangeException(nameof(teamSize), "Team size can't be negative.");

        TeamSize = teamSize;
    }

    public override decimal CalculatePay() =>
        base.CalculatePay() + TeamSize * BonusPerTeamMember;
}
