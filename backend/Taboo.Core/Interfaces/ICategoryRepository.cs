using Taboo.Core.Entities;

namespace Taboo.Core.Interfaces;

public interface ICategoryRepository
{
  Task<IEnumerable<Category>> GetAllAsync();
}