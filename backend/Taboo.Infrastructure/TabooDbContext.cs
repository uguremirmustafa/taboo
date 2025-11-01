using Microsoft.EntityFrameworkCore;
using Taboo.Core.Entities;

namespace Taboo.Infrastructure;

public class TabooDbContext(DbContextOptions<TabooDbContext> options) : DbContext(options)
{

  public DbSet<Category> Categories => Set<Category>();
  public DbSet<Word> Words => Set<Word>();
  public DbSet<ForbiddenWord> ForbiddenWords => Set<ForbiddenWord>();
  public DbSet<CategoryTranslation> CategoryTranslations => Set<CategoryTranslation>();
  public DbSet<WordTranslation> WordTranslations => Set<WordTranslation>();

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    // CATEGORY
    modelBuilder.Entity<Category>(entity =>
    {
      entity.ToTable("categories");
      entity.HasKey(e => e.Id);
      entity.Property(e => e.Code)
                .IsRequired()
                .HasMaxLength(100);

      entity.HasIndex(e => e.Code)
                .IsUnique();
    });

    // CATEGORY TRANSLATION
    modelBuilder.Entity<CategoryTranslation>(entity =>
    {
      entity.ToTable("category_translations");
      entity.HasKey(e => e.Id);

      entity.Property(e => e.Language)
                .IsRequired()
                .HasConversion<string>(); // store enum as text

      entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(200);

      entity.HasOne(e => e.Category)
                .WithMany(c => c.Translations)
                .HasForeignKey(e => e.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
    });

    // WORD
    modelBuilder.Entity<Word>(entity =>
    {
      entity.ToTable("words");
      entity.HasKey(e => e.Id);

      entity.HasOne(e => e.Category)
                .WithMany(c => c.Words)
                .HasForeignKey(e => e.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
    });

    // WORD TRANSLATION
    modelBuilder.Entity<WordTranslation>(entity =>
    {
      entity.ToTable("word_translations");
      entity.HasKey(e => e.Id);

      entity.Property(e => e.Language)
                .IsRequired()
                .HasConversion<string>();

      entity.Property(e => e.Value)
                .IsRequired()
                .HasMaxLength(200);

      entity.HasOne(e => e.Word)
                .WithMany(w => w.Translations)
                .HasForeignKey(e => e.WordId)
                .OnDelete(DeleteBehavior.Cascade);
    });

    // FORBIDDEN WORD
    modelBuilder.Entity<ForbiddenWord>(entity =>
    {
      entity.ToTable("forbidden_words");
      entity.HasKey(e => e.Id);

      entity.Property(e => e.Value)
                .IsRequired()
                .HasMaxLength(200);

      entity.HasOne(e => e.Word)
                .WithMany(w => w.ForbiddenWords)
                .HasForeignKey(e => e.WordId)
                .OnDelete(DeleteBehavior.Cascade);
    });
  }
}