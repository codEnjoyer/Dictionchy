using System.Text.Json;

namespace Dictionchy.Infrastructure;

public static class ClassLoader
{
    /// <summary>
    /// Загружает объект из JSON-файла
    /// </summary>
    /// <param name="folder">
    /// Путь к папке с JSON-файлом
    /// </param>
    /// <param name="filename">
    /// Имя JSON-файла
    /// </param>
    /// <example>
    /// ClassDumper.Load<Pet>("path/to/file", "filename")
    /// </example>
    public static async Task<T?> Load<T>(string folder, string filename)
    {
        var pathToFile = Path.Combine(folder, filename, ".json");
        if (!File.Exists(pathToFile))
        {
            return default;
        }

        await using var fs = File.Open(pathToFile, FileMode.Open);
        return await JsonSerializer.DeserializeAsync<T>(fs, new JsonSerializerOptions {WriteIndented = true});
    }
}