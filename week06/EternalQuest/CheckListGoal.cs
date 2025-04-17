using System;

// Checklist goal class - a goal that must be completed a certain number of times
public class ChecklistGoal : Goal
{
    // Private fields for encapsulation
    private int _targetCount;
    private int _currentCount;
    private int _bonusPoints;

    // Properties with getters and setters
    public int TargetCount { get { return _targetCount; } set { _targetCount = value; } }
    public int CurrentCount { get { return _currentCount; } set { _currentCount = value; } }
    public int BonusPoints { get { return _bonusPoints; } set { _bonusPoints = value; } }

    // Constructor
    public ChecklistGoal(string name, string description, int pointValue, int targetCount, int bonusPoints) 
        : base(name, description, pointValue)
    {
        if (targetCount <= 0)
        {
            throw new ArgumentException("Target count must be greater than zero.");
        }
        _targetCount = targetCount;
        _currentCount = 0;
        _bonusPoints = bonusPoints;
    }

    // Override RecordEvent to track progress and award bonus when completed
    public override int RecordEvent()
    {
        // Check if already completed
        if (_isComplete)
        {
            return 0; // No more points if already completed
        }
        
        _currentCount++;
        
        // Check if this completion achieves the target
        if (_currentCount >= _targetCount)
        {
            _isComplete = true;
            return PointValue + _bonusPoints; // Award regular points plus bonus
        }
        
        return PointValue; // Just the regular points
    }

    // Create a formatted display string for listing goals
    public override string GetDisplayString()
    {
        string completionMark = _isComplete ? "[X]" : "[ ]";
        string completionStatus = _isComplete ? " (COMPLETED!)" : "";
        return $"{completionMark} {Name} ({Description}) -- Completed {_currentCount}/{_targetCount} times{completionStatus}";
    }

    // Create a string representation for saving to a file
    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal:{Name},{Description},{PointValue},{_isComplete},{_targetCount},{_currentCount},{_bonusPoints}";
    }

    // Override the Initialize method to handle the additional fields
    public override void Initialize(string[] parts)
    {
        try
        {
            // First set the basic properties
            base.Initialize(parts);
            
            // Then get the checklist-specific values
            if (parts.Length > 5) _targetCount = int.Parse(parts[5]);
            if (parts.Length > 6) _currentCount = int.Parse(parts[6]);
            if (parts.Length > 7) _bonusPoints = int.Parse(parts[7]);
            
            // Make sure target count is valid
            if (_targetCount <= 0)
            {
                _targetCount = 1; // Set a safe default
                Console.WriteLine("Warning: Loaded goal had invalid target count. Set to 1.");
            }
            
            // Ensure isComplete is set correctly based on current count
            if (_currentCount >= _targetCount)
            {
                _isComplete = true;
            }
        }
        catch (Exception ex)
        {
            // Just log the error but don't throw - allows partial loading
            Console.WriteLine($"Warning when initializing ChecklistGoal: {ex.Message}");
            
            // Set safe defaults
            if (_targetCount <= 0) _targetCount = 1;
            if (_currentCount < 0) _currentCount = 0;
            if (_bonusPoints < 0) _bonusPoints = 0;
        }
    }
}