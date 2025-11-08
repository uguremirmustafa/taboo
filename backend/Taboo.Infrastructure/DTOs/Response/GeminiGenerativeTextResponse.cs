
namespace Taboo.Infrastructure.DTOs.Response;

// Response DTOs
public class Part
{
  // API'den gelen 'text' alanını temsil eder
  public string? Text { get; set; }
}

public class Content
{
  // 'parts' dizisini temsil eder
  public List<Part>? Parts { get; set; }
}

public class Candidate
{
  // 'content' nesnesini temsil eder
  public Content? Content { get; set; }
}

public class GeminiResponse
{
  // Ana 'candidates' dizisini temsil eder
  public List<Candidate>? Candidates { get; set; }
}