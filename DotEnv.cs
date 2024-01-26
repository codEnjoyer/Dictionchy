using System.Reflection;
using System.Resources;
using System.Text.Json;

namespace Dictionchy;

public enum EnvFileType
{
    Env,
    Json
}

public static class DotEnv
{
    public static string Token { get; private set; }
    public static string Resources { get; private set; }

    private static readonly Dictionary<string, PropertyInfo> Properties = new();


    #pragma warning disable CS8618 
    static DotEnv()
    {
        foreach (var property in typeof(DotEnv).GetProperties())
            Properties[property.Name] = property;
    }

    public static void Load(EnvFileType type = EnvFileType.Env)
    {
        var path = ReadResource(".env");
        var textInfo = Thread.CurrentThread.CurrentCulture.TextInfo;
        var parseStrategy = GetParseStrategy(type);
        foreach (var (name, value) in parseStrategy(path))
        {
            var propertyFormattedName = textInfo.ToTitleCase(name.ToLower());
            Properties[propertyFormattedName].SetValue("ThisArgumentIsIgnoredForStaticMethods", value);
        }
    }

    private static Func<string, IEnumerable<Tuple<string, string>>> GetParseStrategy(EnvFileType type)
    {
        return type switch
        {
            EnvFileType.Env => ParseDotEnv,
            EnvFileType.Json => ParseJson,
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
        };
    }
    
    private static IEnumerable<Tuple<string, string>> ParseDotEnv(string content)
    {
        var lines = content.Split(Environment.NewLine);
        foreach (var line in lines)
        {
            var parts = line.Split("=");
            if (parts.Length != 2)
                continue;
            yield return Tuple.Create(parts[0], parts[1]);
        }
    }

    private static IEnumerable<Tuple<string, string>> ParseJson(string content)
    {
        var obj = JsonSerializer.Deserialize<Dictionary<string, string>>(content);
        if (obj is null)
            yield break;
        foreach (var (key, value) in obj)
            yield return Tuple.Create(key, value);
    }
    
    public static string ReadResource(string name)
    {
        // Determine path
        var assembly = Assembly.GetExecutingAssembly();
        var resourcePath = name;
        // Format: "{Namespace}.{Folder}.{filename}.{Extension}"
        if (!name.StartsWith(nameof(DotEnv)))
        {
            resourcePath = assembly.GetManifestResourceNames()
                .Single(str => str.EndsWith(name));
        }

        using var stream = assembly.GetManifestResourceStream(resourcePath);
        using var reader = new StreamReader(stream ?? Stream.Null);
        return reader.ReadToEnd().Trim();
    }
}