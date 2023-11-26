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
    public class FileConfigurations : IEntityTypeConfiguration<Models.File>
    {
        public void Configure(EntityTypeBuilder<Models.File> builder)
        {
            builder.ToTable("Files");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Path).IsRequired().HasMaxLength(255);
            builder.Property(p => p.Path).IsRequired().HasMaxLength(100);
        }
    }
}
