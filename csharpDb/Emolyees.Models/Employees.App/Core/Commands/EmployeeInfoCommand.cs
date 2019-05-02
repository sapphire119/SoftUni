namespace Employees.App.Core.Commands
{
    using System;
    using System.Text;
    using System.Linq;
    using Employees.Data;
    using AutoMapper.QueryableExtensions;
    using Employees.App.ModelsDto;

    public class EmployeeInfoCommand
    {
        public string Execute(string[] data)
        {
            if (data.Length != 2)
            {
                throw new InvalidOperationException("Invalid input!");
            }

            using (var context = new EmployeeDbContext())
            {
                var isEmployeeIdValid = int.TryParse(data[1], out int employeeId);

                if (!isEmployeeIdValid)
                {
                    throw new ArgumentException("Employee Id not valid!");
                }

                var employeeDto = context.Employees
                        .Where(e => e.Id == employeeId)
                        .ProjectTo<EmployeeDto>()
                        .SingleOrDefault();

                if (employeeDto == null)
                {
                    throw new ArgumentException($"Employee with ID {employeeId} doesn't exist!");
                }

                var sb = new StringBuilder();

                sb.AppendLine($"ID:{employeeDto.Id} - {employeeDto.FirstName} {employeeDto.LastName} - ${employeeDto.Salary:f2}");

                return sb.ToString();
            }
        }
    }
}
