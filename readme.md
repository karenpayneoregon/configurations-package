# NuGet package for connections

Containes two class project for source for two NuGet packages.

Each project has details on usage.

- [ConfigurationLibrary](https://www.nuget.org/packages/ConfigurationLibrary/)
- [EntityFrameworkCoreHelpers](https://www.nuget.org/packages/EntityFrameworkCoreHelpers/1.0.1)

These two packages allow a developer to be consistent from project to project for obtaining connection strings for both `SqlClient data provider` and `EF Core`. 

Usually a developer will have a single connection in code or in an application configuration file and when moving from say development to test then to production must change the code or configuration file. Using these libraries keep all connections in a json file and change one property for the active environment.

:x: One thing that should **never be stored**, login details, `user name` and `password`, instead do not uses these libraries unless each user is setup as a user in the database with proper roles.
