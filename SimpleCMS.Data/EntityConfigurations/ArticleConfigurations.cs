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
    public class ArticleConfigurations : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.ToTable("Articles");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).IsRequired().HasMaxLength(255);
            builder.Property(x => x.SubTitle).IsRequired().HasMaxLength(500);
            builder.Property(x => x.Published).IsRequired();
            builder.Property(x => x.DateModified).IsRequired();
            builder.Property(x => x.DateCreated).IsRequired();
            builder.Property(x => x.Slug).IsRequired().HasMaxLength(255);
            builder.Property(x=> x.CreatedById).IsRequired().HasMaxLength(450);
            builder.Property(x => x.IsNews).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Content).IsRequired();
        }
    }
}
