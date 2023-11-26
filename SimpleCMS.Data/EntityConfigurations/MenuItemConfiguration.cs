using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleCMS.Data.Models;

namespace SimpleCMS.Data.EntityConfigurations
{
    public class MenuItemConfiguration : IEntityTypeConfiguration<MenuItem>
    {
        public void Configure(EntityTypeBuilder<MenuItem> builder)
        {
            builder.ToTable("MenuItems");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Title).HasMaxLength(255);
            builder.Property(p => p.Link).HasMaxLength(255);
        }
    }
}
