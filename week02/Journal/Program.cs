using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Journal Project.");
        Journal journal = new();
        while (true)
        {
            Console.WriteLine("1. Write an entry");
            Console.WriteLine("2. List entries");
            Console.WriteLine("3. Save journal to file");
            Console.WriteLine("4. Load journal from file");
            Console.WriteLine("5. Quit");
            Console.Write("Please make a selection: ");
            string selection = Console.ReadLine();
            if (selection == "1")
            {
                journal.CreateEntry();
            }
            else if (selection == "2")
            {
                journal.ListEntries();
            }
            else if (selection == "3")
            {
                journal.SaveToFile();
            }
            else if (selection == "4")
            {
                journal.ReadFromFile();
            }
            else if (selection == "5" || selection == "q")
            {
                break;
            }
        }
        Console.WriteLine("Thanks for using the journal program.");
    }
}