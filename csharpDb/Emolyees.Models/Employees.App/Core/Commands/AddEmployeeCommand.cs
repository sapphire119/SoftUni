namespace Employees.App.Core.Commands
{
    using System;
    using Employees.Data;
    using Employees.App.ModelsDto;
    using AutoMapper;
    using Employees.Models;

    public class AddEmployeeCommand
    {
        public string Execute(string[] data)
        {
            if (data.Length != 4)
            {
                throw new InvalidOperationException("Invalid input!");
            }

            using (var context = new EmployeeDbContext())
            {
                var employeeFirstName = data[1];
                var employeeLastName = data[2];
                var isItAValidNumberForSalary = decimal.TryParse(data[3], out decimal salary);

                if (!isItAValidNumberForSalary)
                {
                    throw new ArgumentException("Invalid salary!");
                }

                var employeeDto = new EmployeeDto()
                {
                    FirstName = employeeFirstName,
                    LastName = employeeLastName,
                    Salary = salary
                };

                var employee = Mapper.Map<Employee>(employeeDto);

                context.Employees.Add(employee);

                context.SaveChanges();

                return $"Successfully added {employeeDto.FirstName} with salary {employeeDto.Salary:f2}";
            }
        }
    }
}
