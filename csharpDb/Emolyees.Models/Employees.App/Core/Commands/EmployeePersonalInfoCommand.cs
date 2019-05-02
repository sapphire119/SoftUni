namespace Employees.App.Core.Commands
{
    using AutoMapper.QueryableExtensions;
    using Employees.App.ModelsDto;
    using Employees.Data;
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class EmployeePersonalInfoCommand
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

                var employeeInfoDto = context.Employees
                        .Where(e => e.Id == employeeId)
                        .ProjectTo<EmployeeInfoDto>()
                        .SingleOrDefault();

                if (employeeInfoDto == null)
                {
                    throw new ArgumentException($"Employee with ID {employeeId} doesn't exist!");
                }

                var sb = new StringBuilder();

                sb.AppendLine($"ID:{employeeInfoDto.Id} - {employeeInfoDto.FirstName} {employeeInfoDto.LastName} - ${employeeInfoDto.Salary:f2}");

                var date = employeeInfoDto.Birthday != null ? employeeInfoDto.Birthday.Value
                    .ToString(@"dd-MM-yyyy", CultureInfo.InvariantCulture) : "No entry for birthday";

                sb.AppendLine($"Birthday: {date}");

                var address = employeeInfoDto.Address != null ? employeeInfoDto.Address : "No entry for address";
                sb.AppendLine($"Address: {address}");

                return sb.ToString();
            }

        }
    }
}
