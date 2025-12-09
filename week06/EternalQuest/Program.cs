using System;

class Program
{
    static void Main(string[] args)
    {
        // Exceeding Requirements:
        // I have added a leveling and ranking system based on the user's score.
        // The user gains levels every 1000 points and achieves new ranks (Novice, Apprentice, etc.) at certain milestones.
        // This is displayed in the player info.

        GoalManager manager = new GoalManager();
        manager.Start();
    }
}
