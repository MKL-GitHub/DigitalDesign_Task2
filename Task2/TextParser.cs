using System.Text;

namespace Task2;

/// <summary>
/// Реализует функционал разбора текста.
/// </summary>
internal class TextParser
{
    private readonly Dictionary<string, int> _uniqueWords = new();
    
    private List<KeyValuePair<string, int>> _sortedWords = null!;
    private string _text = string.Empty;
    
    /// <summary>
    /// Асинхронно находит в строке все уникальные слова, считает их и сортирует.
    /// </summary>
    /// <param name="text">Строка с полным текстом.</param>
    /// <returns>Строка с отсортированными уникальными словами.</returns>
    public async Task<string> SortAsync(string text)
    {
        _text = text;
        
        await Task.Run(Sort);

        return GetOutput();
    }

    private void Sort()
    {
        CollectUniqueWords();
        SortUniqueWords();
    }

    private void CollectUniqueWords()
    {
        StringBuilder wordBuilder = new();

        for (int i = 0; i < _text.Length; i++)
        {
            if (IsValid(i))
            {
                wordBuilder.Append(_text[i]);

                if (i != _text.Length - 1) continue;
            }

            if (wordBuilder.Length == 0) continue;

            TryAddUniqueWord(wordBuilder.ToString().ToLower());
            wordBuilder.Clear();
        }
    }

    private void SortUniqueWords()
    {
        _sortedWords = _uniqueWords.ToList();

        _sortedWords.Sort(Compare);
    }

    private string GetOutput()
    {
        StringBuilder output = new();

        for (int i = 0; i < _sortedWords.Count; i++)
        {
            int leftShift = 5 - i.ToString().Length > 0 
                ? 5 - i.ToString().Length 
                : 1;

            int rightShift = 35 - _sortedWords[i].Key.Length > 0 
                ? 35 - _sortedWords[i].Key.Length 
                : 1;

            string spacesLeft = new string(' ', leftShift);
            string spacesRight = new string('-', rightShift);

            output.AppendLine(
                $"{i}) {spacesLeft} {_sortedWords[i].Key} " +
                $"{spacesRight} {_sortedWords[i].Value}");
        }

        return output.ToString();
    }

    private void TryAddUniqueWord(string word)
    {
        if (_uniqueWords.ContainsKey(word))
        {
            _uniqueWords[word]++;
        }
        else
        {
            _uniqueWords.Add(word, 1);
        }
    }

    private bool IsValid(int index)
    {
        if (_text.Length - 1 < index + 1) return false;

        return IsLetter(index) || _text[index] == '\'' ||
            IsLetter(index - 1) && IsLetter(index + 1) && _text[index] == '-';

        bool IsLetter(int index)
        {
            return char.IsLetter(_text[index]);
        }
    }

    private int Compare(KeyValuePair<string, int> first, KeyValuePair<string, int> second)
    {
        if (first.Value == second.Value)
        {
            return first.Key.CompareTo(second.Key);
        }

        return second.Value - first.Value;
    }
}
