using Taboo.Application.Common.Interfaces;
using Taboo.Application.DTOs;
using Taboo.Application.Interfaces;

namespace Taboo.Application.Services;

public class CategoryService(ICategoryRepository repository, IAppContext appContext) : ICategoryService
{
  private readonly ICategoryRepository _repository = repository;
  private readonly IAppContext _app = appContext;
  public async Task<IEnumerable<CategoryDto>> GetAllAsync()
  {
    var lang = _app.Language;
    var categories = await _repository.GetAllAsync();

    return categories.Select(c => new CategoryDto
    {
      Id = c.Id,
      Name = c.Name
    });
  }
}
