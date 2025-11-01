namespace Taboo.Core.Entities;

public class Category
{
  public int Id { get; set; }

  // e.g. "Sports", "Movies"
  public string Code { get; set; } = null!;

  public ICollection<Word> Words { get; set; } = [];

  public ICollection<CategoryTranslation> Translations { get; set; } = [];
}

