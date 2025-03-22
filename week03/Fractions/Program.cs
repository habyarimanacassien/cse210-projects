using System;

class Program
{
    static void Main(string[] args)
    {
        // Test the first constructor
        Fraction fraction1 = new Fraction();
        Console.WriteLine(fraction1.GetFractionString());
        Console.WriteLine(fraction1.GetDecimalValue());

        // Test the second constructor
        Fraction fraction2 = new Fraction(6);
        Console.WriteLine(fraction2.GetFractionString());
        Console.WriteLine(fraction2.GetDecimalValue());

        // Test the third constructor
        Fraction fraction3 = new Fraction(6, 7);
        Console.WriteLine(fraction3.GetFractionString());
        Console.WriteLine(fraction3.GetDecimalValue());

        // Use Setters and Getters for first constructor
        fraction1.SetTop(1);
        fraction1.SetBottom(1);
        Console.WriteLine(fraction1.GetFractionString());
        Console.WriteLine(fraction1.GetDecimalValue());

        // Use Setters and Getters for second constructor
        fraction2.SetTop(5);
        fraction2.SetBottom(1);
        Console.WriteLine(fraction2.GetFractionString());
        Console.WriteLine(fraction2.GetDecimalValue());

        // Use Setters and Getters for third constructor
        fraction3.SetTop(3);
        fraction3.SetBottom(4);
        Console.WriteLine(fraction3.GetFractionString());
        Console.WriteLine(fraction3.GetDecimalValue());

        // Use Setters and Getters for third constructor
        fraction3.SetTop(1);
        fraction3.SetBottom(3);
        Console.WriteLine(fraction3.GetFractionString());
        Console.WriteLine(fraction3.GetDecimalValue());
    }
}