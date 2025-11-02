using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Taboo.Core.Entities;

namespace Taboo.Infrastructure.Persistence.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
  public void Configure(EntityTypeBuilder<Category> builder)
  {
    builder.ToTable("categories");

    builder.HasKey(e => e.Id);

    builder.Property(e => e.Code)
        .IsRequired()
        .HasMaxLength(100);

    builder.HasIndex(e => e.Code)
        .IsUnique();
  }
}
