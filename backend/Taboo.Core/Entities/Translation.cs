using Taboo.Core.Enums;

public class Translation
{
  public int Id { get; set; }

  // Reference to the entity being translated
  public string EntityType { get; set; } = null!; // e.g., "Word", "ForbiddenWord", "Category"
  public int EntityId { get; set; }

  // The value in the default language (or source)
  public string Source { get; set; } = null!;

  // The translated value
  public string Value { get; set; } = null!;

  public LanguageCode Language { get; set; }
}
