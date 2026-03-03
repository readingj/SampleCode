class Scripture
{
    private Reference _reference;
    private List<Word> _words = new();
    private Random _prng = new(DateTime.Now.Millisecond);
    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        foreach (var word in text.Split())
        {
            _words.Add(new (word));
        }
    }
    public string DisplayString()
    {
        string retval = _reference.DisplayString();
        foreach (var word in _words)
        {
            retval += $" {word.DisplayString()}";
        }
        return retval;
    }
    public bool Hidden()
    {
        bool retval = true;
        foreach (var word in _words)
        {
            if (!word.Hidden)
            {
                retval = false;
                break;
            }
        }
        return retval;
    }
    public void HideWords()
    {
        int nVisible = 0;
        foreach (var word in _words)
        {
            if (!word.Hidden) ++nVisible;
        }
        int nToHide = _prng.Next(1, 4);
        if (nToHide > nVisible) nToHide = nVisible;
        while (true)
        {
            int index = _prng.Next(_words.Count);
            if (!_words[index].Hidden)
            {
                _words[index].Hide();
                --nToHide;
                if (nToHide == 0) break;
            }
        }
    }
}