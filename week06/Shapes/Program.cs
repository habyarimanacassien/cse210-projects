using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Test individual shapes
        Console.WriteLine("Testing individual shapes:");
        
        Square square = new Square("Red", 5);
        Console.WriteLine($"Square - Color: {square.GetColor()}, Area: {square.GetArea()}");
        
        Rectangle rectangle = new Rectangle("Blue", 4, 6);
        Console.WriteLine($"Rectangle - Color: {rectangle.GetColor()}, Area: {rectangle.GetArea()}");
        
        Circle circle = new Circle("Green", 3);
        Console.WriteLine($"Circle - Color: {circle.GetColor()}, Area: {circle.GetArea():F2}");
        
        // Create a list of shapes
        Console.WriteLine("\nUsing polymorphism with a list of shapes:");
        
        List<Shape> shapes = new List<Shape>();
        
        // Add different shapes to the list
        shapes.Add(square);
        shapes.Add(rectangle);
        shapes.Add(circle);
        shapes.Add(new Square("Yellow", 2.5f));
        shapes.Add(new Rectangle("Purple", 2, 8));
        shapes.Add(new Circle("Orange", 1));
        
        // Iterate through the list and display properties
        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"Shape - Color: {shape.GetColor()}, Area: {shape.GetArea():F2}");
        }
        
        Console.WriteLine("\nProgram completed. Press any key to exit.");
        Console.ReadKey();
    }
}