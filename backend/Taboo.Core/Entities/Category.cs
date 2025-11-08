namespace Taboo.Core.Entities;

public class Category
{
  public int Id { get; set; }

  // e.g. "Sports", "Movies"
  public string Name { get; set; } = null!;

  public ICollection<Word> Words { get; set; } = [];

  public ICollection<Translation> Translations { get; set; } = [];
}

