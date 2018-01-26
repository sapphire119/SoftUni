namespace Employees.App.Core.Commands
{
    using AutoMapper.QueryableExtensions;
    using Employees.App.ModelsDto;
    using Employees.Data;
    using System;
    using System.Linq;
    using System.Text;

    public class ManagerInfoCommand
    {
        public string Execute(string[] data)
        {
            if (data.Length != 2)
            {
                throw new InvalidOperationException("Invalid input!");
            }

            using (var context = new EmployeeDbContext())
            {
                var isItAValidNumberForEmployeeId = int.TryParse(data[1],out int managerId);

                if (!isItAValidNumberForEmployeeId)
                {
                    throw new ArgumentException("Invalid values for manager Id!");
                }

                var managerDto = context.Employees
                        .Where(m => m.Id == managerId)
                        .ProjectTo<ManagerDto>()
                        .SingleOrDefault();

                if (managerDto == null)
                {
                    throw new ArgumentException($"Manager with Id: {managerId} doesn't exist!");
                }

                var sb = new StringBuilder();

                sb.AppendLine($"{managerDto.FirstName} {managerDto.LastName} | Employees: {managerDto.EmployeeCount}");

                if (managerDto.Employees.Any())
                {
                    foreach (var employeeDto in managerDto.Employees)
                    {
                        sb.AppendLine($"    - {employeeDto.FirstName} {employeeDto.LastName} - ${employeeDto.Salary:f2}");
                    } 
                }
                else
                {
                    sb.AppendLine("No assigned employees");
                }

                return sb.ToString();
            }
        }
    }
}
