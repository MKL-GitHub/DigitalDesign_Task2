namespace Task2;

/// <summary>
/// Содержит вспомогательные инструменты для работы с файловой системой.
/// </summary>
internal interface IFileSystemTools
{
    /// <summary>
    /// Асинхронно считывает файл по указанному пути.
    /// </summary>
    /// <param name="path">Путь к файлу.</param>
    /// <returns>Прочитанный текст файла.</returns>
    Task<string> ReadAsync(string path);

    /// <summary>
    /// Асинхронно записывает строку в новый файл по указанному пути.
    /// </summary>
    /// <param name="path">Путь к файлу.</param>
    /// <param name="value">Строка для записи в файл.</param>
    /// <returns>Возвращает задачу выполнения функции.</returns>
    Task WriteAsync(string path, string value);
}
