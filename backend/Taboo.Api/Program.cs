using DotNetEnv;
using Taboo.Application;
using Taboo.Application.Common.Interfaces;
using Taboo.Infrastructure;
using Taboo.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

Env.Load("../.env");
var connectionString =
    $"Host={Environment.GetEnvironmentVariable("DB_HOST")};" +
    $"Port={Environment.GetEnvironmentVariable("DB_PORT")};" +
    $"Database={Environment.GetEnvironmentVariable("DB_NAME")};" +
    $"Username={Environment.GetEnvironmentVariable("DB_USER")};" +
    $"Password={Environment.GetEnvironmentVariable("DB_PASSWORD")};" +
    $"Ssl Mode={Environment.GetEnvironmentVariable("DB_SSLMODE")};" +
    $"Channel Binding={Environment.GetEnvironmentVariable("DB_CHANNELBINDING")};";



services.AddApplication();
services.AddInfrastructure(connectionString);

services.AddHttpContextAccessor();
services.AddScoped<IAppContext, Taboo.Api.Services.AppContext>();

services.AddControllers();
services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<TabooDbContext>();
    context.Database.EnsureCreated(); // or await context.Database.MigrateAsync();
    SeedData.SeedCategories(context);
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();

