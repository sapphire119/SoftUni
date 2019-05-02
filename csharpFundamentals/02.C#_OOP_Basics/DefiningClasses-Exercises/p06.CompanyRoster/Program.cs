using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        var lines = int.Parse(Console.ReadLine());

        var employees = new List<Employee>();

        for (int count = 0; count < lines; count++)
        {
            var input = Console.ReadLine().Split();

            var personName = input[0];
            var salary = decimal.Parse(input[1]);
            var position = input[2];
            var department = input[3];

            var currentEmployee = new Employee(personName, salary, department, department);

            if (input.Length == 5)
            {
                InsertAgeOrEmail(input[4], currentEmployee);
            }

            if (input.Length == 6)
            {
                InsertAgeOrEmail(input[4], currentEmployee);
                InsertAgeOrEmail(input[5], currentEmployee);
            }

            employees.Add(currentEmployee);
        }


        var groupedEmployees = employees
            .GroupBy(e => e.Department)
            .OrderByDescending(d => d.Average(e => e.Salary))
            .ToList();

        var highestPayingGroup = groupedEmployees.First();
        Console.WriteLine($"Highest Average Salary: {highestPayingGroup.Key}");

        var orderedEmployees = highestPayingGroup.OrderByDescending(e => e.Salary).ToList();
        Console.WriteLine(string.Join(Environment.NewLine,orderedEmployees));

        //var groupedEmployeesByDepartment = employees.GroupBy(e => e.Department).Select(d => new
        //{
        //    DepartmentName = d.Key,
        //    AverageSalary = d.Average(e => e.Salary),
        //    Employees = d.Select(e => new
        //    {
        //        e.Name,
        //        e.Salary,
        //        e.Email,
        //        e.Age
        //    })
        //    .OrderByDescending(e => e.Salary)
        //    .ToList()
        //})
        //.OrderByDescending(d => d.AverageSalary)
        //.ToList();
    }

    private static void InsertAgeOrEmail(string currentInput, Employee currentEmployee)
    {
        var isItAge = int.TryParse(currentInput, out int age);
        if (!isItAge)
        {
            var email = currentInput;
            currentEmployee.Email = email;
        }
        else
        {
            currentEmployee.Age = age;
        }
    }
}

