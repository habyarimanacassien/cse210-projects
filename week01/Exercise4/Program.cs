using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create a new list to store the numbers
        List<int> numbers = new List<int>();
        
        Console.WriteLine("Enter a list of numbers (positive/negative), type 0 when finished.");
        
        while (true)
        {
            Console.Write("Enter number: ");
            string userInput = Console.ReadLine();
    
            int number = int.Parse(userInput);
            
            if (number == 0)
            {
                // Exit the loop for 0
                break;
            }
            
            // Add the number to our list
            numbers.Add(number);
        }
        Console.WriteLine(numbers);
        // Ensure we have items in numbers list
        if (numbers.Count > 0)
        {
            // Compute sum
            int sum = 0;
            int max = numbers[0];
            foreach (int number in numbers)
            {
                sum += number;
                if (number > max)
                {
                    max = number;
                }
            }
            
            // Compute the average
            double average = sum / numbers.Count;
            
            // Results
            Console.WriteLine($"The sum is: {sum}");
            Console.WriteLine($"The average is: {average}");
            Console.WriteLine($"The largest number is: {max}");
            
            // Stretch 1: Find the smallest +ve number
            int smallestPositive = 999999999;
            bool foundPositive = false;
            
            foreach (int number in numbers)
            {
                if (number > 0 && number < smallestPositive)
                {
                    smallestPositive = number;
                    foundPositive = true;
                }
            }
            
            if (foundPositive)
            {
                Console.WriteLine($"The smallest positive number is: {smallestPositive}");
            }
            else
            {
                Console.WriteLine("No positive numbers were found.");
            }
            
            // Stretch 2: Sort the list
            List<int> sortedNumbers = new List<int>(numbers);
            sortedNumbers.Sort(); // Sort the copy
            
            Console.WriteLine("The sorted list is:");
            foreach (int number in sortedNumbers)
            {
                Console.WriteLine($"{number}");
            }
            Console.WriteLine(); // Add a new line
        }
        else
        {
            Console.WriteLine("No numbers were entered.");
        }
        
    }
}