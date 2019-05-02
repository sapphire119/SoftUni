using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_Hospital
{
    public class Program
    {
        public static void Main()
        {
            var doctors = new List<Doctor>();
            var departments = new List<Department>();

            string hospitalInput;
            while ((hospitalInput = Console.ReadLine()) != "Output")
            {
                string[] tokens = hospitalInput.Split();

                var departmentName = tokens[0];
                var firstName = tokens[1];
                var lastName = tokens[2];
                var pacientName = tokens[3];

                var existingDoctor = doctors.Find(d => d.FirstName == firstName && d.LastName == lastName);
                if (existingDoctor == null)
                {
                    existingDoctor = new Doctor(firstName, lastName);
                    doctors.Add(existingDoctor);
                }

                var existingDepartment = departments.Find(d => d.Name == departmentName);
                if (existingDepartment == null)
                {
                    existingDepartment = new Department(departmentName);
                    departments.Add(existingDepartment);
                }

                var areThereAnyRoomsLeftInDepartment = existingDepartment.Rooms.Sum(r => r.Patients.Count) < 60;
                if (areThereAnyRoomsLeftInDepartment)
                {
                    existingDoctor.Pacients.Add(pacientName);

                    var firstValidRoom = existingDepartment.Rooms.FirstOrDefault(r => r.Patients.Count < 3);
                    firstValidRoom.Patients.Add(pacientName);
                }
            }

            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                PrintOutput(command, departments, doctors);
            }
        }

        private static void PrintOutput(string command, List<Department> departments, List<Doctor> doctors)
        {
            string[] args = command.Split();

            if (args.Length == 1)
            {
                PrintAllPatientsInDepartment(args, departments);
            }
            else if (args.Length == 2 && int.TryParse(args[1], out int room))
            {
                PrintAllPatientsInCurrentRoom(args, departments);
            }
            else
            {
                PrintHealedPatients(args, doctors);
            }
        }

        private static void PrintHealedPatients(string[] args, List<Doctor> doctors)
        {
            var doctorFirstName = args[0];
            var doctorLastName = args[1];

            var healedPatients = doctors
                    .Find(d => d.FirstName == doctorFirstName && d.LastName == doctorLastName)
                    .Pacients
                    .OrderBy(p => p)
                    .ToArray();

            Console.WriteLine(string.Join("\n", healedPatients));

        }

        private static void PrintAllPatientsInCurrentRoom(string[] args, List<Department> departments)
        {
            var departmentName = args[0];
            var roomInput = args[1];
            var isRoomNumberValid = int.TryParse(roomInput, out int roomNumber);
            if (isRoomNumberValid)
            {
                var allPatientsInCurrentRoom = departments
                    .Find(d => d.Name == departmentName)
                    .Rooms[roomNumber - 1]
                    .Patients
                    .OrderBy(p => p)
                    .ToArray();

                Console.WriteLine(string.Join("\n", allPatientsInCurrentRoom));
            }
        }

        private static void PrintAllPatientsInDepartment(string[] args, List<Department> departments)
        {
            var departmentName = args[0];

            var patientsInDepartment = departments
                    .Find(d => d.Name == departmentName)
                    .Rooms
                    .Where(r => r.Patients.Count > 0)
                    .SelectMany(p => p.Patients)
                    .ToArray();

            Console.WriteLine(string.Join("\n", patientsInDepartment));
        }
    }
}
