using Models;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET.EF
{
    public class CourseRepository : IRepository<Course>
    {
        private readonly UniversityContext context;
        private string connectionString;

        //public CourseRepository(UniversityContext context)
        //{
        //    this.context = context;
        //    this.context.Database.EnsureCreated();
        //}

        public CourseRepository(string connectionString)
        {
            this.connectionString = connectionString;
            context = new UniversityContext(connectionString);
        }

        public Course Create(Course entity)
        {
            context.Database.EnsureCreated();
            context.Courses.Add(entity);
            context.SaveChanges();
            return entity;
        }

        public List<Course> GetAll()
        {
            List<Course> Courses = context.Courses.ToList();
            return Courses;
        }

        public Course GetById(int id)
        {
            return context.Courses.Find(id);
        }

        public void Remove(int id)
        {
            var course = context.Courses.Find(id);
            context.Courses.Remove(course);
            context.SaveChanges();
        }

        public void Update(Course entity)
        {
            context.Courses.Update(entity);
            context.SaveChanges();
        }
    }
}
