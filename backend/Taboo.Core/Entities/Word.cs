namespace Taboo.Core.Entities;

public class Word
{
  public int Id { get; set; }

  public int CategoryId { get; set; }

  public Category Category { get; set; } = null!;

  public ICollection<ForbiddenWord> ForbiddenWords { get; set; } = [];

  public ICollection<WordTranslation> Translations { get; set; } = [];
}