namespace Taboo.Core.Entities;

public class Word
{
  public int Id { get; set; }

  public int CategoryId { get; set; }

  public string Value { get; set; } = null!;

  public Category Category { get; set; } = null!;

  public ICollection<TabooWord> TabooWords { get; set; } = [];

  public ICollection<Translation> Translations { get; set; } = [];
}