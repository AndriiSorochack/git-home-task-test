using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Models;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET
{
    public class UniversityContext : DbContext
    {
        private readonly string _connectionString;
        public DbSet<Course> Courses { get; set; }
        public DbSet<HomeTask> HomeTasks { get; set; }
        public DbSet<Student> Students { get; set; }

        private readonly IOptions<RepositoryOptions> _options;

        public UniversityContext(IOptions<RepositoryOptions> options)
        {
            _options = options;
        }

        public UniversityContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //ConfigurationBuilder builder = new ConfigurationBuilder();
            //builder.AddJsonFile($"appsettings.json", true, true);
            //var configuration = builder.Build();
            //string connectionString = configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }

    public class RepositoryOptions
    {
        public string DefaultConnectionString { get; set; }
    }
}
