using Taboo.Core.Entities;
using Taboo.Core.Enums;

namespace Taboo.Infrastructure.Persistence;

public static class SeedData
{
  public static void SeedCategories(TabooDbContext context)
  {
    if (context.Categories.Any())
      return; // DB already seeded

    var categories = new List<Category>
    {
      new() {
        Code = "sports",
        Translations =
        [
          new() { Language = LanguageCode.En, Name = "Sports" },
          new() { Language = LanguageCode.Tr, Name = "Spor" }
        ]
      },
      new() {
        Code = "movies",
        Translations =
        {
          new() { Language = LanguageCode.En, Name = "Movies" },
          new() { Language = LanguageCode.Tr, Name = "Filmler" }
        }
      },
      new() {
        Code = "history",
        Translations =
        {
          new() { Language = LanguageCode.En, Name = "History" },
          new() { Language = LanguageCode.Tr, Name = "Tarih" }
        }
      },
      new() {
        Code = "music",
        Translations =
        {
          new() { Language = LanguageCode.En, Name = "Music" },
          new() { Language = LanguageCode.Tr, Name = "Müzik" }
        }
      }
    };

    context.Categories.AddRange(categories);
    context.SaveChanges();
  }
}
