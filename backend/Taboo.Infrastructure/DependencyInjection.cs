using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Taboo.Application.Interfaces;
using Taboo.Core.Options;
using Taboo.Infrastructure.Persistence;
using Taboo.Infrastructure.Repositories;
using Taboo.Infrastructure.Services;

namespace Taboo.Infrastructure
{
  public static class DependencyInjection
  {
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
      var settings = new AppSettings
      {
        Database = new DatabaseOptions
        {
          Host = config["DB_HOST"]!,
          Port = config["DB_PORT"]!,
          Name = config["DB_NAME"]!,
          User = config["DB_USER"]!,
          Password = config["DB_PASSWORD"]!,
          SslMode = config["DB_SSLMODE"]!,
          ChannelBinding = config["DB_CHANNELBINDING"]!,
        },
        AiSettings = new AIOptions
        {
          ApiKey = config["GEMINI_API_KEY"]!
        }
      };
      services.AddDbContext<TabooDbContext>(options =>
          options.UseNpgsql(settings.Database.ConnectionString));

      services.AddSingleton(settings.AiSettings.ApiKey);
      services.AddScoped<IWordGeneratorService, GeminiWordGeneratorService>();

      services.AddScoped<ICategoryRepository, CategoryRepository>();
      services.AddScoped<IWordRepository, WordRepository>();
      return services;
    }
  }
}