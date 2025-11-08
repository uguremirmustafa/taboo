namespace Taboo.Core.Entities;

public class TabooWord
{
  public int Id { get; set; }
  public int WordId { get; set; }
  public string Value { get; set; } = null!;
  public ICollection<Translation> Translations { get; set; } = [];

}
