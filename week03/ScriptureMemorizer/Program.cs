using System;

namespace ScriptureMemorizer
{
    class Program
    {
        static void Main(string[] args)
        {
            ScriptureLibrary library = new ScriptureLibrary();
            Scripture scripture = library.SelectScripture();

            while (!scripture.AllWordsHidden())
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine();
                Console.WriteLine("Press Enter to hide words or type 'quit' to exit.");
                string input = Console.ReadLine();
                if (input.ToLower() == "quit")
                    break;
                scripture.HideRandomWords(3);
            }
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("All words are hidden. Program ended.");
        }
    }
}
