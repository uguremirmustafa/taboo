using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Taboo.Core.Entities;

namespace Taboo.Infrastructure.Persistence.Configurations;

public class ForbiddenWordConfiguration : IEntityTypeConfiguration<ForbiddenWord>
{
  public void Configure(EntityTypeBuilder<ForbiddenWord> builder)
  {
    builder.ToTable("forbidden_words");

    builder.HasKey(e => e.Id);

    builder.Property(e => e.Value)
        .IsRequired()
        .HasMaxLength(200);

    builder.HasOne(e => e.Word)
        .WithMany(w => w.ForbiddenWords)
        .HasForeignKey(e => e.WordId)
        .OnDelete(DeleteBehavior.Cascade);
  }
}
