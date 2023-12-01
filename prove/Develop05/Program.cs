using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        GoalManager goalManager = new GoalManager();

        int choice;
        do
        {
            goalManager.DisplayPoints(); // Display points before showing the menu

            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Create new goal");
            Console.WriteLine("2. List goals");
            Console.WriteLine("3. Save goals");
            Console.WriteLine("4. Load goals");
            Console.WriteLine("5. Record event");
            Console.WriteLine("6. Quit");
            Console.Write("Enter your choice: ");

            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        CreateNewGoal(goalManager);
                        break;
                    case 2:
                        goalManager.DisplayProgress();
                        break;
                    case 3:
                        Console.Write("Enter the file name to save goals: ");
                        string saveFileName = Console.ReadLine();
                        goalManager.SaveGoals(saveFileName);
                        break;
                    case 4:
                        Console.Write("Enter the file name to load goals: ");
                        string loadFileName = Console.ReadLine();
                        goalManager.LoadGoals(loadFileName);
                        break;
                    case 5:
                        RecordEvent(goalManager);
                        break;
                    case 6:
                        Console.WriteLine("Exiting the program.");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 6.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }

        } while (choice != 6);
    }

    static void CreateNewGoal(GoalManager goalManager)
    {
        Console.WriteLine("Choose the type of goal:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Enter your choice: ");

        if (int.TryParse(Console.ReadLine(), out int goalTypeChoice))
        {
            Console.Write("Enter the goal name: ");
            string goalName = Console.ReadLine();

            Console.Write("Enter the goal points: ");
            if (int.TryParse(Console.ReadLine(), out int goalValue))
            {
                switch (goalTypeChoice)
                {
                    case 1:
                        goalManager.AddGoal(new SimpleGoal(goalName, goalValue));
                        break;
                    case 2:
                        goalManager.AddGoal(new EternalGoal(goalName, goalValue));
                        break;
                    case 3:
                        Console.Write("How many times this goal need to be complete? ");
                        if (int.TryParse(Console.ReadLine(), out int targetCount))
                        {
                            goalManager.AddGoal(new ChecklistGoal(goalName, goalValue, targetCount));
                        }
                        else
                        {
                            Console.WriteLine("Invalid input for target count. Checklist goal not added.");
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid goal type choice. Goal not added.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input for goal value. Goal not added.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input for goal type choice. Goal not added.");
        }
    }

    static void RecordEvent(GoalManager goalManager)
    {
        goalManager.DisplayGoals(); // Display the list of goals

        Console.Write("Enter the index of the goal to record an event: ");
        if (int.TryParse(Console.ReadLine(), out int eventIndex))
        {
            goalManager.RecordEvent(eventIndex - 1);
        }
        else
        {
            Console.WriteLine("Invalid input for event index.");
        }
    }
}
