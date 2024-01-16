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
            builder.Property(x => x.Title).HasMaxLength(255);
            builder.Property(x => x.SubTitle).HasMaxLength(500);
            builder.Property(x => x.Slug).HasMaxLength(255);
            builder.Property(x => x.CreatedById).HasMaxLength(450);

            builder
                .HasMany(p => p.Files)
                .WithMany(p => p.Articles)
                .UsingEntity<Dictionary<string, object>>(
                    "ArticlesFiles",
                    j => j
                        .HasOne<Models.File>()
                        .WithMany()
                        .HasForeignKey("FileId")
                        .HasConstraintName("FK_ArticlesFiles_Files_FileId")
                        .OnDelete(DeleteBehavior.Cascade),
                    j => j
                        .HasOne<Article>()
                        .WithMany()
                        .HasForeignKey("ArticleId")
                        .HasConstraintName("FK_ArticlesFiles_Articles_ArticleId")
                        .OnDelete(DeleteBehavior.ClientCascade));
        }
    }
}
