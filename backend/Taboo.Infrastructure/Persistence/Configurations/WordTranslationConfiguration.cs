using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Taboo.Core.Entities;

namespace Taboo.Infrastructure.Persistence.Configurations;

public class WordTranslationConfiguration : IEntityTypeConfiguration<WordTranslation>
{
  public void Configure(EntityTypeBuilder<WordTranslation> builder)
  {
    builder.ToTable("word_translations");

    builder.HasKey(e => e.Id);

    builder.Property(e => e.Language)
        .IsRequired()
        .HasConversion<string>();

    builder.Property(e => e.Value)
        .IsRequired()
        .HasMaxLength(200);

    builder.HasOne(e => e.Word)
        .WithMany(w => w.Translations)
        .HasForeignKey(e => e.WordId)
        .OnDelete(DeleteBehavior.Cascade);
  }
}
