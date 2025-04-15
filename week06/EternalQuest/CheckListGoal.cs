using System;

namespace EternalQuest
{
    public class ChecklistGoal : Goal
    {
        private int _amountCompleted;
        private int _target;
        private int _bonus;

        public ChecklistGoal(string shortName, string description, int points, int target, int bonus)
            : base(shortName, description, points)
        {
            _target = target;
            _bonus = bonus;
            _amountCompleted = 0;
        }

        public override int RecordEvent()
        {
            if (!IsComplete())
            {
                _amountCompleted++;
                int score = _points;
                if (_amountCompleted == _target)
                {
                    score += _bonus;
                }
                return score;
            }
            else
            {
                Console.WriteLine("This checklist goal has already been completed.");
                return 0;
            }
        }

        public override bool IsComplete()
        {
            return _amountCompleted >= _target;
        }

        public override string GetDetailsString()
        {
            string checkbox = IsComplete() ? "[X]" : "[ ]";
            return $"{checkbox} {_shortName}: {_description} -- Completed: {_amountCompleted}/{_target}";
        }

        public override string GetStringRepresentation()
        {
            // Format: ChecklistGoal:shortName,description,points,amountCompleted,target,bonus
            return $"ChecklistGoal:{_shortName},{_description},{_points},{_amountCompleted},{_target},{_bonus}";
        }

        // Factory method to recreate a ChecklistGoal from a saved string.
        public static ChecklistGoal CreateFromString(string data)
        {
            // Expected data format: shortName,description,points,amountCompleted,target,bonus
            string[] parts = data.Split(',');
            if(parts.Length < 6)
            {
                throw new FormatException("Invalid format for ChecklistGoal");
            }
            string name = parts[0];
            string description = parts[1];
            int points = int.Parse(parts[2]);
            int amountCompleted = int.Parse(parts[3]);
            int target = int.Parse(parts[4]);
            int bonus = int.Parse(parts[5]);
            ChecklistGoal goal = new ChecklistGoal(name, description, points, target, bonus);
            goal._amountCompleted = amountCompleted;
            return goal;
        }
    }
}
