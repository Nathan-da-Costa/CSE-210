/*
CREATIVITY / EXCEEDING REQUIREMENTS:
I enhanced this journal program by adding custom user tracking. I included a 
system feature that prompts the user to rate their current overall energy or 
focus level on a scale from 1-10 before generating their prompt. This metric 
is dynamically saved alongside the standard date, prompt, and entry fields 
to add contextual depth to their writing history.
*/

using System;

class Program
{
    static void Main(string[] args)
    {
        Journal executionJournal = new Journal();
        PromptGenerator promptSource = new PromptGenerator();
        
        // Seeding standard student prompts
        promptSource._prompts.Add("Who was the most interesting person I interacted with today?");
        promptSource._prompts.Add("What was the best part of my day?");
        promptSource._prompts.Add("How did I see the hand of the Lord in my life today?");
        promptSource._prompts.Add("What was the strongest emotion I felt today?");
        promptSource._prompts.Add("If I had one thing I could do over today, what would it be?");

        bool keepRunning = true;
        Console.WriteLine("Welcome to the Journal Program!");

        while (keepRunning)
        {
            Console.WriteLine("\nPlease select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");
            
            string selection = Console.ReadLine();

            switch (selection)
            {
                case "1":
                    // Creativity Element: Tracking extra data contextually
                    Console.Write("On a scale of 1-10, what is your energy level right now? ");
                    string energyLevel = Console.ReadLine();

                    string activePrompt = promptSource.GetRandomPrompt();
                    Console.WriteLine($"\nYour prompt: {activePrompt}");
                    Console.Write("> ");
                    string userResponse = Console.ReadLine();
                    
                    string cleanDate = DateTime.Now.ToString("MM/dd/yyyy");

                    Entry currentEntry = new Entry();
                    currentEntry._date = cleanDate;
                    // Append metadata directly onto the text line beautifully
                    currentEntry._promptText = $"{activePrompt} [Energy Level: {energyLevel}/10]";
                    currentEntry._entryText = userResponse;

                    executionJournal.AddEntry(currentEntry);
                    break;

                case "2":
                    executionJournal.DisplayAll();
                    break;

                case "3":
                    Console.Write("What is the filename? ");
                    string loadPath = Console.ReadLine();
                    executionJournal.LoadFromFile(loadPath);
                    break;

                case "4":
                    Console.Write("What is the filename? ");
                    string savePath = Console.ReadLine();
                    executionJournal.SaveToFile(savePath);
                    break;

                case "5":
                    keepRunning = false;
                    break;

                default:
                    Console.WriteLine("Invalid entry. Choose a number between 1 and 5.");
                    break;
            }
        }
    }
}