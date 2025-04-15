using System;

namespace EternalQuest
{
    public class EternalGoal : Goal
    {
        public EternalGoal(string shortName, string description, int points)
            : base(shortName, description, points)
        {
        }

        public override int RecordEvent()
        {
            return _points;
        }

        public override bool IsComplete()
        {
            // Eternal goals are never complete.
            return false;
        }

        public override string GetDetailsString()
        {
            return $"[ ] {_shortName}: {_description}";
        }

        public override string GetStringRepresentation()
        {
            // Format: EternalGoal:shortName,description,points
            return $"EternalGoal:{_shortName},{_description},{_points}";
        }

        // Factory method to recreate an EternalGoal from a saved string.
        public static EternalGoal CreateFromString(string data)
        {
            // Expected data format: shortName,description,points
            string[] parts = data.Split(',');
            if(parts.Length < 3)
            {
                throw new FormatException("Invalid format for EternalGoal");
            }
            string name = parts[0];
            string description = parts[1];
            int points = int.Parse(parts[2]);
            return new EternalGoal(name, description, points);
        }
    }
}
