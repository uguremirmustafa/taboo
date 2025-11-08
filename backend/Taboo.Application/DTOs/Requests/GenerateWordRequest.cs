namespace Taboo.Application.DTOs.Requests;

public class GenerateForbiddenWordsRequest
{
  public string Word { get; init; } = null!;
  public int CategoryId { get; init; }
}