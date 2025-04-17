using System;

// Eternal goal class - a goal that is never complete but gives points each time
public class EternalGoal : Goal
{
    // Constructor
    public EternalGoal(string name, string description, int pointValue) 
        : base(name, description, pointValue)
    {
    }

    // Override RecordEvent to always return points but never mark as complete
    public override int RecordEvent()
    {
        // Eternal goals are never complete, but always give points
        return PointValue;
    }

    // Create a formatted display string for listing goals
    public override string GetDisplayString()
    {
        // Eternal goals are never complete, so always show empty checkbox
        return $"[ ] {Name} ({Description}) - Eternal";
    }

    // Create a string representation for saving to a file
    public override string GetStringRepresentation()
    {
        return $"EternalGoal:{Name},{Description},{PointValue},{_isComplete}";
    }
}
