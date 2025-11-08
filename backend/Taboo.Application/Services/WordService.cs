using Taboo.Application.Interfaces;
using Taboo.Core.Entities;

namespace Taboo.Application.Services;

public class WordService(
    IWordGeneratorService generator,
    IWordRepository wordRepository,
    ICategoryRepository categoryRepository) : IWordService
{
  public async Task<Word> GenerateAndSaveForbiddenWordsAsync(string wordValue, int categoryId)
  {
    var category = await categoryRepository.GetByIdAsync(categoryId);
    if (category == null)
    {
      throw new ArgumentException($"Category with ID {categoryId} not found.", nameof(categoryId));
    }

    var existingWord = await wordRepository.GetWordByValueAsync(wordValue);

    if (existingWord != null)
    {
      return existingWord;
    }

    var forbiddenWords = await generator.GenerateForbiddenWordsAsync(wordValue, category.Name);

    var word = new Word
    {
      Value = wordValue,
      CategoryId = categoryId,
      TabooWords = forbiddenWords
                .Select(f => new TabooWord { Value = f })
                .ToList()
    };

    await wordRepository.AddAsync(word);
    await wordRepository.SaveChangesAsync();

    return word;
  }
}
