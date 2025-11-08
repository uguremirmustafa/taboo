using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Taboo.Application.Interfaces;
using Taboo.Application.Common.Interfaces;
using Taboo.Core.Enums;
using Taboo.Infrastructure.DTOs.Response;
using Taboo.Infrastructure.DTOs.Request;

namespace Taboo.Infrastructure.Services;

public class GeminiWordGeneratorService(
    string apiKey,
    HttpClient httpClient,
    IAppContext appContext
) : IWordGeneratorService
{
  private readonly string _apiKey = apiKey;
  private readonly HttpClient _httpClient = httpClient;
  private readonly LanguageCode _lang = appContext.Language;

  public async Task<IEnumerable<string>> GenerateForbiddenWordsAsync(string targetWord, string category)
  {
    var payload = new GeminiRequest
    {
      Contents =
        [
            new RequestContent
            {
                Role = "user",
                Parts =
                [
                    new RequestPart { Text = $"Generate 5 forbidden words for the Taboo game for the word '{targetWord}' under category '{category}' in {_lang} language as a comma-separated list." }
                ]
            }
        ],
      // SystemInstruction da aslında bir RequestContent yapısındadır
      SystemInstruction = new RequestContent
      {
        Role = "system",
        Parts =
          [
              new RequestPart { Text = "You are generating taboo-style forbidden words." }
          ]
      }
    };
    var options = new JsonSerializerOptions
    {
      PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };

    var requestContent = new StringContent(
        JsonSerializer.Serialize(payload, options),
        Encoding.UTF8,
        "application/json"
    );

    _httpClient.DefaultRequestHeaders.Clear();
    _httpClient.DefaultRequestHeaders.Add("x-goog-api-key", _apiKey);

    var response = await _httpClient.PostAsync(
        "https://generativelanguage.googleapis.com/v1beta/models/gemini-2.5-flash:generateContent",
        requestContent
    );
    response.EnsureSuccessStatusCode();

    var json = await response.Content.ReadAsStringAsync();
    var geminiResponse = JsonSerializer.Deserialize<GeminiResponse>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
    var text = geminiResponse?.Candidates?
                  .FirstOrDefault()?
                  .Content?
                  .Parts?
                  .FirstOrDefault()?
                  .Text;

    if (string.IsNullOrEmpty(text))
    {
      throw new InvalidOperationException("Failed to generate forbidden words from Gemini API response.");
    }

    return text.Split(',', StringSplitOptions.RemoveEmptyEntries)
         .Select(x => x.Trim());
  }
}
