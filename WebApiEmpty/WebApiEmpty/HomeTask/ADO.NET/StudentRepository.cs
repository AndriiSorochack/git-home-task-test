using Models;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET
{
    public class StudentRepository : IRepository<Student>
    {
        private readonly UniversityContext context;
        private string connectionString;

        public StudentRepository(string connectionString)
        {
            this.connectionString = connectionString;
            context = new UniversityContext(connectionString);
        }

        //public StudentRepository(string connectionString)
        //{
        //    this.connectionString = connectionString;
        //}

        public Student Create(Student entity)
        {
            context.Database.EnsureCreated();
            context.Students.Add(entity);
            context.SaveChanges();
            return entity;
        }

        public List<Student> GetAll()
        {
            List<Student> Students = context.Students.ToList();
            return Students;
        }

        public Student GetById(int id)
        {
            return context.Students.Find(id);
        }

        public void Remove(int id)
        {
            var student = context.Students.Find(id);
            context.Students.Remove(student);
            context.SaveChanges();
        }

        public void Update(Student entity)
        {
            context.Students.Update(entity);
            context.SaveChanges();
        }
    }
}
