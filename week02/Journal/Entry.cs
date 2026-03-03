class Entry
{
    private string _date;
    private string _prompt;
    private string _text;
    private static PromptGenerator _promptGenerator = new();
    public Entry()
    {
        _date = DateTime.Now.ToString();
        _prompt = _promptGenerator.GetPrompt();
        Console.WriteLine(_prompt);
        Console.Write("> ");
        _text = Console.ReadLine();
    }
    public Entry(string fileString)
    {
        string[] pieces = fileString.Split("~~");
        if (pieces.Count() != 3)
        {
            Console.WriteLine("Error reading entry - Journal is corrupted");
        }
        else
        {
            _date = pieces[0];
            _prompt = pieces[1];
            _text = pieces[2];
        }
    }
    public string ToTextString()
    {
        return $"Date: {_date}\nPrompt: {_prompt}\n{_text}";
    }
    public string ToFileString()
    {
        return $"{_date}~~{_prompt}~~{_text}";
    }
}