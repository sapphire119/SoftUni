using System;
using P01_StudentSystem.Data.Models;

namespace P01_StudentSystem.Data
{ 
    class StartUp
    {
        static void Main(string[] args)
        {
            using (var context = new StudentSystemContext())
            {
                ResetDatabase(context);
            }
        }

        private static void ResetDatabase(StudentSystemContext context)
        {
            //context.Database.EnsureDeleted();

            //context.Database.EnsureCreated();

            Seed(context);
        }

        private static void Seed(StudentSystemContext context)
        {
            var students = new[]
            {
                new Student() { Birthday = new DateTime(1994,10,4), Name = "Pesho", PhoneNumber = "+35921635123", RegisteredOn = new DateTime(2010,12,10) },
                new Student() { Birthday = new DateTime(2001,11,20), Name = "Ivan", PhoneNumber = "+35921642123", RegisteredOn = new DateTime(2007,12,10) },
                new Student() { Birthday = new DateTime(2004,04,14), Name = "Maria", PhoneNumber = "+35921675623", RegisteredOn = new DateTime(2004,04,10) },
                new Student() { Birthday = new DateTime(1999,05,30), Name = "Karina", PhoneNumber = "+35921889923", RegisteredOn = new DateTime(2000,10,21) },
            };

            context.Students.AddRange(students);

            var courses = new[]
            {
                new Course() { StartDate = new DateTime(1999,09,11), Name = "Learn Java", Price = 250, EndDate = new DateTime(2020,02,20)},
                new Course() { StartDate = new DateTime(2011,04,21), Name = "Learn C#", Price = 325, EndDate = new DateTime(2040,02,20)},
                new Course() { StartDate = new DateTime(2001,11,02), Name = "Learn C++", Price = 500, EndDate = new DateTime(3020,02,20)},
                new Course() { StartDate = new DateTime(2016,07,30), Name = "Learn Software Development", Price = 1500, EndDate = new DateTime(2021,02,20)},
            };

            context.Courses.AddRange(courses);

            var resources = new[]
            {
                new Resource() { Name = "Book on Java", Course = courses[0], ResourceType = ResourceType.Document, Url = "www.learnJava.com"},
                new Resource() { Name = "Book on C#", Course = courses[1], ResourceType = ResourceType.Document, Url = "www.Nakovsbooks.com"},
                new Resource() { Name = "Learn to Code with C++", Course = courses[2], ResourceType = ResourceType.Document, Url = "www.getgudWithCplusplus.com"},
                new Resource() { Name = "Learn Programming", Course = courses[3], ResourceType = ResourceType.Document, Url = "www.getMoreGud.com"},
            };

            context.Resources.AddRange(resources);

            var homeworkSubmissions = new[]
            {
                new Homework() { Content = "No more sorrow", ContentType = ContentType.Application, Course = courses[1], SubmissionTime = new DateTime(2010,04,10) },
                new Homework() { Content = "Contains all tasks", ContentType = ContentType.Pdf, Course = courses[0], SubmissionTime = new DateTime(2010,04,10) },
                new Homework() { Content = "I kill for you", ContentType = ContentType.Application, Course = courses[2], SubmissionTime = new DateTime(2004,04,10) },
                new Homework() { Content = "No more sorrow", ContentType = ContentType.Pdf, Course = courses[3], SubmissionTime = new DateTime(2017,07,10) },
            };

            context.HomeworkSubmissions.AddRange(homeworkSubmissions);

            var studentCourses = new[]
            {
                new StudentCourse() { Student = students[0], Course = courses[0]},
                new StudentCourse() { Student = students[2], Course = courses[1]},
                new StudentCourse() { Student = students[1], Course = courses[3]},
                new StudentCourse() { Student = students[3], Course = courses[2]},
            };

            context.StudentCourses.AddRange(studentCourses);

            context.SaveChanges();
        }
    }
}
