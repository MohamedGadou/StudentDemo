using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using StudentDemo.Domain.Entities;
using StudentDemo.Infrastructure.EntityTypeConfigs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDemo.Infrastructure.Context
{
    public class StudentDemoDbContext: DbContext
    {
        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }

        public StudentDemoDbContext(DbContextOptions<StudentDemoDbContext> options)
            : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StudentEntityTypeConfig());
            modelBuilder.ApplyConfiguration(new CourseEntityTypeConfig());

            base.OnModelCreating(modelBuilder);
        }

    }
}
