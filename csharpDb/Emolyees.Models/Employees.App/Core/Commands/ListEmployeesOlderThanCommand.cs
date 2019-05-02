namespace Employees.App.Core.Commands
{
    using AutoMapper.QueryableExtensions;
    using Employees.App.ModelsDto;
    using Employees.Data;
    using System;
    using System.Linq;
    using System.Text;

    public class ListEmployeesOlderThanCommand
    {
        public string Execute(string[] data)
        {
            if (data.Length != 2)
            {
                throw new InvalidOperationException("Invalid input!");
            }

            using (var context = new EmployeeDbContext())
            {
                var isItAValidNumberForAge = int.TryParse(data[1], out int age);

                if (!isItAValidNumberForAge)
                {
                    throw new ArgumentException("Invalid age!");
                }

                var ageInDays = age * 365;

                var listEmployeeDto = context.Employees
                        .Where(e => e.Birthday.HasValue)
                        .Where(e => DateTime.Now.Subtract(e.Birthday.Value).Days > ageInDays)
                        .ProjectTo<ListEmployeeDto>()
                        .OrderByDescending(dto => dto.Salary)
                        .ToArray();

                var sb = new StringBuilder();

                foreach (var employee in listEmployeeDto)
                {
                    var managerLastName = employee.ManagerLastName != null ? 
                            employee.ManagerLastName : "[no manager]";
                    sb.AppendLine($"{employee.FirstName} {employee.LastName} - ${employee.Salary:f2} - Manager: {managerLastName}");
                }

                return sb.ToString();
            }
        }
    }
}
