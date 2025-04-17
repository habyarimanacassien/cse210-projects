using System;

// Progressive goal class - a goal that tracks progress towards a larger accomplishment
// This is an addition beyond the base requirements to show creativity
public class ProgressiveGoal : Goal
{
    // Private fields for encapsulation
    private int _totalSteps;
    private int _currentStep;
    private int _finalBonus;

    // Properties with getters and setters
    public int TotalSteps { get { return _totalSteps; } set { _totalSteps = value; } }
    public int CurrentStep { get { return _currentStep; } set { _currentStep = value; } }
    public int FinalBonus { get { return _finalBonus; } set { _finalBonus = value; } }

    // Constructor
    public ProgressiveGoal(string name, string description, int pointValue, int totalSteps, int finalBonus) 
        : base(name, description, pointValue)
    {
        _totalSteps = totalSteps;
        _currentStep = 0;
        _finalBonus = finalBonus;
    }

    // Override RecordEvent to track progress towards the large goal
    public override int RecordEvent()
    {
        _currentStep++;
        
        // Check if this step completes the goal
        if (_currentStep >= _totalSteps)
        {
            _isComplete = true;
            return PointValue + _finalBonus; // Award points plus final bonus
        }
        
        // Calculate percentage complete and award partial points
        double percentComplete = (double)_currentStep / _totalSteps;
        int earnedPoints = (int)(PointValue * percentComplete);
        
        return earnedPoints;
    }

    // Create a formatted display string for listing goals
    public override string GetDisplayString()
    {
        string completionMark = _isComplete ? "[X]" : "[ ]";
        int progressPercent = (int)(((double)_currentStep / _totalSteps) * 100);
        return $"{completionMark} {Name} ({Description}) -- Progress: {progressPercent}% ({_currentStep}/{_totalSteps})";
    }

    // Create a string representation for saving to a file
    public override string GetStringRepresentation()
    {
        return $"ProgressiveGoal:{Name},{Description},{PointValue},{_isComplete},{_totalSteps},{_currentStep},{_finalBonus}";
    }

    // Override the Initialize method to handle the additional fields
    public override void Initialize(string[] parts)
    {
        base.Initialize(parts);
        _totalSteps = int.Parse(parts[5]);
        _currentStep = int.Parse(parts[6]);
        _finalBonus = int.Parse(parts[7]);
    }
}
