using Microsoft.EntityFrameworkCore;
using Taboo.Application.Common.Interfaces;
using Taboo.Application.Interfaces;
using Taboo.Core.Entities;
using Taboo.Core.Enums;
using Taboo.Infrastructure.Persistence;

namespace Taboo.Infrastructure.Repositories;

public class WordRepository(TabooDbContext context, IAppContext appContext) : IWordRepository
{
    private readonly LanguageCode lang = appContext.Language;
    public async Task AddAsync(Word word) =>
        await context.Words.AddAsync(word);

    public async Task<Word?> GetWordByValueAsync(string value) =>
        await context.Words
            .Include(w => w.TabooWords)
            .FirstOrDefaultAsync(w =>
                w.Value == value ||
                w.Translations.Any(t => t.Source == value &&
                                        t.EntityType == "Word" &&
                                        t.Language == lang));
    public async Task SaveChangesAsync() =>
        await context.SaveChangesAsync();
}
