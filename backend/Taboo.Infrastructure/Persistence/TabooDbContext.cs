using Microsoft.EntityFrameworkCore;
using Taboo.Core.Entities;

namespace Taboo.Infrastructure.Persistence;

public class TabooDbContext(DbContextOptions<TabooDbContext> options) : DbContext(options)
{

  public DbSet<Category> Categories => Set<Category>();
  public DbSet<Word> Words => Set<Word>();
  public DbSet<TabooWord> ForbiddenWords => Set<TabooWord>();
  public DbSet<Translation> Translations => Set<Translation>();

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    // Automatically apply all configurations in this assembly
    modelBuilder.ApplyConfigurationsFromAssembly(typeof(TabooDbContext).Assembly);
  }
}