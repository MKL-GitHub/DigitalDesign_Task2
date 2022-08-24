namespace Task2;

class Program
{
    private const string FILE_PATH = "Война и мир.txt"; 
    private const string NEW_FILE_PATH = "result.txt";

    public static void Main(string[] args)
    {
        CreateUniqueWordsFile(new FileSystemTools()).Wait();
    }

    private static async Task CreateUniqueWordsFile(IFileSystemTools fileSystemTools)
    {
        TextParser textParser = new();

        var readText = await fileSystemTools.ReadAsync(FILE_PATH);
        var sortedUniqueWords = await textParser.SortAsync(readText);
        await fileSystemTools.WriteAsync(NEW_FILE_PATH, sortedUniqueWords);
    }
}
