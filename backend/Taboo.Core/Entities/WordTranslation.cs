using Taboo.Core.Enums;

namespace Taboo.Core.Entities;

public class WordTranslation
{
  public int Id { get; set; }
  public int WordId { get; set; }
  public Word Word { get; set; } = null!;

  public LanguageCode Language { get; set; }
  public string Value { get; set; } = null!;
}
