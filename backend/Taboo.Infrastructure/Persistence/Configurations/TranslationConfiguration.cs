using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class TranslationConfiguration : IEntityTypeConfiguration<Translation>
{
  public void Configure(EntityTypeBuilder<Translation> builder)
  {
    builder.ToTable("translations");

    builder.HasKey(t => t.Id);

    builder.Property(t => t.Language)
           .IsRequired()
           .HasConversion<string>();

    builder.Property(t => t.Source)
           .IsRequired()
           .HasMaxLength(200);

    builder.Property(t => t.Value)
           .IsRequired()
           .HasMaxLength(200);

    builder.Property(t => t.EntityType)
           .IsRequired()
           .HasMaxLength(50);

    builder.HasIndex(t => new { t.EntityType, t.EntityId });

    // Note: don't configure a FK here to multiple tables,
    // EF cannot enforce FK generically. Handle FK integrity in code.
  }
}
