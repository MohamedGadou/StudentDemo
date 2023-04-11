using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentDemo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDemo.Infrastructure.EntityTypeConfigs
{
    public class StudentEntityTypeConfig : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Students");
            
            builder.HasMany(e => e.Courses)
                .WithOne(e => e.Student);

            builder.HasKey(e => e.Id);
        }

    }
}
