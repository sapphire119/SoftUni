namespace Employees.App.Core.Commands
{
    using System;
    using Employees.Data;
    using System.Globalization;

    public class SetBirthdayCommand
    {
        public string Execute(string[] data)
        {
            if (data.Length != 3)
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

                var dayMonthYear = data[2].Split('-');

                var isDayValid = int.TryParse(dayMonthYear[0], out int day);
                var isMonthValid = int.TryParse(dayMonthYear[1], out int month);
                var isYearValid = int.TryParse(dayMonthYear[2], out int year);

                if (!isDayValid || !isMonthValid || !isYearValid)
                {
                    throw new ArgumentException("Invalid date!");
                }

                var employee = context.Employees.Find(employeeId);

                if (employee == null)
                {
                    throw new ArgumentException($"Employee with Id: {employeeId} doesn't exist!");
                }

                var birthday = new DateTime();

                try
                {
                    birthday = new DateTime(year, month, day);
                }
                catch (Exception)
                {
                    throw new ArgumentException("Invalid entries for day, month or year!");
                }

                employee.Birthday = birthday;

                context.SaveChanges();

                var birthdayDate = employee.Birthday.Value.ToString("dd-MMM-yyyy",CultureInfo.InvariantCulture);

                return $"Successfully set the birthdate of {employee.FirstName} to {birthdayDate}!";
            }
        }
    }
}
