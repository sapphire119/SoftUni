namespace p03.Mankind
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            try
            {
                var studentInput = Console.ReadLine().Split();

                var studentFirstName = studentInput[0];
                var studentLastName = studentInput[1];
                var studentFacultyNumber = studentInput[2];

                var student = new Student(studentFirstName, studentLastName, studentFacultyNumber);

                var workerInput = Console.ReadLine().Split();

                var workerFirstName = workerInput[0];
                var workerLastName = workerInput[1];
                var workerSalary = decimal.Parse(workerInput[2]);
                var workingHours = decimal.Parse(workerInput[3]);

                var worker = new Worker(workerFirstName, workerLastName, workerSalary, workingHours);

                Console.WriteLine(student + Environment.NewLine);
                Console.WriteLine(worker);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
