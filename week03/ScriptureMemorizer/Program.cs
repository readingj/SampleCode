using System;

// Exceeded requirements by:
// 1. Making sure new words are hidden on each loop
// 2. Randomly selecting a scripture from a list

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the ScriptureMemorizer Project.");
        Random prng = new(DateTime.Now.Millisecond);
        List<Scripture> scriptures = new()
        {new (new("John", "3", "16"), "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life."),
        new (new ("D&C", "14", "7"), "And if ye keep my commandments and endure to the end ye shall have eternal life, which gift is the greatest of all the gifts of God."),
        new (new ("Matthew", "2", "12-13"), "And being warned of God in a dream that they should not return to Herod, they departed into their own country another way. And when they were departed, behold, the angel of the Lord appeareth to Joseph in a dream, saying, Arise, and take the young child and his mother, and flee into Egypt, and be thou there until I bring thee word: for Herod will seek the young child to destroy him."),
        new (new ("Moroni", "10", "5"), "And by the power of the Holy Ghost ye may know the truth of all things.")
        };
        Scripture scripture = scriptures[prng.Next(scriptures.Count)];
        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.DisplayString());
            if (scripture.Hidden())
            {
                Console.WriteLine("You have completely hidden the scripture");
                break;
            }
            Console.Write("Hit enter to continue, 'quit' to quit: ");
            scripture.HideWords();
            string response = Console.ReadLine();
            if (response == "q" || response == "quit")
            {
                Console.WriteLine("Exiting at your command");
                break;
            }

        }
    }
}