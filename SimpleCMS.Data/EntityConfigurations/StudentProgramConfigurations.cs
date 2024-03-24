using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleCMS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCMS.Data.EntityConfigurations
{
    public class StudentProgramConfigurations : IEntityTypeConfiguration<StudentProgram>
    {
        public void Configure(EntityTypeBuilder<StudentProgram> builder)
        {
            builder.ToTable("StudentPrograms");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.LessonNumber);
            builder.Property(p => p.DayOfTheWeek).HasMaxLength(50);
            builder.Property(p => p.SubjectName).HasMaxLength(100);

        }
    }
}
