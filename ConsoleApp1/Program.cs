using System.Text.Json.Serialization;
using System.Text.Json;
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace ConsoleApp1;

internal class Program
{
    static void Main(string[] args)
    {
        Console.Title = "";

        TimeIncrement[] values = Enum.GetValues<TimeIncrement>().ToArray();
        var serializerOptions = new JsonSerializerOptions
        {
            WriteIndented = true,
            Converters = { new JsonStringEnumConverter() }
        };

        Console.WriteLine(JsonSerializer.Serialize(values, serializerOptions));
        Console.WriteLine();

        Root root = new() { TimeIncrement = values };
        var json = JsonSerializer.Serialize(root, serializerOptions);
        Console.WriteLine(json);

        var rootDeserialize = JsonSerializer.Deserialize<Root>(json, serializerOptions);

        Console.ReadLine();
    }
}
public class Root
{
    public TimeIncrement[] TimeIncrement { get; set; }
}
public enum TimeIncrement
{
    Hourly,
    Quarterly,
    HalfHour
}