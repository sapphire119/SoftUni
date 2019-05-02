using System;
using System.Collections.Generic;
using System.Text;

public class Worker : Human
{
    private const decimal MinSalary = 10M;
    private const decimal MinWorkingHours = 1M;
    private const decimal MaxWorkingHours = 12M;

    private const string InvalidOperationError = "Expected value mismatch! Argument: {0}";

    private const int WorkDaysInAWeek = 5;

    private decimal weekSalary;
    private decimal workHoursPerDay;

    public Worker(string firstName, string lastName, decimal weekSalary, decimal workHoursPerDay) 
        : base(firstName, lastName)
    {
        this.WeekSalary = weekSalary;
        this.WorkHoursPerDay = workHoursPerDay;
    }

    public decimal WorkHoursPerDay
    {
        get
        {
            return this.workHoursPerDay;
        }
        set
        {
            if (!(MinWorkingHours <= value && value <= MaxWorkingHours))
            {
                throw new ArgumentException(string.Format(InvalidOperationError, nameof(workHoursPerDay)));
            }
            this.workHoursPerDay = value;
        }
    }

    public decimal WeekSalary
    {
        get
        {
            return this.weekSalary;
        }
        set
        {
            if (value < MinSalary)
            {
                throw new ArgumentException(string.Format(InvalidOperationError, nameof(weekSalary)));
            }
            this.weekSalary = value;
        }
    }

    public decimal MoneyPerHour => this.CalculateMoneyPerHour();

    private decimal CalculateMoneyPerHour()
    {
        var moneyPerHour = this.WeekSalary / (WorkDaysInAWeek * this.WorkHoursPerDay);
        return moneyPerHour;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(base.ToString())
            .AppendLine($"Week Salary: {this.WeekSalary:F2}")
            .AppendLine($"Hours per day: {this.WorkHoursPerDay:F2}")
            .AppendLine($"Salary per hour: {this.MoneyPerHour:F2}");

        var result = sb.ToString().TrimEnd();
        return result;
    }
}
