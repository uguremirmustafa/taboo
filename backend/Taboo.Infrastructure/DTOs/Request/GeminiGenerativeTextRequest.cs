using System;

namespace Taboo.Infrastructure.DTOs.Request;

// 1. En içteki metin parçası
public class RequestPart
{
  public string? Text { get; set; }
}

// 2. Kullanıcı/Sistem içeriği
public class RequestContent
{
  public string? Role { get; set; }
  public List<RequestPart>? Parts { get; set; }
}

// 3. Ana İstek Gövdesi
public class GeminiRequest
{
  [System.Text.Json.Serialization.JsonPropertyName("model")]
  public string Model { get; set; } = "gemini-2.5-flash"; // Varsayılan değer burada tanımlanabilir

  [System.Text.Json.Serialization.JsonPropertyName("contents")]
  public List<RequestContent>? Contents { get; set; }

  [System.Text.Json.Serialization.JsonPropertyName("systemInstruction")]
  public RequestContent? SystemInstruction { get; set; } // SystemInstruction da bir RequestContent'tir
}