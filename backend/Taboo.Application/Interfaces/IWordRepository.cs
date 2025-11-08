using Taboo.Core.Entities;

namespace Taboo.Application.Interfaces;

public interface IWordRepository
{
  Task AddAsync(Word word);
  Task<Word?> GetWordByValueAsync(string value);
  Task SaveChangesAsync();
}
