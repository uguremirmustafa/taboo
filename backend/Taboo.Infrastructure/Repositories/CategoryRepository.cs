using Microsoft.EntityFrameworkCore;
using Taboo.Application.Common.Interfaces;
using Taboo.Application.Interfaces;
using Taboo.Core.Entities;
using Taboo.Infrastructure.Persistence;

namespace Taboo.Infrastructure.Repositories;

public class CategoryRepository(TabooDbContext context, IAppContext appContext) : ICategoryRepository
{
  private readonly TabooDbContext _context = context;
  private readonly IAppContext _app = appContext;

  public async Task<IEnumerable<Category>> GetAllAsync()
  {
    return await _context.Categories
            .AsNoTracking()
            .Include(c => c.Translations)
            .Where(c => c.Translations.Any(t => t.Language == _app.Language))
            .ToListAsync();
  }
}