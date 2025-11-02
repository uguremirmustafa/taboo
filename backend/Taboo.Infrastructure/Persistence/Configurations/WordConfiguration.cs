using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Taboo.Core.Entities;

namespace Taboo.Infrastructure.Persistence.Configurations;

public class WordConfiguration : IEntityTypeConfiguration<Word>
{
  public void Configure(EntityTypeBuilder<Word> builder)
  {
    builder.ToTable("words");

    builder.HasKey(e => e.Id);

    builder.HasOne(e => e.Category)
        .WithMany(c => c.Words)
        .HasForeignKey(e => e.CategoryId)
        .OnDelete(DeleteBehavior.Cascade);
  }
}
