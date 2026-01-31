using System;

class Program
{
    static void Main(string[] args)
    {
        Reference reference = new Reference("John", 3, 16);
        Scripture scripture = new Scripture(reference, "For God so loved the world, He gave His only begotten Son, that whoever believes in Him should not perish but have everlasting life.");

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress Enter or type quit:");

            string input = Console.ReadLine();
            if (input.ToLower() == "quit")
                break;
                
            scripture.HideRandomWords(3);

            if (scripture.AllHidden())
                break;
        }

        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());
        Console.WriteLine("\nPress Enter or type quit:");
    }
}