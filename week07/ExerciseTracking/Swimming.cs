using System;

public class Swimming : Activity
{
    // Private member variables
    private int _laps;

    // Constructor
    public Swimming(DateTime date, int minutes, int laps) : base(date, minutes)
    {
        _laps = laps;
    }

    // Implement abstract methods
    public override double GetDistance()
    {
        // Distance in miles = swimming laps * 50 / 1000 * 0.62
        return _laps * 50 / 1000.0 * 0.62;
    }

    public override double GetSpeed()
    {
        return (GetDistance() / _minutes) * 60;
    }

    public override double GetPace()
    {
        return _minutes / GetDistance();
    }
}
