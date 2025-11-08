using Microsoft.AspNetCore.Mvc;
using Taboo.Application.Interfaces;
using Taboo.Application.DTOs.Requests;

namespace Taboo.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TabooController(IWordService wordService) : ControllerBase
{
  [HttpPost("generate")]
  public async Task<IActionResult> Generate([FromBody] GenerateForbiddenWordsRequest request)
  {
    Console.WriteLine($"Word: {request.Word}, CategoryId: {request.CategoryId}");

    var word = await wordService.GenerateAndSaveForbiddenWordsAsync(request.Word, request.CategoryId);
    return Ok(word);
  }
}
