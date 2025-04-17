using System;

// Negative goal class - a goal that deducts points for bad habits
// This is an addition beyond the base requirements to show creativity
public class NegativeGoal : Goal
{
    // Private field for tracking occurrences
    private int _occurrenceCount;

    // Property with getter and setter
    public int OccurrenceCount { get { return _occurrenceCount; } set { _occurrenceCount = value; } }

    // Constructor
    public NegativeGoal(string name, string description, int pointValue) 
        : base(name, description, pointValue)
    {
        _occurrenceCount = 0;
    }

    // Override RecordEvent to deduct points (negative points value)
    public override int RecordEvent()
    {
        _occurrenceCount++;
        
        // Return negative points (the point value should be set as a negative number)
        return PointValue;
    }

    // Create a formatted display string for listing goals
    public override string GetDisplayString()
    {
        // Negative goals are never "complete" in the traditional sense
        return $"[!] {Name} ({Description}) -- Avoid! (Occurred {_occurrenceCount} times)";
    }

    // Create a string representation for saving to a file
    public override string GetStringRepresentation()
    {
        return $"NegativeGoal:{Name},{Description},{PointValue},{_isComplete},{_occurrenceCount}";
    }

    // Override the Initialize method to handle the additional fields
    public override void Initialize(string[] parts)
    {
        base.Initialize(parts);
        _occurrenceCount = int.Parse(parts[5]);
    }
}
