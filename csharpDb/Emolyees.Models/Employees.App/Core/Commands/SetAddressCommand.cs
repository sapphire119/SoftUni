namespace Employees.App.Core.Commands
{
    using System;
    using System.Linq;
    using Employees.Data;
    using Employees.App.ModelsDto;
    using AutoMapper.QueryableExtensions;
    using System.Text;

    public class SetAddressCommand
    {
        public string Execute(string[] data)
        {
            if (data.Length < 3)
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

                var address = string.Join(" ", data.Skip(2).ToArray());

                var employee = context.Employees.Find(employeeId);

                if (employee == null)
                {
                    throw new ArgumentException($"Employee with Id: {employeeId} doesn't exist!");
                }

                employee.Address = address;

                context.SaveChanges();

                return $"Successfully set the address of {employee.FirstName} to {employee.Address}!";
            }

        }
    }
}
