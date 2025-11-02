using Microsoft.EntityFrameworkCore;
using Taboo.Core.Entities;

namespace Taboo.Infrastructure.Persistence;

public class TabooDbContext(DbContextOptions<TabooDbContext> options) : DbContext(options)
{

  public DbSet<Category> Categories => Set<Category>();
  public DbSet<Word> Words => Set<Word>();
  public DbSet<ForbiddenWord> ForbiddenWords => Set<ForbiddenWord>();
  public DbSet<CategoryTranslation> CategoryTranslations => Set<CategoryTranslation>();
  public DbSet<WordTranslation> WordTranslations => Set<WordTranslation>();

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    // Automatically apply all configurations in this assembly
    modelBuilder.ApplyConfigurationsFromAssembly(typeof(TabooDbContext).Assembly);
  }
}