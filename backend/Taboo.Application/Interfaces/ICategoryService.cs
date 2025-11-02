using Taboo.Application.DTOs;

namespace Taboo.Application.Interfaces;

public interface ICategoryService
{
  Task<IEnumerable<CategoryDto>> GetAllAsync();
}
