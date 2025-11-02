using Microsoft.EntityFrameworkCore;
using Taboo.Application.Interfaces;
using Taboo.Core.Entities;
using Taboo.Infrastructure.Persistence;

namespace Taboo.Infrastructure.Repositories;

public class CategoryRepository(TabooDbContext context) : ICategoryRepository
{
  private readonly TabooDbContext _context = context;

  public async Task<IEnumerable<Category>> GetAllAsync()
  {
    return await _context.Categories.AsNoTracking().ToListAsync();
  }
}