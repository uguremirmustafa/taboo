namespace Taboo.Core.Entities;

public class ForbiddenWord
{
  public int Id { get; set; }
  public int WordId { get; set; }
  public Word Word { get; set; } = null!;

  public string Value { get; set; } = null!;
}
