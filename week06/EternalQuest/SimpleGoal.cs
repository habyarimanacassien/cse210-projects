using System;

// Simple goal class - a one-time goal that can be completed once
public class SimpleGoal : Goal
{
    // Constructor
    public SimpleGoal(string name, string description, int pointValue) 
        : base(name, description, pointValue)
    {
    }

    // Override RecordEvent to mark as complete and return points
    public override int RecordEvent()
    {
        if (!_isComplete)
        {
            _isComplete = true;
            return PointValue;
        }
        
        // Already completed, no more points
        return 0;
    }

    // Create a formatted display string for listing goals
    public override string GetDisplayString()
    {
        string completionMark = _isComplete ? "[X]" : "[ ]";
        return $"{completionMark} {Name} ({Description})";
    }

    // Create a string representation for saving to a file
    public override string GetStringRepresentation()
    {
        return $"SimpleGoal:{Name},{Description},{PointValue},{_isComplete}";
    }
}
