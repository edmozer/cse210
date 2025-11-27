using System;
using System.Collections.Generic;

namespace Mindfulness
{
    public class ListingActivity : Activity
    {
        private int _count;
        private List<string> _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

        public ListingActivity() : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
        {
        }

        public void Run()
        {
            DisplayStartingMessage();

            Console.WriteLine("List as many responses you can to the following prompt:");
            Console.WriteLine($"--- {GetRandomPrompt()} ---");
            Console.Write("You may begin in: ");
            ShowCountDown(5);
            Console.WriteLine();

            List<string> items = GetListFromUser();

            _count = items.Count;
            Console.WriteLine($"You listed {_count} items!");

            DisplayEndingMessage();
        }

        private string GetRandomPrompt()
        {
            Random random = new Random();
            int index = random.Next(_prompts.Count);
            return _prompts[index];
        }

        private List<string> GetListFromUser()
        {
            List<string> items = new List<string>();
            DateTime startTime = DateTime.Now;
            DateTime endTime = startTime.AddSeconds(_duration);

            while (DateTime.Now < endTime)
            {
                Console.Write("> ");
                string? entry = Console.ReadLine();
                if (!string.IsNullOrEmpty(entry))
                {
                    items.Add(entry);
                }
            }
            return items;
        }
    }
}
