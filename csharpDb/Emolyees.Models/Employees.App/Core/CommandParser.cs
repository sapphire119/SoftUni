namespace Employees.App
{
    using System;
    using Employees.App.Core.Commands;

    public class CommandParser
    {
        public string ParseCommand(string[] data)
        {
            var command = data[0];

            switch (command)
            {
                case "AddEmployee": return new AddEmployeeCommand().Execute(data);
                case "SetBirthday": return new SetBirthdayCommand().Execute(data);
                case "SetAddress": return new SetAddressCommand().Execute(data);
                case "EmployeeInfo": return new EmployeeInfoCommand().Execute(data);   
                case "EmployeePersonalInfo": return new EmployeePersonalInfoCommand().Execute(data);
                case "SetManager": return new SetManagerCommand().Execute(data);
                case "ManagerInfo": return new ManagerInfoCommand().Execute(data);
                case "ListEmployeesOlderThan": return new ListEmployeesOlderThanCommand().Execute(data);
                case "Exit": return new ExitCommand().Execute();
                default:
                    throw new ArgumentException("Invalid command!");
            }
        }
    }
}