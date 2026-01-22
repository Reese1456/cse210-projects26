using System;

class Program
{
    static void Main(string[] args)
    {
        PromptGenerator promptGenerator = new PromptGenerator();
        Journal journal = new Journal();

        int userOption = 0;

        Console.WriteLine("Welcome to the Journal Program!");

        while (userOption != 5)
        {
            Console.WriteLine("Please select an option from below: ");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Save");
            Console.WriteLine("4. Load");
            Console.WriteLine("5. Exit");
            Console.Write("Please type a number from 1-5: ");

            string userInput = Console.ReadLine();

            if (int.TryParse(userInput, out userOption))
            {
                switch (userOption)
                {
                    case 1:
                        string prompt = promptGenerator.GetRandomPrompt();
                        Console.WriteLine($"Prompt: {prompt}");
                        Console.Write("Your response: ");
                        string response = Console.ReadLine();
                        string date = DateTime.Now.ToShortDateString();
                        Entry newEntry = new Entry(date, prompt, response);
                        journal.AddEntry(newEntry);
                        Console.WriteLine("Entry added.");
                        break;

                    case 2:
                        journal.DisplayAll();
                        break;

                    case 3:
                        Console.Write("Enter a filename to save to: ");
                        string saveFile = Console.ReadLine();
                        journal.SaveToFile(saveFile);
                        break;

                    case 4:
                        Console.Write("Enter a filename to load from: ");
                        string loadFile = Console.ReadLine();
                        journal.LoadFromFile(loadFile);
                        break;

                    case 5:
                        break;
                }
            }

            else
            {
                Console.WriteLine("Invalid input. Please enter a number from 1-5.");
                userOption = 0;
            }

            Console.WriteLine();
        }
        
        Console.WriteLine("Thank you for using the Journal Program. Goodbye!");
    }
}