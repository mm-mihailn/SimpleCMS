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
    public class ArticleFilesConfiguration : IEntityTypeConfiguration<ArticleFiles>
    {
        public void Configure(EntityTypeBuilder<ArticleFiles> builder)
        {
            builder.ToTable("ArticleFiles");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Article).IsRequired().HasMaxLength(255);
            builder.Property(x => x.File).IsRequired().HasMaxLength(500);
        
        }
    }
}

