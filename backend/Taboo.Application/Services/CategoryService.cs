using Taboo.Application.DTOs;
using Taboo.Application.Interfaces;

namespace Taboo.Application.Services;

public class CategoryService(ICategoryRepository repository) : ICategoryService
{
  private readonly ICategoryRepository _repository = repository;

  public async Task<IEnumerable<CategoryDto>> GetAllAsync()
  {
    var categories = await _repository.GetAllAsync();

    // Map manually or use AutoMapper if you prefer later
    return categories.Select(c => new CategoryDto
    {
      Id = c.Id,
      Code = c.Code
    });
  }
}
