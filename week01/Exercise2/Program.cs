using System;
using System.Reflection.Metadata;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter your grade percentage (eg. type 71 if it is 71%): ");
        string userGrade = Console.ReadLine();
        int grade = int.Parse(userGrade);

        string letter;
        if (grade >= 90)
        {
            letter = "A";
        }
        else if (grade >= 80)
        {
            letter = "B";
        }
        else if (grade >= 70)
        {
            letter = "C";
        }
        else if (grade >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        string sign;
        int mod = grade % 10;
        Console.WriteLine($"Your sign is {mod}");
        if (mod >= 7 && letter != "A" && letter != "F")
        {
            sign = "+";
        }
        else if (mod < 3 && letter != "F")
        {
            sign = "-";
        }
        else
        {
            sign = "";
        }

        Console.WriteLine($"Your letter grade is: {letter}{sign}");


        if (grade >= 70)
        {
            Console.WriteLine("Congratulations, you passed the course.");
        }
        else
        {
            Console.WriteLine("Sorry, you failed the course! Don't give up, you will do it next time.");
        }
    }
}