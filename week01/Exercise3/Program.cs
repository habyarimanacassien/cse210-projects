using System;

class Program
{
    static void Main(string[] args)
    {
        string needMore = "yes";
        while (needMore == "yes")
        {
            Random randGen = new Random();
            int magic = randGen.Next(1, 120);

            string keep = "yes";
            int guesses = 0;
            while (keep == "yes")
            {
                Console.Write("What is your guess? ");
                string userInput2 = Console.ReadLine();
                int guess = int.Parse(userInput2);

                if(guess > magic)
                {
                    Console.WriteLine("Lower");
                    keep = "yes";
                }
                else if (guess < magic)
                {
                    Console.WriteLine("Higher");
                    keep = "yes";
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                    keep = "no";
                }
                guesses += 1;
            }
            Console.WriteLine($"The number of total guesses was {guesses}.");

            Console.Write("Do you want to play again? ");
            needMore = Console.ReadLine();
        }
        Console.WriteLine("Good bye!!!");
    }
}