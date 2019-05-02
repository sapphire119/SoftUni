namespace Employees.App.Core.Commands
{
    using AutoMapper.QueryableExtensions;
    using Employees.App.ModelsDto;
    using Employees.Data;
    using System;
    using System.Linq;

    public class SetManagerCommand
    {
        public string Execute(string[] data)
        {
            if (data.Length != 3)
            {
                throw new InvalidOperationException("Invalid input!");
            }

            using (var context = new EmployeeDbContext())
            {
                var isItAValidNumberForEmployeeId = int.TryParse(data[1], out int employeeId);
                var isItAValidNumberForManagerId = int.TryParse(data[2], out int managerId);

                if (!isItAValidNumberForEmployeeId || !isItAValidNumberForManagerId)
                {
                    throw new ArgumentException("Invalid values for employee or manager Id!");
                }

                var employee = context.Employees.Find(employeeId);

                if (employee == null)
                {
                    throw new ArgumentException($"Employee with Id:{employeeId} doesn't exist!");
                }

                var manager = context.Employees.Find(managerId);

                if (manager == null)
                {
                    throw new ArgumentException($"Manager with Id:{managerId} doesn't exist!");
                }

                employee.ManagerId = managerId;

                context.SaveChanges();

                return $"Successfully added manager: " +
                    $"{manager.FirstName + ' ' + manager.LastName} with ID:{manager.Id} " 
                    + Environment.NewLine +
                    $"to employee {employee.FirstName + ' ' + employee.LastName} with ID:{employee.Id}!";
            }
        }
    }
}
