using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Taboo.Core.Entities;

public class WordConfiguration : IEntityTypeConfiguration<Word>
{
  public void Configure(EntityTypeBuilder<Word> builder)
  {
    // Table name
    builder.ToTable("words");

    // Primary key
    builder.HasKey(w => w.Id);

    // Category relationship
    builder.HasOne(w => w.Category)
           .WithMany(c => c.Words)
           .HasForeignKey(w => w.CategoryId)
           .OnDelete(DeleteBehavior.Cascade);

    // Value field
    builder.Property(w => w.Value)
           .IsRequired()
           .HasMaxLength(200);

    // TabooWords relationship
    builder.HasMany(w => w.TabooWords)
           .WithOne() // no nav property on TabooWord
           .HasForeignKey(tw => tw.WordId)
           .OnDelete(DeleteBehavior.Cascade);

    // Translations relationship
    builder.HasMany(w => w.Translations)
           .WithOne()
           .HasForeignKey(t => t.EntityId)
           .HasPrincipalKey(w => w.Id)
           .OnDelete(DeleteBehavior.Cascade);

    // Optional: Index on Value for fast lookup
    builder.HasIndex(w => new { w.CategoryId, w.Value }).IsUnique();
  }
}
