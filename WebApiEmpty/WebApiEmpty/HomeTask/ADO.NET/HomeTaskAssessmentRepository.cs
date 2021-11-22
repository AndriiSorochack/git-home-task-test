using Models;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET
{
    public class HomeTaskAssessmentRepository : IRepository<HomeTaskAssessment>
    {
        private readonly UniversityContext context;
        private string connectionString;

        public HomeTaskAssessmentRepository(string connectionString)
        {
            this.connectionString = connectionString;
            context = new UniversityContext(connectionString);
            context.Database.EnsureCreated();
        }

        public HomeTaskAssessment Create(HomeTaskAssessment entity)
        {
            context.Database.EnsureCreated();
            context.Assessments.Add(entity);
            context.SaveChanges();
            return entity;
        }

        public List<HomeTaskAssessment> GetAll()
        {
            List<HomeTaskAssessment> assessments = context.Assessments.ToList();
            return assessments;
        }

        public HomeTaskAssessment GetById(int id)
        {
            return context.Assessments.Find(id);
        }

        public void Remove(int id)
        {
            var assessment = context.Assessments.Find(id);
            context.Assessments.Remove(assessment);
            context.SaveChanges();
        }

        public void Update(HomeTaskAssessment entity)
        {
            context.Assessments.Update(entity);
            context.SaveChanges();
        }
    }
}
