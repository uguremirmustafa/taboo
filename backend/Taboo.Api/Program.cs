using DotNetEnv;
using Taboo.Application;
using Taboo.Application.Common.Interfaces;
using Taboo.Infrastructure;
using Taboo.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

Env.Load("../.env");
builder.Configuration.AddEnvironmentVariables();

var services = builder.Services;

services.AddHttpClient();
services.AddApplication();
services.AddInfrastructure(builder.Configuration);

services.AddHttpContextAccessor();
services.AddScoped<IAppContext, Taboo.Api.Services.AppContext>();

services.AddControllers();
services.AddOpenApi();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<TabooDbContext>();
    context.Database.EnsureCreated(); // or await context.Database.MigrateAsync();
    await SeedData.SeedCategoriesAsync(context);
}
if (!app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}
app.MapControllers();
app.Run();
