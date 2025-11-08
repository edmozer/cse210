using System;
using JournalApp;

namespace JournalApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Journal journal = new Journal();
            bool running = true;
            while (running)
            {
                Console.WriteLine("\nJournal Menu:");
                Console.WriteLine("1. Write a new entry");
                Console.WriteLine("2. Display the journal");
                Console.WriteLine("3. Save the journal to a file");
                Console.WriteLine("4. Load the journal from a file");
                Console.WriteLine("5. View prompts");
                Console.WriteLine("6. Add a custom prompt");
                Console.WriteLine("7. Search entries");
                Console.WriteLine("8. Edit an entry");
                Console.WriteLine("9. Export journal to JSON");
                Console.WriteLine("0. Quit");
                Console.Write("Choose an option: ");
                string? choice = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(choice))
                {
                    Console.WriteLine("No input detected. Try again.");
                    continue;
                }
                switch (choice)
                {
                    case "1":
                        string prompt = journal.GetRandomPrompt();
                        Console.WriteLine($"Prompt: {prompt}");
                        Console.Write("Your response: ");
                        string? response = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(response))
                        {
                            Console.WriteLine("No response entered. Entry not added.");
                            break;
                        }
                        journal.AddEntry(prompt, response);
                        Console.WriteLine("Entry added!");
                        break;
                    case "2":
                        journal.DisplayEntries();
                        break;
                    case "3":
                        Console.Write("Enter filename to save: ");
                        string? saveFile = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(saveFile))
                        {
                            Console.WriteLine("No filename entered. Try again.");
                            break;
                        }
                        journal.SaveToFile(saveFile);
                        Console.WriteLine("Journal saved.");
                        break;
                    case "4":
                        Console.Write("Enter filename to load: ");
                        string? loadFile = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(loadFile))
                        {
                            Console.WriteLine("No filename entered. Try again.");
                            break;
                        }
                        journal.LoadFromFile(loadFile);
                        Console.WriteLine("Journal loaded.");
                        break;
                    case "5":
                        Console.WriteLine("Prompts:");
                        foreach (var p in typeof(Journal).GetField("prompts", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(journal) as System.Collections.Generic.List<string>)
                        {
                            Console.WriteLine(p);
                        }
                        break;
                    case "6":
                        Console.Write("Enter your custom prompt: ");
                        string? customPrompt = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(customPrompt))
                        {
                            Console.WriteLine("No prompt entered. Try again.");
                            break;
                        }
                        (typeof(Journal).GetField("prompts", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(journal) as System.Collections.Generic.List<string>)?.Add(customPrompt);
                        Console.WriteLine("Custom prompt added.");
                        break;
                    case "7":
                        Console.Write("Enter keyword to search: ");
                        string? keyword = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(keyword))
                        {
                            Console.WriteLine("No keyword entered. Try again.");
                            break;
                        }
                        var results = journal.SearchEntries(keyword);
                        if (results.Count == 0)
                        {
                            Console.WriteLine("No entries found matching your search.");
                        }
                        else
                        {
                            Console.WriteLine($"Found {results.Count} entries:");
                            foreach (var entry in results)
                            {
                                Console.WriteLine(entry);
                            }
                        }
                        break;
                    case "8":
                        Console.WriteLine($"There are {journal.EntryCount} entries.");
                        Console.Write("Enter entry number to edit (starting from 1): ");
                        string? idxStr = Console.ReadLine();
                        if (!int.TryParse(idxStr, out int idx) || idx < 1 || idx > journal.EntryCount)
                        {
                            Console.WriteLine("Invalid entry number.");
                            break;
                        }
                        Console.Write("Enter new response: ");
                        string? newResp = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(newResp))
                        {
                            Console.WriteLine("No response entered. Try again.");
                            break;
                        }
                        if (journal.EditEntry(idx - 1, newResp))
                            Console.WriteLine("Entry updated.");
                        else
                            Console.WriteLine("Failed to update entry.");
                        break;
                    case "9":
                        Console.Write("Enter filename to export as JSON: ");
                        string? jsonFile = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(jsonFile))
                        {
                            Console.WriteLine("No filename entered. Try again.");
                            break;
                        }
                        journal.ExportToJson(jsonFile);
                        Console.WriteLine("Journal exported to JSON.");
                        break;
                    case "0":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
            Console.WriteLine("Goodbye!");
        }
    }
}


