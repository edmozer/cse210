using System;

namespace ScriptureMemorizer
{
    class Program
    {
        static void Main(string[] args)
        {
            // Exceeding requirements: See comments below for details.
            // This program supports multi-verse references and only hides words that are not already hidden.
            // It also allows the user to choose a scripture from a small library at startup.

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
                scripture.HideRandomWords(3); // Hide 3 words per round
            }
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("All words are hidden. Program ended.");
        }
    }
}

// Exceeding requirements:
// - User can choose from a small scripture library at startup.
// - Only non-hidden words are selected to hide each round.
// - Multi-verse references supported.
// - All code follows encapsulation principles.
