# NuGet package for connections

![img](assets/title.png)

Containes two class project for source for two NuGet packages.

:green_circle: Updated to .NET Core 7 12/14/2022 from .NET Core 5

Each project has details on usage.

- [ConfigurationLibrary](https://www.nuget.org/packages/ConfigurationLibrary/)
- [EntityFrameworkCoreHelpers](https://www.nuget.org/packages/EntityFrameworkCoreHelpers/1.0.1)

These two packages allow a developer to be consistent from project to project for obtaining connection strings for both `SqlClient data provider` and `EF Core`. 

Usually a developer will have a single connection in code or in an application configuration file and when moving from say development to test then to production must change the code or configuration file. Using these libraries keep all connections in a json file and change one property for the active environment.

:x: One thing that should **never be stored**, login details, `user name` and `password`, instead do not uses these libraries unless each user is setup as a user in the database with proper roles.


# Desktop

## EF Core

```csharp
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    if (!optionsBuilder.IsConfigured)
    {
        optionsBuilder.UseSqlServer(ConfigurationHelper.ConnectionString());
    }
}
```

## SqlClient data provider

```csharp
await using var cn = new SqlConnection(ConfigurationHelper.ConnectionString());
```

### appsettings.json

```json
{
  "ConnectionsConfiguration": {
    "ActiveEnvironment": "Development",
    "Development": "Server=(localdb)\\MSSQLLocalDB;Database=OED.Pizza;Trusted_Connection=True",
    "Stage": "Stage connection string goes here",
    "Production": "Prod connection string goes here"
  }
}
```

# Web

## EF Core

```csharp
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    if (!optionsBuilder.IsConfigured)
    {
        optionsBuilder.UseSqlServer(ConfigurationHelper.ConnectionStringWeb());
    }
}
```

## appsettings.json

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "ActiveEnvironment": "Development",
    "Development": "Server=(localdb)\\MSSQLLocalDB;Database=OED.Pizza;Trusted_Connection=True",
    "Stage": "Server=(localdb)\\MSSQLLocalDB;Database=OED.Pizza;Trusted_Connection=True",
    "Production": "Server=(localdb)\\MSSQLLocalDB;Database=OED.Pizza;Trusted_Connection=True"
  }
}
```







