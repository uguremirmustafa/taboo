using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Taboo.Core.Entities;

namespace Taboo.Infrastructure.Persistence.Configurations;

public class TabooWordConfiguration : IEntityTypeConfiguration<TabooWord>
{
  public void Configure(EntityTypeBuilder<TabooWord> builder)
  {
    builder.ToTable("taboo_words");

    builder.HasKey(e => e.Id);

    builder.Property(e => e.Value)
        .IsRequired()
        .HasMaxLength(200);
  }
}
