using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Taboo.Application.Interfaces;
using Taboo.Infrastructure.Persistence;
using Taboo.Infrastructure.Repositories;

namespace Taboo.Infrastructure
{
  public static class DependencyInjection
  {
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
    {
      services.AddDbContext<TabooDbContext>(options =>
          options.UseNpgsql(connectionString));

      services.AddScoped<ICategoryRepository, CategoryRepository>();
      return services;
    }
  }
}