using System;

class Program
{
    static void Main(string[] args)
    {
        static void DisplayWelcome()
        {
            Console.WriteLine("Welcome to the Program!");
        }

        static string PromptUserName()
        {
            Console.Write("Please enter your name: ");
            string userName = Console.ReadLine();
            return userName;
        }

        static int PromptUserNumber()
        {
            Console.Write("Please enter your favourite number: ");
            string userResponse = Console.ReadLine();
            int userNumber = int.Parse(userResponse);
            return userNumber;
        }

        static int SquareNumber(int one)
        {
            int userNumberSquared = one * one;
            return userNumberSquared;
        }

        static void ReturnResult(string name, int squaredNumber)
        {
            Console.WriteLine($"{name}, the square of your number is {squaredNumber}.");
        }

        DisplayWelcome();
        string userName = PromptUserName();
        int userNumber = PromptUserNumber();
        int userNumberSquared = SquareNumber(userNumber);
        ReturnResult(userName, userNumberSquared);
    }
}