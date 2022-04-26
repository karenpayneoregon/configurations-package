# Connection helpers for data providers

![Configuration](assets/configuration.png)


This library provides a method to obtain a connection string to use with a data provider or Entity Framework Core, intended for desktop applications as ASP.NET Core has this already with more options via dependency injection.

In the configuration file, `ActiveEnvironment` points to the environment to connect, development, stage (test) and production.

Well someone may say I only have one database server. Then set the environment to any of the environments than if at a later time more servers are available you are ready.

---

Simple example for obtaining connection strings.

Get current connection by `ActiveEnvironment`

```csharp
ConnectionString()
```


**appsettings.json**

```json
{
  "ConnectionsConfiguration": {
    "ActiveEnvironment": "Production",
    "Development": "Dev connection string goes here",
    "Stage": "Stage connection string goes here",
    "Production": "Prod connection string goes here"
  }
}
```

Above, `ConnectionString()` will be for `Production`

Used with a data provider

```csharp
public class DataProviderOperations
{
    public static async Task<bool> CanConnect()
    {
        await using var cn = new SqlConnection(ConfigurationHelper.ConnectionString());
        await using var cmd = new SqlCommand(){Connection = cn};
        cmd.CommandText = "SELECT ContactId, FirstName, LastName FROM dbo.Contact1;";
        try
        {
            await cn.OpenAsync();

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}
```

Used with Entity Framework Core

```csharp
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    if (!optionsBuilder.IsConfigured)
    {
        optionsBuilder.UseSqlServer(ConfigurationHelper.ConnectionString());
    }
}
```

**Basic usage**

Set connection strings in `appsettings.json` and copy `appsettings.json` to the application folder followed by using `ConfigurationHelper.ConnectionString()` to set a connection string.

# Inspired by

An earlier repository I wrote on connection to databases.

[Working with multiple environments for connection strings](https://github.com/karenpayneoregon/configuration-helpers)
