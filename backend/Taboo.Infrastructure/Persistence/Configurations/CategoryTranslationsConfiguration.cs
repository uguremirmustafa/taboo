using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Taboo.Core.Entities;

namespace Taboo.Infrastructure.Persistence.Configurations;

public class CategoryTranslationConfiguration : IEntityTypeConfiguration<CategoryTranslation>
{
  public void Configure(EntityTypeBuilder<CategoryTranslation> builder)
  {
    builder.ToTable("category_translations");

    builder.HasKey(e => e.Id);

    builder.Property(e => e.Language)
        .IsRequired()
        .HasConversion<string>();

    builder.Property(e => e.Name)
        .IsRequired()
        .HasMaxLength(200);

    builder.HasOne(e => e.Category)
        .WithMany(c => c.Translations)
        .HasForeignKey(e => e.CategoryId)
        .OnDelete(DeleteBehavior.Cascade);
  }
}
