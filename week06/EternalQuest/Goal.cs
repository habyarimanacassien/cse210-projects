using System;

namespace EternalQuest
{
    public abstract class Goal
    {
        protected string _shortName;
        protected string _description;
        protected int _points;

        public Goal(string shortName, string description, int points)
        {
            _shortName = shortName;
            _description = description;
            _points = points;
        }

        // Record that the goal was accomplished. Returns the number of points earned.
        public abstract int RecordEvent();

        // Returns true if the goal is complete.
        public abstract bool IsComplete();

        // Returns a string with the goal details to display in a list.
        public virtual string GetDetailsString()
        {
            // Default implementation (for Simple and Eternal goals).
            return $"[ ] {_shortName}: {_description}";
        }

        // Returns a string representing the goal, which can be used for saving to a file.
        public abstract string GetStringRepresentation();
    }
}
