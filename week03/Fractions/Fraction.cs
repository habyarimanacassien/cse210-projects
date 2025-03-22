using System;

public class Fraction
{
    // Member variables a s private
    private int _top;
    private int _bottom;

    // Constructor with no parameters
    public Fraction()
    {
        _top = 1;
        _bottom = 1;
    }

    // Constructor with one parameter (top)
    public Fraction(int top)
    {
        _top = top;
        _bottom = 1;
    }

    // Constructor with two parameters
    public Fraction(int top, int bottom)
    {
        _top = top;
        _bottom = bottom;
    }

    // Getter for the top
    public int GetTop()
    {
        return _top;
    }

    // Setter for the top
    public void SetTop(int top)
    {
        _top = top;
    }

    // Getter for the bottom
    public int GetBottom()
    {
        return _bottom;
    }

    // Setter for the bottom
    public void SetBottom(int bottom)
    {
        _bottom = bottom;
    }

    // Method to return the fraction in string format
    public string GetFractionString()
    {
        return $"{_top}/{_bottom}";
    }

    // Method to return the decimal value of the fraction
    public double GetDecimalValue()
    {
        return (double)_top / (double)_bottom;
    }
}