using Taboo.Core.Entities;

namespace Taboo.Application.Interfaces;

public interface ICategoryRepository
{
  Task<IEnumerable<Category>> GetAllAsync();
}