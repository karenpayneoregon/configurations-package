# About

Test for 

- ConfigurationLibrary
- EntityFrameworkCoreHelpers

# Setup

Before running test, execute ShadowProperties.Classes.Initialize() which will create and populate the database as a localDb SQL-Server database.


# Logging

One of the options for making a connection with code from EntityFrameworkCoreHelpers is to log to a file. In the method CustomLogging a log file will be created in the application folder, Logs. To ensure the Logs folder exists the following task is used.

```xml
<Target Name="MakeLogFolder" AfterTargets="Build">
	<MakeDir Directories="$(OutDir)Logs" />
</Target>
```
