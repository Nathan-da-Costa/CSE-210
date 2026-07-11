using System;

class Program
{
    static void Main(string[] args)
    {
        // Ask the user for their first name
        Console.Write("What is your first name? ");
        string firstName = Console.ReadLine();

        // Ask the user for their last name
        Console.Write("What is your last name? ");
        string lastName = Console.ReadLine();

        // Blank line for spacing as shown in the example
        Console.WriteLine();

        // Display the output using the requested format
        Console.WriteLine($"Your name is {lastName}, {firstName} {lastName}.");
    }
}