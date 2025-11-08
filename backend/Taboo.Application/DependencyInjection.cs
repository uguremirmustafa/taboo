using Microsoft.Extensions.DependencyInjection;
using Taboo.Application.Services;
using Taboo.Application.Interfaces;

namespace Taboo.Application
{
  public static class DependencyInjection
  {
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
      services.AddScoped<ICategoryService, CategoryService>();
      services.AddScoped<IWordService, WordService>();
      return services;
    }
  }
}
