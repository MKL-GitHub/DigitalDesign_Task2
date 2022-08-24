using System.Text;

namespace Task2; 

/// <summary>
/// Реализует функционал работы с файлами.
/// </summary>
internal class FileSystemTools : IFileSystemTools
{
    /// <inheritdoc/>
    public async Task<string> ReadAsync(string filePath)
    {
        FileInfo fileInfo = new(filePath);

        if (!fileInfo.Exists)
        {
            throw new FileNotFoundException("Файл не найден", filePath);
        }

        return await File.ReadAllTextAsync(filePath, Encoding.UTF8);
    }

    /// <inheritdoc/>
    public async Task WriteAsync(string newFilePath, string text)
    {
        await File.WriteAllTextAsync(newFilePath, text, Encoding.UTF8);
    }
}
