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
    public class SpecialtieConfiguration: IEntityTypeConfiguration<Specialtie>
    {
        public void Configure(EntityTypeBuilder<Specialtie> builder)
        {
            builder.ToTable("Specialtie");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).HasMaxLength(255);
            builder.Property(p => p.Description).HasMaxLength(300);

        }
    }
}
