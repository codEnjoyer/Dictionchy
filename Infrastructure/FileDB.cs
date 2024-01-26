using System.Text.Json;
using Dictionchy.Domain;

namespace Dictionchy.Infrastructure;

public class FileDB<T>: IDatabaseProvider<T>
{
    public T? Get(params string[] args)
    {
        var folder = args[0];
        var filename = args[1];
        var pathToFile = Path.Combine(folder, filename + ".json");
        if (!File.Exists(pathToFile))
        {
            return default;
        }

        using var fs = File.Open(pathToFile, FileMode.Open);
        return JsonSerializer.Deserialize<T>(fs, new JsonSerializerOptions { WriteIndented = true });
    }

    public async void Save(T obj, params string[] args)
    {
        var folder = args[0];
        var filename = args[1];
        var pathToFile = Path.Combine(folder, filename + ".json");
        await using var fs = File.Open(pathToFile, FileMode.OpenOrCreate);
        await JsonSerializer.SerializeAsync(fs, obj, new JsonSerializerOptions { WriteIndented = true });
    }
}