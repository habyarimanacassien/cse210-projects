using System;

class Program
{
    static void Main(string[] args)
    {
        // Test the base Assignment class
        Assignment assignment = new Assignment("Samuel Bennett", "Multiplication");
        Console.WriteLine(assignment.GetSummary());
        // Test accessing properties
        Console.WriteLine($"Student: {assignment.StudentName}, Topic: {assignment.Topic}");
        Console.WriteLine();

        // Test the MathAssignment class
        MathAssignment mathAssignment = new MathAssignment("Roberto Rodriguez", "Fractions", "7.3", "8-19");
        Console.WriteLine(mathAssignment.GetSummary());
        Console.WriteLine(mathAssignment.GetHomeworkList());
        // Test accessing properties
        Console.WriteLine($"Section: {mathAssignment.TextbookSection}, Problems: {mathAssignment.Problems}");
        Console.WriteLine();

        // Test the WritingAssignment class
        WritingAssignment writingAssignment = new WritingAssignment("Mary Waters", "European History", "The Causes of World War II");
        Console.WriteLine(writingAssignment.GetSummary());
        Console.WriteLine(writingAssignment.GetWritingInformation());
        // Test accessing properties
        Console.WriteLine($"Title: {writingAssignment.Title}");
    }
}