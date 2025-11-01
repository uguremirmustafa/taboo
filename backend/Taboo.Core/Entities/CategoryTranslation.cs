using Taboo.Core.Enums;

namespace Taboo.Core.Entities;

public class CategoryTranslation
{
  public int Id { get; set; }

  public int CategoryId { get; set; }

  public Category Category { get; set; } = null!;

  public LanguageCode Language { get; set; }
  public string Name { get; set; } = null!;

}