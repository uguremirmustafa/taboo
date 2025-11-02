using Taboo.Core.Enums;

namespace Taboo.Application.Common.Interfaces
{
  public interface IAppContext
  {
    LanguageCode Language { get; }
    string TimeZone { get; }
    string? CorrelationId { get; }
    string? IpAddress { get; }
  }
}
