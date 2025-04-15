using System;

namespace EternalQuest
{
    public class SimpleGoal : Goal
    {
        private bool _isComplete;

        public SimpleGoal(string shortName, string description, int points)
            : base(shortName, description, points)
        {
            _isComplete = false;
        }

        public override int RecordEvent()
        {
            if (!_isComplete)
            {
                _isComplete = true;
                return _points;
            }
            else
            {
                Console.WriteLine("This goal has already been completed.");
                return 0;
            }
        }

        public override bool IsComplete()
        {
            return _isComplete;
        }

        public override string GetDetailsString()
        {
            string checkbox = _isComplete ? "[X]" : "[ ]";
            return $"{checkbox} {_shortName}: {_description}";
        }

        public override string GetStringRepresentation()
        {
            // Format: SimpleGoal:shortName,description,points,isComplete
            return $"SimpleGoal:{_shortName},{_description},{_points},{_isComplete}";
        }

        // Factory method to recreate a SimpleGoal from a saved string.
        public static SimpleGoal CreateFromString(string data)
        {
            // Expected data format: shortName,description,points,isComplete
            string[] parts = data.Split(',');
            if(parts.Length < 4)
            {
                throw new FormatException("Invalid format for SimpleGoal");
            }
            string name = parts[0];
            string description = parts[1];
            int points = int.Parse(parts[2]);
            bool isComplete = bool.Parse(parts[3]);
            SimpleGoal goal = new SimpleGoal(name, description, points);
            if(isComplete)
            {
                // Set the completion status for a loaded goal.
                goal._isComplete = true;
            }
            return goal;
        }
    }
}
