using System;

// Base class for all types of goals (Abstraction and Encapsulation)
public abstract class Goal
{
    // Private fields for encapsulation
    private string _name;
    private string _description;
    private int _pointValue;
    protected bool _isComplete;

    // Properties with getters and setters for encapsulation
    public string Name { get { return _name; } set { _name = value; } }
    public string Description { get { return _description; } set { _description = value; } }
    public int PointValue { get { return _pointValue; } set { _pointValue = value; } }
    public bool IsComplete { get { return _isComplete; } }

    // Constructor
    public Goal(string name, string description, int pointValue)
    {
        _name = name;
        _description = description;
        _pointValue = pointValue;
        _isComplete = false;
    }

    // Abstract methods for polymorphic behavior
    public abstract int RecordEvent();
    public abstract string GetDisplayString();
    public abstract string GetStringRepresentation();

    // Virtual method that derived classes can override if needed
    public virtual void Initialize(string[] parts)
    {
        _name = parts[1];
        _description = parts[2];
        _pointValue = int.Parse(parts[3]);
        _isComplete = bool.Parse(parts[4]);
    }
}
