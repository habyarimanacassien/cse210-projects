using System;
using System.Collections.Generic;
using System.IO;

namespace EternalQuest
{
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
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine($"Your current score is: {_score}");
                Console.WriteLine("Menu Options:");
                Console.WriteLine("1. Create New Goal");
                Console.WriteLine("2. List Goals");
                Console.WriteLine("3. Record Event");
                Console.WriteLine("4. Save Goals");
                Console.WriteLine("5. Load Goals");
                Console.WriteLine("6. Quit");
                Console.Write("Select a choice from the menu: ");
                string choice = Console.ReadLine();
                Console.WriteLine();

                switch(choice)
                {
                    case "1":
                        CreateGoal();
                        break;
                    case "2":
                        ListGoals();
                        break;
                    case "3":
                        RecordEvent();
                        break;
                    case "4":
                        SaveGoals();
                        break;
                    case "5":
                        LoadGoals();
                        break;
                    case "6":
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
                Console.WriteLine();
            }
        }

        private void ListGoals()
        {
            Console.WriteLine("Goals:");
            for (int i = 0; i < _goals.Count; i++)
            {
                Console.WriteLine($"{i+1}. {_goals[i].GetDetailsString()}");
            }
        }

        private void CreateGoal()
        {
            Console.WriteLine("The types of Goals are:");
            Console.WriteLine("1. Simple Goal");
            Console.WriteLine("2. Eternal Goal");
            Console.WriteLine("3. Checklist Goal");
            Console.Write("Which type of goal would you like to create? ");
            string input = Console.ReadLine();

            Console.Write("Enter the goal name: ");
            string name = Console.ReadLine();
            Console.Write("Enter a short description: ");
            string description = Console.ReadLine();
            Console.Write("Enter the points associated with this goal: ");
            int points = int.Parse(Console.ReadLine());

            Goal newGoal = null;
            switch(input)
            {
                case "1":
                    newGoal = new SimpleGoal(name, description, points);
                    break;
                case "2":
                    newGoal = new EternalGoal(name, description, points);
                    break;
                case "3":
                    Console.Write("Enter the number of times this goal needs to be completed: ");
                    int target = int.Parse(Console.ReadLine());
                    Console.Write("Enter the bonus points for completing the goal: ");
                    int bonus = int.Parse(Console.ReadLine());
                    newGoal = new ChecklistGoal(name, description, points, target, bonus);
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
            if (newGoal != null)
            {
                _goals.Add(newGoal);
                Console.WriteLine("Goal created successfully.");
            }
        }

        private void RecordEvent()
        {
            ListGoals();
            Console.Write("Which goal did you accomplish? Enter the number: ");
            int goalNumber;
            if (int.TryParse(Console.ReadLine(), out goalNumber))
            {
                if (goalNumber > 0 && goalNumber <= _goals.Count)
                {
                    Goal selectedGoal = _goals[goalNumber - 1];
                    int pointsEarned = selectedGoal.RecordEvent();
                    _score += pointsEarned;
                    Console.WriteLine($"You earned {pointsEarned} points!");
                }
                else
                {
                    Console.WriteLine("Invalid goal number.");
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid number.");
            }
        }

        private void SaveGoals()
        {
            Console.Write("Enter the filename to save your goals (e.g., goals.txt): ");
            string fileName = Console.ReadLine();

            try
            {
                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    // First line saves the current score.
                    writer.WriteLine(_score);
                    foreach (Goal goal in _goals)
                    {
                        writer.WriteLine(goal.GetStringRepresentation());
                    }
                }
                Console.WriteLine("Goals saved successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving goals: {ex.Message}");
            }
        }

        private void LoadGoals()
        {
            Console.Write("Enter the filename to load your goals: ");
            string fileName = Console.ReadLine();

            if (File.Exists(fileName))
            {
                try
                {
                    string[] lines = File.ReadAllLines(fileName);
                    if (lines.Length > 0)
                    {
                        // First line is the saved score.
                        _score = int.Parse(lines[0]);
                        _goals.Clear();
                        for (int i = 1; i < lines.Length; i++)
                        {
                            string line = lines[i];
                            // Each line is formatted as Type:data
                            string[] parts = line.Split(':', 2);
                            if (parts.Length < 2)
                            {
                                continue;
                            }
                            string type = parts[0];
                            string data = parts[1];

                            switch (type)
                            {
                                case "SimpleGoal":
                                    _goals.Add(SimpleGoal.CreateFromString(data));
                                    break;
                                case "EternalGoal":
                                    _goals.Add(EternalGoal.CreateFromString(data));
                                    break;
                                case "ChecklistGoal":
                                    _goals.Add(ChecklistGoal.CreateFromString(data));
                                    break;
                                default:
                                    Console.WriteLine($"Unknown goal type: {type}");
                                    break;
                            }
                        }
                        Console.WriteLine("Goals loaded successfully.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error loading goals: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("File not found.");
            }
        }
    }
}