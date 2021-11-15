using System;
using Microsoft.Extensions.Configuration;
using Models;
using Models.Models;
using ADO.NET.EF;

namespace ADO.NET
{
    class Program
    {
        // Student TASK
        // Update the connection string located in appSettings.json file
        // Make the program to execute without exceptions.
        // Check that the results are correct in DB.

        private static string _connectionString;
        static void Main(string[] args)
        {
            //ConfigurationBuilder builder = new ConfigurationBuilder();
            //builder.AddJsonFile($"appsettings.json", true, true);
            //var configuration = builder.Build();
            //string connectionString = configuration.GetConnectionString("DefaultConnection");
            ////SetConnectionString();
            //using UniversityContext context = new();
            //IRepository<Course> courseRepository = new CourseRepository(context);
            //Course newCourse = new Course() { StartDate = DateTime.Now, EndDate = DateTime.Now, PassCredits = 500 };

            //var course = courseRepository.Create(newCourse);
            //course.PassCredits = 1000;

            //courseRepository.Update(course);

            //IRepository<Student> studentRepository = GetStudentRepository();
            //Student newStudent = new Student()
            //{
            //    BirthDate = DateTime.Now,
            //    Email = "Test",
            //    GitHubLink = "Test",
            //    Name = "test",
            //    PhoneNumber = "000"
            //};

            //var insertedStudent = studentRepository.Create(newStudent);
            ////studentRepository.Update(insertedStudent);
            ////studentRepository.Remove(1);
            //insertedStudent.Notes += "; Is employed";
            //insertedStudent.Courses.Add(course);

            //studentRepository.Update(insertedStudent);
            //studentRepository.Remove(insertedStudent.Id);
            //courseRepository.Remove(course.Id);
        }

        //private static IRepository<Student> GetStudentRepository()
        //{
        //    using UniversityContext context = new();
        //    return new StudentRepository(context);
        //}
    }
}