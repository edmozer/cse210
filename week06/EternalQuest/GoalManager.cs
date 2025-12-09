using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        while (true)
        {
            Console.WriteLine();
            DisplayPlayerInfo();
            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");
            
            string choice = Console.ReadLine() ?? "";

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoalDetails();
                    break;
                case "3":
                    SaveGoals();
                    break;
                case "4":
                    LoadGoals();
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "6":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"You have {_score} points.");
        int level = _score / 1000 + 1;
        string rank = "Novice";
        if (_score > 500) rank = "Apprentice";
        if (_score > 1000) rank = "Journeyman";
        if (_score > 2500) rank = "Expert";
        if (_score > 5000) rank = "Master";
        
        Console.WriteLine($"Level: {level} ({rank})");
    }

    public void ListGoalNames()
    {
        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString().Split(']')[1].Trim().Split('(')[0].Trim()}");
        }
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        string type = Console.ReadLine() ?? "";

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine() ?? "";
        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine() ?? "";
        Console.Write("What is the amount of points associated with this goal? ");
        string points = Console.ReadLine() ?? "0";

        if (type == "1")
        {
            _goals.Add(new SimpleGoal(name, description, points));
        }
        else if (type == "2")
        {
            _goals.Add(new EternalGoal(name, description, points));
        }
        else if (type == "3")
        {
            Console.Write("How many times does this goal need to be accomplished for a bonus? ");
            int target = int.Parse(Console.ReadLine() ?? "0");
            Console.Write("What is the bonus for accomplishing it that many times? ");
            int bonus = int.Parse(Console.ReadLine() ?? "0");
            _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
        }
    }

    public void RecordEvent()
    {
        ListGoalNames();
        Console.Write("Which goal did you accomplish? ");
        int index = int.Parse(Console.ReadLine() ?? "0") - 1;

        if (index >= 0 && index < _goals.Count)
        {
            int pointsEarned = _goals[index].RecordEvent();
            _score += pointsEarned;
            Console.WriteLine($"Congratulations! You have earned {pointsEarned} points!");
            Console.WriteLine($"You now have {_score} points.");
        }
    }

    public void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine() ?? "";

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(_score);
            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }
    }

    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine() ?? "";

        if (File.Exists(filename))
        {
            string[] lines = File.ReadAllLines(filename);
            _score = int.Parse(lines[0]);
            _goals.Clear();

            for (int i = 1; i < lines.Length; i++)
            {
                string line = lines[i];
                string[] parts = line.Split(':');
                string type = parts[0];
                string[] details = parts[1].Split(',');

                if (type == "SimpleGoal")
                {
                    SimpleGoal goal = new SimpleGoal(details[0], details[1], details[2]);
                    if (bool.Parse(details[3]))
                    {
                        goal.RecordEvent(); // Mark as complete without adding points (since score is loaded separately)
                        // Wait, RecordEvent adds points in my implementation if I call it.
                        // I should probably have a way to set complete without returning points or just rely on the fact that I already loaded the score.
                        // Actually, RecordEvent returns points but doesn't modify _score directly in the class, the manager does.
                        // But SimpleGoal.RecordEvent checks if not complete.
                        // If I call RecordEvent here, it will return points, but I am not adding them to _score.
                        // However, SimpleGoal.RecordEvent sets _isComplete = true.
                        // So calling it is fine to set the state, as long as I ignore the return value.
                    }
                    _goals.Add(goal);
                }
                else if (type == "EternalGoal")
                {
                    _goals.Add(new EternalGoal(details[0], details[1], details[2]));
                }
                else if (type == "ChecklistGoal")
                {
                    ChecklistGoal goal = new ChecklistGoal(details[0], details[1], details[2], int.Parse(details[4]), int.Parse(details[3]));
                    goal.SetAmountCompleted(int.Parse(details[5]));
                    _goals.Add(goal);
                }
            }
        }
    }
}
