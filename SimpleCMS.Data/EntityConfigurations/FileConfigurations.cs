using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleCMS.Data.Models;

namespace SimpleCMS.Data.EntityConfigurations
{
    public class FileConfigurations : IEntityTypeConfiguration<Files>
    {
        public void Configure(EntityTypeBuilder<Files> builder)
        {
            builder.ToTable("Files");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Path).HasMaxLength(255);
            builder.Property(p => p.Name).HasMaxLength(100);
            builder.Property(p => p.MimeType).HasMaxLength(100);
        }
    }
}
