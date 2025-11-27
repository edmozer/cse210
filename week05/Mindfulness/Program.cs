using System;

namespace Mindfulness
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creativity:
            // I exceeded the requirements by ensuring that the Reflection Activity does not repeat questions
            // until all questions have been shown at least once in the current session.
            // This logic is implemented in the ReflectionActivity.cs file using a list to track used indices.

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Menu Options:");
                Console.WriteLine("  1. Start breathing activity");
                Console.WriteLine("  2. Start reflecting activity");
                Console.WriteLine("  3. Start listing activity");
                Console.WriteLine("  4. Quit");
                Console.Write("Select a choice from the menu: ");

                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    BreathingActivity breathingActivity = new BreathingActivity();
                    breathingActivity.Run();
                }
                else if (choice == "2")
                {
                    ReflectionActivity reflectionActivity = new ReflectionActivity();
                    reflectionActivity.Run();
                }
                else if (choice == "3")
                {
                    ListingActivity listingActivity = new ListingActivity();
                    listingActivity.Run();
                }
                else if (choice == "4")
                {
                    break;
                }
            }
        }
    }
}
