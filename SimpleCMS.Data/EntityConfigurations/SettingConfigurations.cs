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
    public class SettingConfigurations : IEntityTypeConfiguration<Setting>
    {
        public void Configure(EntityTypeBuilder<Setting> builder)
        {
            builder.ToTable("Settings");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).HasMaxLength(255);
            builder.Property(p => p.Value).HasMaxLength(300);

        }
    }
}
