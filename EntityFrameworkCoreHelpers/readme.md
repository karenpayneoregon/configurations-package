# About

Provides the following methods for connecting to a SQL-Server database.

## Note

Place the following appsettings.json file into a project, set to copy if newer

1. Populate each environment with appropriate connection strings.
2. Set `ActiveEnvironment` to the desired environment.
3. Use one of the connection methods below in your DbContext class.

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

Connect without logging

```csharp
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    if (!optionsBuilder.IsConfigured)
    {
        DbContextConnections.NoLogging(optionsBuilder);
    }
}
```

Connect with logging via Debug.WriteLine

```csharp
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    if (!optionsBuilder.IsConfigured)
    {
        DbContextConnections.StandardLogging(optionsBuilder);
    }
}
```

Connect with logging to a specified file

```csharp
/// <summary>
/// Writes/appends to a file
/// </summary>
/// <param name="optionsBuilder"></param>
/// <param name="fileName">File name to write log data too</param>
public static void CustomLogging(DbContextOptionsBuilder optionsBuilder, string fileName)
{
    optionsBuilder.UseSqlServer(ConfigurationHelper.ConnectionString())
        .EnableSensitiveDataLogging()
        .LogTo(new DbContextLogger(fileName).Log)
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors();
}
```


Connect with logging to a folder named Logs under the current application folder.

Note the folder Logs must exist while the log file does not need to exists. To ensure the folder exist consider a msbuild task[^1].

```csharp
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    if (!optionsBuilder.IsConfigured)
    {
        DbContextConnections.CustomLogging(optionsBuilder);
    }
}
```


```csharp
public class DbContextConnections
{
    /// <summary>
    /// Simple configuration for setting the connection string
    /// </summary>
    public static void NoLogging(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(ConfigurationHelper.ConnectionString());
    }

    /// <summary>
    /// Default logging to output window
    /// </summary>
    public static void StandardLogging(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(ConfigurationHelper.ConnectionString())
            .EnableSensitiveDataLogging()
            .LogTo(message => Debug.WriteLine(message));
    }
    /// <summary>
    /// Writes/appends to a file
    /// Make sure that the folder exists, as coded folder name is Logs under the app folder.
    /// One way to ensure the folder exists is to use MsBuild task MakeDir as in
    /// the test project ShadowPropertiesUnitTestProject.
    /// </summary>
    public static void CustomLogging(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(ConfigurationHelper.ConnectionString())
            .EnableSensitiveDataLogging()
            .LogTo(new DbContextLogger().Log)
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors();
    }
}
``````

[^1]: msbuild MakeDir
```xml
<Target Name="MakeLogFolder" AfterTargets="Build">
	<MakeDir Directories="$(OutDir)Logs" />
</Target>
```