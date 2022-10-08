# About

For testing connection strings for EF Core


```csharp
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    if (!optionsBuilder.IsConfigured)
    {
        StandardLoggingSqlServer(optionsBuilder);
    }
}

public static void StandardLoggingSqlServer(DbContextOptionsBuilder optionsBuilder)
{
    optionsBuilder
        .UseSqlServer(ConfigurationHelper.ConnectionStringWeb())
        .EnableSensitiveDataLogging()
        .LogTo(message => Debug.WriteLine(message));

}
public static void NoLoggingSqlServer(DbContextOptionsBuilder optionsBuilder)
{
    optionsBuilder.UseSqlServer(ConfigurationHelper.ConnectionStringWeb());
}
```