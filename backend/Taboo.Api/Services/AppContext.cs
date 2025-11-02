using Taboo.Application.Common.Interfaces;
using Taboo.Core.Enums;

namespace Taboo.Api.Services;

public class AppContext(IHttpContextAccessor httpContextAccessor) : IAppContext
{
  private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

  private HttpContext? HttpContext => _httpContextAccessor.HttpContext;

  public LanguageCode Language
  {
    get
    {
      var langHeader = HttpContext?.Request.Headers.AcceptLanguage.ToString()
          .Split(',')[0]
          .Trim()
          .ToLowerInvariant();

      return langHeader switch
      {
        "tr" or "tr-tr" => LanguageCode.Tr,
        "en" or "en-us" or "en-gb" => LanguageCode.En,
        _ => LanguageCode.Tr
      };
    }
  }

  public string TimeZone =>
      HttpContext?.Request.Headers["X-Timezone"].ToString() ?? "UTC";

  public string? CorrelationId =>
      HttpContext?.TraceIdentifier;

  public string? IpAddress =>
      HttpContext?.Connection.RemoteIpAddress?.ToString();


}
