using Microsoft.EntityFrameworkCore;
using Taboo.Core.Entities;
using Taboo.Core.Enums;

namespace Taboo.Infrastructure.Persistence;

public static class SeedData
{
  public static async Task SeedCategoriesAsync(TabooDbContext context)
  {
    if (await context.Categories.AnyAsync())
      return; // DB already seeded

    var categories = new List<Category>
    {
        new Category
        {
            Name = "Sports",
            // Translations = new List<Translation>
            // {
            //     new Translation
            //     {
            //         Language = LanguageCode.Tr,
            //         Source = "Sports",
            //         Value = "Spor",
            //         EntityType = nameof(Category) // safer than string literal
            //     }
            // }
        },
        new Category
        {
            Name = "Movies",
            // Translations = new List<Translation>
            // {
            //     new Translation
            //     {
            //         Language = LanguageCode.Tr,
            //         Source = "Movies",
            //         Value = "Filmler",
            //         EntityType = nameof(Category)
            //     }
            // }
        }
    };

    // Add categories first
    await context.Categories.AddRangeAsync(categories);

    // Save changes to generate Ids
    await context.SaveChangesAsync();
  }

}
