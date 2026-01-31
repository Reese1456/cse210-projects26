public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        foreach (string word in text.Split(' '))
        {
            _words.Add(new Word(word));
        }
    }

    public void HideRandomWords(int count)
{
    Random r = new Random();

    List<Word> visibleWords = _words.Where(w => !w.IsHidden()).ToList();

    if (visibleWords.Count < count)
        count = visibleWords.Count;

    for (int i = 0; i < count; i++)
    {
        int index = r.Next(visibleWords.Count);
        visibleWords[index].Hide();

        visibleWords.RemoveAt(index);
    }
}

    public bool AllHidden()
    {
        return _words.All(w => w.IsHidden());
    }

    public string GetDisplayText()
    {
        return $"{_reference.GetDisplayText()}:\n" +
               string.Join(" ", _words.Select(w => w.GetDisplayText()));
    }
}
