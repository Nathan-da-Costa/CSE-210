using System;
using System.Collections.Generic;
using System.Threading;

namespace MindfulnessProgram
{
    // Abstract Base Class to fulfill Inheritance and Abstraction requirements
    public abstract class MindfulnessActivity
    {
        // Private attributes (Encapsulation)
        private string _name;
        private string _description;
        private int _duration;

        public MindfulnessActivity(string name, string description)
        {
            _name = name;
            _description = description;
            _duration = 0;
        }

        public int GetDuration()
        {
            return _duration;
        }

        public void SetDuration(int duration)
        {
            _duration = duration;
        }

        // Common starting message for all activities
        public void DisplayStartingMessage()
        {
            Console.Clear();
            Console.WriteLine($"Welcome to the {_name} Activity.");
            Console.WriteLine();
            Console.WriteLine(_description);
            Console.WriteLine();
            Console.Write("Please enter the duration of the activity in seconds: ");
            
            if (int.TryParse(Console.ReadLine(), out int duration))
            {
                _duration = duration;
            }
            else
            {
                _duration = 10; // Default value if input is invalid
                Console.WriteLine("Invalid input. Defaulted to 10 seconds.");
            }

            Console.Clear();
            Console.WriteLine("Get ready...");
            ShowSpinner(3);
        }

        // Common ending message for all activities
        public void DisplayEndingMessage()
        {
            Console.WriteLine();
            Console.WriteLine("Well done!!");
            ShowSpinner(3);
            Console.WriteLine();
            Console.WriteLine($"You have completed the {_name} Activity for {_duration} seconds.");
            ShowSpinner(3);
        }

        // Countdown timer animation
        public void ShowCountDown(int seconds)
        {
            for (int i = seconds; i > 0; i--)
            {
                Console.Write(i);
                Thread.Sleep(1000);
                Console.Write("\b \b");
            }
        }

        // Spinner animation
        public void ShowSpinner(int seconds)
        {
            List<string> animationStrings = new List<string> { "|", "/", "-", "\\" };
            int startTime = Environment.TickCount;
            int i = 0;

            while ((Environment.TickCount - startTime) < seconds * 1000)
            {
                string s = animationStrings[i];
                Console.Write(s);
                Thread.Sleep(250);
                Console.Write("\b \b");

                i++;
                if (i >= animationStrings.Count)
                {
                    i = 0;
                }
            }
        }

        // Abstract method to be implemented in derived classes
        public abstract void Run();
    }

    // 1. Breathing Activity
    public class BreathingActivity : MindfulnessActivity
    {
        public BreathingActivity() : base(
            "Breathing", 
            "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
        {
        }

        public override void Run()
        {
            DisplayStartingMessage();

            int duration = GetDuration();
            int elapsed = 0;

            while (elapsed < duration)
            {
                Console.Write(" Breathe in... ");
                ShowCountDown(4);
                Console.WriteLine();

                elapsed += 4;
                if (elapsed >= duration) break;

                Console.Write(" Breathe out... ");
                ShowCountDown(4);
                Console.WriteLine();

                elapsed += 4;
            }

            DisplayEndingMessage();
        }
    }

    // 2. Reflecting Activity
    public class ReflectingActivity : MindfulnessActivity
    {
        private List<string> _prompts;
        private List<string> _questions;

        public ReflectingActivity() : base(
            "Reflecting", 
            "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
        {
            _prompts = new List<string>
            {
                "Think of a time when you stood up for someone else.",
                "Think of a time when you did something really difficult.",
                "Think of a time when you helped someone in need.",
                "Think of a time when you did something truly selfless."
            };

            _questions = new List<string>
            {
                "Why was this experience meaningful to you?",
                "Have you ever done anything like this before?",
                "How did you get started?",
                "How did you feel when it was complete?",
                "What made this time different than other times when you were not as successful?",
                "What is your favorite thing about this experience?",
                "What could you learn from this experience that applies to other situations?",
                "What did you learn about yourself through this experience?",
                "How can you keep this experience in mind in the future?"
            };
        }

        public override void Run()
        {
            DisplayStartingMessage();

            Random rand = new Random();
            string prompt = _prompts[rand.Next(_prompts.Count)];

            Console.WriteLine("Consider the following prompt:");
            Console.WriteLine();
            Console.WriteLine($" --- {prompt} --- ");
            Console.WriteLine();
            Console.WriteLine("When you have something in mind, press enter to continue.");
            Console.ReadLine();

            Console.WriteLine("Now ponder on each of the following questions related to this experience.");
            Console.Write("You may begin in: ");
            ShowCountDown(5);
            Console.Clear();

            int duration = GetDuration();
            int elapsed = 0;

            while (elapsed < duration)
            {
                string question = _questions[rand.Next(_questions.Count)];
                Console.Write($"> {question} ");
                ShowSpinner(5);
                Console.WriteLine();
                elapsed += 5;
            }

            DisplayEndingMessage();
        }
    }

    // 3. Listing Activity
    public class ListingActivity : MindfulnessActivity
    {
        private List<string> _prompts;

        public ListingActivity() : base(
            "Listing", 
            "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
        {
            _prompts = new List<string>
            {
                "Who are people that you appreciate?",
                "What are personal strengths of yours?",
                "Who are people that you have helped this week?",
                "When have you felt the Holy Ghost this month?",
                "Who are some of your personal heroes?"
            };
        }

        public override void Run()
        {
            DisplayStartingMessage();

            Random rand = new Random();
            string prompt = _prompts[rand.Next(_prompts.Count)];

            Console.WriteLine("List as many responses you can to the following prompt:");
            Console.WriteLine($" --- {prompt} --- ");
            Console.Write("You may begin in: ");
            ShowCountDown(5);
            Console.WriteLine();

            List<string> userItems = new List<string>();
            int duration = GetDuration();
            
            DateTime startTime = DateTime.Now;
            DateTime endTime = startTime.AddSeconds(duration);

            while (DateTime.Now < endTime)
            {
                Console.Write("> ");
                string input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                {
                    userItems.Add(input);
                }
            }

            Console.WriteLine($"You listed {userItems.Count} items!");
            DisplayEndingMessage();
        }
    }

    // Program Class (Menu System)
    public class Program
    {
        /* 
         * Exceeding Requirements Report:
         * - Added robust input validation in the main menu and duration prompts 
         *   to prevent application crashes from invalid user inputs.
         */
        static void Main(string[] args)
        {
            int choice = 0;

            while (choice != 4)
            {
                Console.Clear();
                Console.WriteLine("Menu Options:");
                Console.WriteLine("  1. Start breathing activity");
                Console.WriteLine("  2. Start reflecting activity");
                Console.WriteLine("  3. Start listing activity");
                Console.WriteLine("  4. Quit");
                Console.Write("Select a choice from the menu: ");

                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    MindfulnessActivity activity = null;

                    switch (choice)
                    {
                        case 1:
                            activity = new BreathingActivity();
                            break;
                        case 2:
                            activity = new ReflectingActivity();
                            break;
                        case 3:
                            activity = new ListingActivity();
                            break;
                        case 4:
                            Console.WriteLine("Thank you for using the Mindfulness Program. Goodbye!");
                            break;
                        default:
                            Console.WriteLine("Invalid option. Please try again.");
                            Thread.Sleep(2000);
                            break;
                    }

                    if (activity != null)
                    {
                        activity.Run();
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a valid number.");
                    Thread.Sleep(2000);
                }
            }
        }
    }
}