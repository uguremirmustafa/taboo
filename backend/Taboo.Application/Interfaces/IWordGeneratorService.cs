namespace Taboo.Application.Interfaces;

public interface IWordGeneratorService
{
  Task<IEnumerable<string>> GenerateForbiddenWordsAsync(string targetWord, string category);
}
