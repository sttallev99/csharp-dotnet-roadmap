namespace WordFrequency;

public static class WordCounter
{
    private static readonly char[] Separators = [' ', '.', ',', '!', '?', ';', ':', '\n', '\r', '\t'];

    public static Dictionary<string, int> Count(string text)
    {
        var counts = new Dictionary<string, int>();

        if(string.IsNullOrWhiteSpace(text))
            return counts;

        string[] words = text.Split(Separators, StringSplitOptions.RemoveEmptyEntries);

        foreach (string raw in words)
        {
            string word = raw.ToLowerInvariant();
            counts[word] = counts.GetValueOrDefault(word, 0) + 1;
        }

        return counts;
    }

    public static IEnumerable<(string Word, int Count)> Top(Dictionary<string, int> counts, int n)
    {
        ArgumentNullException.ThrowIfNull(counts);
        ArgumentOutOfRangeException.ThrowIfNegative(n);

        return counts
            .OrderByDescending(pair => pair.Value)
            .ThenBy(pair => pair.Key, StringComparer.Ordinal)
            .Take(n)
            .Select(pair => (pair.Key, pair.Value));
    }
}