using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 100);

        Console.WriteLine("Guess a number between 1 and 100");
        Console.WriteLine("What is your guess? ");
        string userGuessText = Console.ReadLine();
        int userGuess = int.Parse(userGuessText);

        while (userGuess != magicNumber)
        {
            if (userGuess > magicNumber)
            {
                Console.WriteLine("Lower");
            }

            else if (userGuess < magicNumber)
            {
                Console.WriteLine("Higher");
            }

            Console.WriteLine("What is your guess? ");
            userGuessText = Console.ReadLine();
            userGuess = int.Parse(userGuessText);
        }

        Console.WriteLine("You guessed it!");
    }
}