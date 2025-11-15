using System;
using System.Collections.Generic;

namespace ScriptureMemorizer
{
    public class ScriptureLibrary
    {
        private List<Scripture> _scriptures;

        public ScriptureLibrary()
        {
            _scriptures = new List<Scripture>
            {
                new Scripture(new Reference("John", 3, 16), "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life."),
                new Scripture(new Reference("Proverbs", 3, 5, 6), "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths."),
                new Scripture(new Reference("2 Nephi", 2, 25), "Adam fell that men might be; and men are, that they might have joy.")
            };
        }

        public Scripture SelectScripture()
        {
            Console.WriteLine("Select a scripture to memorize:");
            for (int i = 0; i < _scriptures.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_scriptures[i].GetDisplayText().Split('\n')[0]}");
            }
            int choice = 1;
            while (true)
            {
                Console.Write("Enter number: ");
                string input = Console.ReadLine();
                if (int.TryParse(input, out choice) && choice >= 1 && choice <= _scriptures.Count)
                    break;
                Console.WriteLine("Invalid choice. Try again.");
            }
            return _scriptures[choice - 1];
        }
    }
}
