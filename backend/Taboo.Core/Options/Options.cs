namespace Taboo.Core.Options;

public class AppSettings
{
  public DatabaseOptions Database { get; set; } = new();
  public AIOptions AiSettings { get; set; } = new();
}

public class DatabaseOptions
{
  public string Host { get; set; } = null!;
  public string Port { get; set; } = null!;
  public string Name { get; set; } = null!;
  public string User { get; set; } = null!;
  public string Password { get; set; } = null!;
  public string SslMode { get; set; } = "Disable";
  public string ChannelBinding { get; set; } = "Prefer";

  public string ConnectionString =>
      $"Host={Host};Port={Port};Database={Name};Username={User};Password={Password};" +
      $"Ssl Mode={SslMode};Channel Binding={ChannelBinding};";
}

public class AIOptions
{
  public string ApiKey { get; set; } = null!;
}
