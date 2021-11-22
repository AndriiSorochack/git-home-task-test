using ADO.NET;
using ADO.NET.EF;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Models;
using Models.Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace University_Web_Page
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<UniversityContext>(options =>
         options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddControllersWithViews();
            services.AddDbContext<UniversityContext>();
            services.Configure<RepositoryOptions>(Configuration);
            services.AddControllers();
            services.AddScoped<CourseService>();
            services.AddScoped<HomeTaskService>(); //Write Add Scoped here HomeTaskServices
            services.AddScoped<StudentService>();  //Write Add Scoped here StudentServices
            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddScoped<IRepository<Course>>(p => new CourseRepository(connectionString));
            services.AddScoped<IRepository<Student>>(p => new StudentRepository(connectionString));
            services.AddScoped<IRepository<HomeTask>>(p => new HomeTaskRepository(connectionString));
            services.AddScoped<IRepository<HomeTaskAssessment>>(p => new HomeTaskAssessmentRepository(connectionString));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
