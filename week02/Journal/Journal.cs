class Journal
{
    private List<Entry> _entries = new();
    const string _fileSaveFileName = ".fileNameSave.txt";
    private string _lastFileName = null;
public Journal()
    {
        InitializeLastFileName();
    }
    public void CreateEntry()
    {
        _entries.Add(new());
    }
    public void ListEntries()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("There are no entries yet");
        }
        else
        {
            int index = 1;
            foreach (var entry in _entries)
            {
                Console.WriteLine($"Entry {index}\n{entry.ToTextString()}");
                ++index;
            }
        }
    }
    public void SaveToFile()
    {
        GetLastFileName("saving");
        using StreamWriter writer = new(_lastFileName);
        foreach (var entry in _entries)
        {
            writer.WriteLine(entry.ToFileString());
        }
    }
    public void ReadFromFile()
    {
        GetLastFileName("saving");
        if (File.Exists(_lastFileName))
        {
            _entries.Clear();
            using StreamReader reader = new(_lastFileName);
            while (true)
            {
                string input = reader.ReadLine();
                if (input is null)
                {
                    break;
                }
                else
                {
                    _entries.Add(new(input));
                }
            }
        }
        else
        {
            Console.WriteLine("That file does not exist");
        }
    }
    private void InitializeLastFileName()
    {
        if (File.Exists(_fileSaveFileName))
        {
            using StreamReader reader = new (_fileSaveFileName);
            _lastFileName = reader.ReadLine();
        }
        else
        {
            _lastFileName = "journal.txt";
        }
    }
    private void GetLastFileName(string op)
    {
        Console.Write($"Please enter filename for {op} (default '{_lastFileName}'): ");
        string input = Console.ReadLine();
        if (input is null || input == "")
        {
            input = _lastFileName;
        }
        _lastFileName = input;
        using StreamWriter writer = new(_fileSaveFileName);
        writer.WriteLine(_lastFileName);
    }
}