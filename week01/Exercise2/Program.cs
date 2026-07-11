using System;

class Program
{
    static void Main(string[] args)
    {
        // Prompt for grade percentage
        Console.Write("What is your grade percentage? ");
        string answer = Console.ReadLine();
        int gradePercentage = int.Parse(answer);

        string letter = "";
        string sign = "";

        // 1. Determine the letter grade
        if (gradePercentage >= 90)
        {
            letter = "A";
        }
        else if (gradePercentage >= 80)
        {
            letter = "B";
        }
        else if (gradePercentage >= 70)
        {
            letter = "C";
        }
        else if (gradePercentage >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        // 2. Stretch Challenge: Determine the sign (+ or -)
        int lastDigit = gradePercentage % 10;

        if (lastDigit >= 7)
        {
            sign = "+";
        }
        else if (lastDigit < 3)
        {
            sign = "-";
        }
        else
        {
            sign = "";
        }

        // Handle exceptional cases (No A+, F+, or F-)
        if (letter == "A" && sign == "+")
        {
            sign = "";
        }
        if (letter == "F")
        {
            sign = "";
        }

        // Display the grade result
        Console.WriteLine($"Your grade is: {letter}{sign}");

        // 3. Check if the user passed the course
        if (gradePercentage >= 70)
        {
            Console.WriteLine("Congratulations! You passed the course!");
        }
        else
        {
            Console.WriteLine("Don't give up! Keep trying for the next time.");
        }
    }
}