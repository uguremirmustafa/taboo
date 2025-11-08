using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Taboo.Core.Entities;

namespace Taboo.Infrastructure.Persistence.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
  public void Configure(EntityTypeBuilder<Category> builder)
  {
    // Table name
    builder.ToTable("categories");

    // Primary key
    builder.HasKey(c => c.Id);

    // Name field
    builder.Property(c => c.Name)
           .IsRequired()
           .HasMaxLength(100);

    // Unique index on Name
    builder.HasIndex(c => c.Name).IsUnique();

    // Words relationship
    builder.HasMany(c => c.Words)
           .WithOne(w => w.Category)
           .HasForeignKey(w => w.CategoryId)
           .OnDelete(DeleteBehavior.Cascade);

    // Translations relationship (generic table)
    builder.HasMany(c => c.Translations)
           .WithOne()
           .HasForeignKey(t => t.EntityId)
           .HasPrincipalKey(c => c.Id)
           .OnDelete(DeleteBehavior.Cascade);
  }
}
