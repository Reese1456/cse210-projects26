using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        string studentGradeText = Console.ReadLine();
        int studentGrade = int.Parse(studentGradeText);
        string letter = "";
        string plusOrMinus = "";
        int lastChar = (studentGrade % 10);  

        if (studentGrade >= 90)
        {
            letter = "A";
        }

        else if (studentGrade >= 80)
        {
            letter = "B";
        }

        else if (studentGrade >= 70)
        {
            letter = "C";
        }

        else if (studentGrade >= 60)
        {
            letter = "D";
        }

        else
        {
            letter = "F";
        }

        if (lastChar >= 7)
        {
            plusOrMinus = "+";
        }

        else if (lastChar <= 3)
        {
            plusOrMinus = "-";
        }

        if (studentGrade >= 97)
        {
            plusOrMinus = "";
        }

        else if (studentGrade <= 59)
        {
            plusOrMinus = "";
        }

        Console.WriteLine($"Your letter grade is {letter}{plusOrMinus}.");

        if (studentGrade >= 70)
        {
            Console.WriteLine("You have passed the class!");
        }

        else
        {
            Console.WriteLine("You have failed the class. :(");
        }
    }
}