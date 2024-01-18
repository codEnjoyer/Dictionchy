using System.Text.Json;

namespace Dictionchy.Infrastructure;

public static class ClassDumper
{
    /// <summary>
    /// Выгружает объект в JSON-файл
    /// </summary>
    /// <param name="obj">
    /// Выгружаемый объект
    /// </param>
    /// <param name="folder">
    /// Папка, в которой будет сохранен JSON-файл
    /// </param>
    /// <param name="filename">
    /// Имя JSON-файла
    /// </param>
    /// <example>
    /// ClassDumper.Dump(obj, "path/to/file", "filename")
    /// </example>
    public static async void Dump<T>(T obj, string folder, string filename)
    {
        var pathToFile = Path.Combine(folder, filename + ".json");
        await using var fs = File.Open(pathToFile, FileMode.OpenOrCreate);
        await JsonSerializer.SerializeAsync(fs, obj, new JsonSerializerOptions {WriteIndented = true});
    }
}