using System.Reflection.Metadata.Ecma335;

class Word
{
    private string _text;
    private bool _hidden;
    public Word(string text)
    {
        _text = text;
        _hidden = false;
    }
    public void Hide()
    {
        _hidden = true;
    }
    public string DisplayString()
    {
        string retval = _text;
        if (_hidden)
        {
            retval = new string('_', _text.Length);
        }
        return retval;
    }
    public bool Hidden => _hidden;
}