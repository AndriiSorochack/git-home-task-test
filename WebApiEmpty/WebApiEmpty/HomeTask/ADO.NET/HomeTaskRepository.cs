using Models;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET
{
    public class HomeTaskRepository : IRepository<HomeTask>
    {
        private readonly UniversityContext context;
        private string connectionString;

        public HomeTaskRepository(string connectionString)
        {
            this.connectionString = connectionString;
            context = new UniversityContext(connectionString);
            context.Database.EnsureCreated();
        }

        public HomeTask Create(HomeTask entity)
        {
            context.Database.EnsureCreated();
            context.HomeTasks.Add(entity);
            context.SaveChanges();
            return entity;
        }

        public List<HomeTask> GetAll()
        {
            List<HomeTask> HomeTasks = context.HomeTasks.ToList();
            return HomeTasks;
        }

        public HomeTask GetById(int id)
        {
            return context.HomeTasks.Find(id);
        }

        public void Remove(int id)
        {
            var homeTask = context.HomeTasks.Find(id);
            context.HomeTasks.Remove(homeTask);
            context.SaveChanges();
        }

        public void Update(HomeTask entity)
        {
            context.HomeTasks.Update(entity);
            context.SaveChanges();
        }
    }
}
