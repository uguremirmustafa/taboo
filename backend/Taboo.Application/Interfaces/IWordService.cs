using Taboo.Core.Entities;

namespace Taboo.Application.Interfaces;

public interface IWordService
{
  Task<Word> GenerateAndSaveForbiddenWordsAsync(string word, int categoryId);
}
