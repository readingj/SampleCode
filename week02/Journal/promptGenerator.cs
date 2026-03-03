class PromptGenerator
{
    private Random _random = new(DateTime.Now.Millisecond);
    private List<string> _prompts = new()
    {
        "What was the best thing you ate today?",
        "Describe a dog you saw today",
        "What was your best spiritual thought for the day?",
        "Did you break anything today?",
        "Did you make anyone laugh today?"
    };
    // Don't reuse prompts until all have been used
    private List<int> used = new();
    public string GetPrompt()
    {
        if (used.Count == _prompts.Count)
        {
            used.Clear();
        }
        int index;
        while (true)
        {
            index = _random.Next(_prompts.Count);
            if (used.IndexOf(index) == -1)
            {
                break;
            }
        }
        used.Add(index);
        return _prompts[index];
    }
}