using Microsoft.AspNetCore.Mvc;
using Taboo.Application.Interfaces;

namespace Taboo.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController(ICategoryService categoryService) : ControllerBase
{
  private readonly ICategoryService _categoryService = categoryService;

  [HttpGet]
  public async Task<IActionResult> GetAll()
  {
    var categories = await _categoryService.GetAllAsync();
    return Ok(categories);
  }
}
