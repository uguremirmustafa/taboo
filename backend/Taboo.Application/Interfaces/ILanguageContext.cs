using Taboo.Core.Enums;

namespace Taboo.Application.Interfaces;

public interface ILanguageContext
{
  LanguageCode CurrentLanguage { get; }
}
