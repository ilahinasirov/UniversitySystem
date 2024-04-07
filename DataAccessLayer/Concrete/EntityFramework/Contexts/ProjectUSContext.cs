using DataAccessLayer.Concrete.SeedMethods;
using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.EntityFramework.Contexts
{
    public class ProjectUSContext : IdentityDbContext<User>

    {
        //public ProjectUSContext(DbContextOptions<ProjectUSContext> options):base(options)
        //{
        //}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-JN80QO8\SQLEXPRESS;Database=ProjectUS;Trusted_Connection=true");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            using (var serviceScope = this.GetInfrastructure().GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                SeedData.InitializeRoles(serviceScope.ServiceProvider, roleManager).Wait();
            }
        }

        public DbSet<Exam> Exams { get; set; }
        DbSet<Group> Groups { get; set; }
        DbSet<Lesson> Lessons { get; set; }
        DbSet<Option> Options { get; set; }
        DbSet<Question> Questions { get; set; }
        DbSet<User> Users { get; set; }



        //        // Seed Method
        //        protected override void OnModelCreating(ModelBuilder modelBuilder)
        //        {
        //            modelBuilder.Entity<User>().HasQueryFilter(x => !x.IsDeleted);
        //            modelBuilder.Entity<Role>().HasData(
        //                new Role
        //                {
        //                    Id = 1,
        //                    Key = ERole.admin.ToString(),
        //                    Name = "ADMIN"

        //                },
        //                new Role
        //                {
        //                    Id = 2,
        //                    Key = ERole.teacher.ToString(),
        //                    Name = "TEACHER"

        //                },
        //                new Role
        //                {
        //                    Id = 3,
        //                    Key = ERole.student.ToString(),
        //                    Name = "STUDENT"

        //                }
        //                );
        //            /*
        //dotnet tool install --global dotnet-ef
        //dotnet ef migrations add InitialCreate
        //dotnet ef database update
        //*/


        //        }



    }
}
