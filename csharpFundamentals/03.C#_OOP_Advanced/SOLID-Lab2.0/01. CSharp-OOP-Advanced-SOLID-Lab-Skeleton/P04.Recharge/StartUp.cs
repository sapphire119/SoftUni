namespace P04.Recharge
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            Employee employee = new Employee("1");
            Robot robot = new Robot("2", 200);

            ISleeper sleep = robot;

            employee.Work(20);
            employee.Sleep();

            robot.Work(40);
            robot.Recharge();

            Console.WriteLine();
        }
    }
}
