using System;
using System.Collections.Generic;

namespace Mindfulness
{
    public class ReflectionActivity : Activity
    {
        private List<string> _prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        private List<string> _questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };

        public ReflectionActivity() : base("Reflection Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
        {
        }

        public void Run()
        {
            DisplayStartingMessage();
            DisplayPrompt();
            DisplayQuestions();
            DisplayEndingMessage();
        }

        private string GetRandomPrompt()
        {
            Random random = new Random();
            int index = random.Next(_prompts.Count);
            return _prompts[index];
        }

        private string GetRandomQuestion()
        {
            Random random = new Random();
            int index = random.Next(_questions.Count);
            return _questions[index];
        }

        private void DisplayPrompt()
        {
            string prompt = GetRandomPrompt();
            Console.WriteLine();
            Console.WriteLine("Consider the following prompt:");
            Console.WriteLine();
            Console.WriteLine($"--- {prompt} ---");
            Console.WriteLine();
            Console.WriteLine("When you have something in mind, press enter to continue.");
            Console.ReadLine();
        }

        private void DisplayQuestions()
        {
            Console.WriteLine("Now ponder on each of the following questions as they related to this experience.");
            Console.Write("You may begin in: ");
            ShowCountDown(5);
            Console.Clear();

            DateTime startTime = DateTime.Now;
            DateTime endTime = startTime.AddSeconds(_duration);

            // Creativity: Ensure no duplicate questions in a single session until all are used.
            List<int> usedQuestionIndices = new List<int>();
            Random random = new Random();

            while (DateTime.Now < endTime)
            {
                string question = GetUniqueRandomQuestion(usedQuestionIndices, random);
                Console.Write($"> {question} ");
                ShowSpinner(10); // Pause for reflection
                Console.WriteLine();
            }
        }

        private string GetUniqueRandomQuestion(List<int> usedIndices, Random random)
        {
            if (usedIndices.Count == _questions.Count)
            {
                usedIndices.Clear(); // Reset if all questions used
            }

            int index;
            do
            {
                index = random.Next(_questions.Count);
            } while (usedIndices.Contains(index));

            usedIndices.Add(index);
            return _questions[index];
        }
    }
}
