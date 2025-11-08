
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace JournalApp
{
    public class Journal
    {
        private List<Entry> entries = new List<Entry>();
        private List<string> prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"
        };
        private Random random = new Random();

        public void AddEntry(string prompt, string response)
        {
            string date = DateTime.Now.ToString("yyyy-MM-dd");
            entries.Add(new Entry(date, prompt, response));
        }

        public List<Entry> SearchEntries(string keyword)
        {
            var results = new List<Entry>();
            foreach (var entry in entries)
            {
                if (entry.Prompt.Contains(keyword, StringComparison.OrdinalIgnoreCase) || entry.Response.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                {
                    results.Add(entry);
                }
            }
            return results;
        }

        public bool EditEntry(int index, string newResponse)
        {
            if (index >= 0 && index < entries.Count)
            {
                entries[index].Response = newResponse;
                return true;
            }
            return false;
        }

        public void ExportToJson(string filename)
        {
            if (string.IsNullOrWhiteSpace(filename)) return;
            var json = JsonSerializer.Serialize(entries);
            File.WriteAllText(filename, json);
        }

        public int EntryCount => entries.Count;

        public string GetRandomPrompt()
        {
            int index = random.Next(prompts.Count);
            return prompts[index];
        }

        public void DisplayEntries()
        {
            int i = 1;
            foreach (var entry in entries)
            {
                Console.WriteLine($"Entry #{i}:");
                Console.WriteLine(entry);
                i++;
            }
        }

        public void SaveToFile(string filename)
        {
            if (string.IsNullOrWhiteSpace(filename)) return;
            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (var entry in entries)
                {
                    writer.WriteLine($"{entry.Date}|{entry.Prompt}|{entry.Response}");
                }
            }
        }

        public void LoadFromFile(string filename)
        {
            if (string.IsNullOrWhiteSpace(filename) || !File.Exists(filename)) return;
            entries.Clear();
            foreach (var line in File.ReadAllLines(filename))
            {
                var parts = line.Split('|');
                if (parts.Length == 3)
                {
                    entries.Add(new Entry(parts[0], parts[1], parts[2]));
                }
            }
        }
    }
}
