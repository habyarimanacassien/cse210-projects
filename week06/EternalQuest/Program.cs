using System;
using System.Collections.Generic;
using System.IO;

/*
 * Eternal Quest Program
 * 
 * This program exceeds the base requirements in the following ways:
 * 
 * 1. Added two additional goal types beyond the base requirements:
 *    - ProgressiveGoal: Tracks progress towards a large accomplishment, giving partial points along the way
 *    - NegativeGoal: Tracks bad habits with negative points to discourage them
 * 2. Gives detailed feedback when recording events, including points earned
 * 3. Improved error handling for file operations
 * 4. Added unsaved changes tracking and prompts before quitting
 */

class Program
{
    static void Main(string[] args)
    {
        GoalManager goalManager = new GoalManager();
        bool running = true;
        bool hasUnsavedChanges = false;

        DisplayWelcomeMessage();

        while (running)
        {
            DisplayMenu(goalManager, hasUnsavedChanges);
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateNewGoal(goalManager);
                    hasUnsavedChanges = true;
                    break;
                case "2":
                    ListGoals(goalManager);
                    break;
                case "3":
                    if (SaveGoals(goalManager))
                    {
                        hasUnsavedChanges = false;
                    }
                    break;
                case "4":
                    if (hasUnsavedChanges)
                    {
                        Console.Write("\nYou have unsaved changes. Load new goals anyway? (y/n): ");
                        if (!Console.ReadLine().ToLower().StartsWith("y"))
                        {
                            Console.WriteLine("Load canceled.");
                            break;
                        }
                    }
                    if (LoadGoals(goalManager))
                    {
                        hasUnsavedChanges = false;
                    }
                    break;
                case "5":
                    if (RecordEvent(goalManager))
                    {
                        hasUnsavedChanges = true;
                    }
                    break;
                case "6":
                    DisplayScore(goalManager);
                    // Do NOT set hasUnsavedChanges = true here
                    // Displaying the score doesn't create any changes that need to be saved
                    break;
                case "7":
                    if (hasUnsavedChanges)
                    {
                        Console.Write("\nYou have unsaved changes. Are you sure you want to quit? (y/n): ");
                        if (!Console.ReadLine().ToLower().StartsWith("y"))
                        {
                            Console.WriteLine("Quit canceled.");
                            break;
                        }
                    }
                    running = false;
                    Console.WriteLine("\nThank you for using the Eternal Quest Program. Goodbye!");
                    break;
                default:
                    Console.WriteLine("\nInvalid choice. Please try again.");
                    break;
            }
        }
    }

    static void DisplayWelcomeMessage()
    {
        Console.WriteLine("╔═══════════════════════════════════════╗");
        Console.WriteLine("║        ETERNAL QUEST PROGRAM          ║");
        Console.WriteLine("║      Track your goals and progress    ║");
        Console.WriteLine("╚═══════════════════════════════════════╝");
    }

    static void DisplayMenu(GoalManager goalManager, bool hasUnsavedChanges)
    {
        Console.WriteLine("\n=== Main Menu ===");
        
        // Only show unsaved changes indicator, not the current score
        if (hasUnsavedChanges)
        {
            Console.WriteLine("* You have unsaved changes *");
        }
        
        Console.WriteLine("1. Create New Goal");
        Console.WriteLine("2. List Goals");
        Console.WriteLine("3. Save Goals");
        Console.WriteLine("4. Load Goals");
        Console.WriteLine("5. Record Event");
        Console.WriteLine("6. Display Score");
        Console.WriteLine("7. Quit");
        Console.Write("\nSelect a choice from the menu: ");
    }

    static void CreateNewGoal(GoalManager goalManager)
    {
        Console.WriteLine("\n=== Create New Goal ===");
        Console.WriteLine("The types of goals are:");
        Console.WriteLine("1. Simple Goal - Complete once for points");
        Console.WriteLine("2. Eternal Goal - Can be recorded repeatedly");
        Console.WriteLine("3. Checklist Goal - Complete x times with bonus");
        Console.WriteLine("4. Progressive Goal - Track progress with partial rewards");
        Console.WriteLine("5. Negative Goal - Track habits to avoid");
        
        string goalTypeChoice = "";
        bool validChoice = false;
        
        while (!validChoice)
        {
            Console.Write("\nWhich type of goal would you like to create? (Type 1-5, or 0 to cancel): ");
            goalTypeChoice = Console.ReadLine();
            
            if (goalTypeChoice == "0")
            {
                Console.WriteLine("Goal creation canceled.");
                return;
            }
            
            if (goalTypeChoice == "1" || goalTypeChoice == "2" || goalTypeChoice == "3" || 
                goalTypeChoice == "4" || goalTypeChoice == "5")
            {
                validChoice = true;
            }
            else
            {
                Console.WriteLine("Invalid choice. Please enter a number between 1 and 5, or 0 to cancel.");
            }
        }

        // Common goal information needed for all types
        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Goal name cannot be empty. Goal creation canceled.");
            return;
        }

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(description))
        {
            Console.WriteLine("Goal description cannot be empty. Goal creation canceled.");
            return;
        }

        Console.Write("What is the amount of points associated with this goal? ");
        int points;
        if (!int.TryParse(Console.ReadLine(), out points))
        {
            Console.WriteLine("Invalid points value. Goal creation canceled.");
            return;
        }

        Goal newGoal = null;

        try
        {
            switch (goalTypeChoice)
            {
                case "1": // Simple Goal
                    newGoal = new SimpleGoal(name, description, points);
                    break;

                case "2": // Eternal Goal
                    newGoal = new EternalGoal(name, description, points);
                    break;

                case "3": // Checklist Goal
                    Console.Write("How many times does this goal need to be accomplished? ");
                    int targetCount;
                    if (!int.TryParse(Console.ReadLine(), out targetCount) || targetCount <= 0)
                    {
                        Console.WriteLine("Invalid target count. Goal creation canceled.");
                        return;
                    }

                    Console.Write("What is the bonus for accomplishing it that many times? ");
                    int bonus;
                    if (!int.TryParse(Console.ReadLine(), out bonus) || bonus < 0)
                    {
                        Console.WriteLine("Invalid bonus value. Goal creation canceled.");
                        return;
                    }

                    newGoal = new ChecklistGoal(name, description, points, targetCount, bonus);
                    break;

                case "4": // Progressive Goal
                    Console.Write("How many steps does this goal have in total? ");
                    int totalSteps;
                    if (!int.TryParse(Console.ReadLine(), out totalSteps) || totalSteps <= 0)
                    {
                        Console.WriteLine("Invalid steps count. Goal creation canceled.");
                        return;
                    }

                    Console.Write("What is the bonus for completing all steps? ");
                    int finalBonus;
                    if (!int.TryParse(Console.ReadLine(), out finalBonus) || finalBonus < 0)
                    {
                        Console.WriteLine("Invalid bonus value. Goal creation canceled.");
                        return;
                    }

                    newGoal = new ProgressiveGoal(name, description, points, totalSteps, finalBonus);
                    break;

                case "5": // Negative Goal
                    Console.WriteLine("Note: This goal's points should be negative to deduct from score.");
                    if (points > 0)
                    {
                        points = -points; // Make sure points are negative
                        Console.WriteLine($"Points value updated to {points} (negative).");
                    }

                    newGoal = new NegativeGoal(name, description, points);
                    break;

                default:
                    Console.WriteLine("Invalid goal type.");
                    return;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error creating goal: {ex.Message}");
            return;
        }

        if (newGoal != null)
        {
            goalManager.AddGoal(newGoal);
            Console.WriteLine($"\nNew {newGoal.GetType().Name} created successfully!");
        }
    }

    static void ListGoals(GoalManager goalManager)
    {
        goalManager.DisplayGoals();
    }

    static bool SaveGoals(GoalManager goalManager)
    {
        if (goalManager.Goals.Count == 0)
        {
            Console.WriteLine("\nYou have no goals to save.");
            return false;
        }

        // First, display all available goal files in the directory
        string currentDir = AppDomain.CurrentDomain.BaseDirectory;
        string projectDir = GetMainProjectDirectory(currentDir);
        DisplayAvailableGoalFiles(projectDir);

        // Check if there's a previously saved file and offer it as default
        string defaultFilename = string.IsNullOrEmpty(goalManager.LastSavedFilename) ?
            "" : Path.GetFileName(goalManager.LastSavedFilename);

        if (!string.IsNullOrEmpty(defaultFilename))
        {
            Console.Write($"\nWhat is the filename for the goal file (.txt format)? (Press Enter for '{defaultFilename}'): ");
        }
        else
        {
            Console.Write("\nWhat is the filename for the goal file (.txt format)? ");
        }

        string filename = Console.ReadLine();

        // Use the default filename if the user just pressed Enter
        if (string.IsNullOrWhiteSpace(filename) && !string.IsNullOrEmpty(defaultFilename))
        {
            filename = defaultFilename;
        }
        else if (string.IsNullOrWhiteSpace(filename))
        {
            Console.WriteLine("Invalid filename. Save canceled.");
            return false;
        }

        // Make sure the filename has the .txt extension
        if (!filename.EndsWith(".txt", StringComparison.OrdinalIgnoreCase))
        {
            filename += ".txt";
        }

        // Use the main project directory
        string fullPath = Path.Combine(projectDir, filename);

        // Show the full path where file will be saved
        Console.WriteLine($"File will be saved to: {fullPath}");

        // Check if file exists and provide options
        if (File.Exists(fullPath))
        {
            Console.WriteLine("\nFile already exists. Choose an option:");
            Console.WriteLine("1. Replace the file (overwrites all existing data)");
            Console.WriteLine("2. Append to the file (keeps existing goals and adds new ones)");
            Console.WriteLine("3. Cancel the save operation");
            Console.Write("Your choice: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    // Replace - just continue with normal save
                    Console.WriteLine("Replacing existing file...");
                    return goalManager.SaveToFile(fullPath, false);

                case "2":
                    // Append mode - combine existing goals with new ones
                    Console.WriteLine("Appending to existing file...");
                    return goalManager.SaveToFile(fullPath, true);

                default:
                    Console.WriteLine("Save canceled.");
                    return false;
            }
        }

        // No existing file, just save normally
        return goalManager.SaveToFile(fullPath, false);
    }

static bool LoadGoals(GoalManager goalManager)
{
    // First, display all available goal files in the directory
    string currentDir = AppDomain.CurrentDomain.BaseDirectory;
    string projectDir = GetMainProjectDirectory(currentDir);
    bool filesExist = DisplayAvailableGoalFiles(projectDir);

    // If no files were found, just return to display the main menu
    if (!filesExist)
    {
        Console.WriteLine("\nNo existing goal files found.");
        return false;
    }

    Console.Write("What is the filename for the goal file (or press Enter to cancel)? ");
    string input = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(input))
    {
        Console.WriteLine("Load canceled.");
        return false;
    }

    string filename = input;

    // If the user didn't provide an extension, assume .txt
    if (!filename.Contains('.'))
    {
        filename += ".txt";
    }

    // Try in the main project directory first
    string fullPath = Path.Combine(projectDir, filename);

    // Show the full path to help the user understand where the program is looking
    // Console.WriteLine($"Looking for file at: {fullPath}");

    if (!File.Exists(fullPath))
    {
        Console.WriteLine($"File '{filename}' not found!");

        // Try in the execution directory as a fallback
        string execPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filename);
        if (File.Exists(execPath))
        {
            Console.WriteLine($"Found file at: {execPath}");
            fullPath = execPath;
        }
        else
        {
            // Show a list of available files again
            Console.WriteLine("\nAvailable goal files:");
            string[] txtFiles = Directory.GetFiles(projectDir, "*.txt");
            foreach (string file in txtFiles)
            {
                Console.WriteLine($"- {Path.GetFileName(file)}");
            }

            // Ask the user for just the filename again, not the full path
            Console.Write("\nEnter the filename to load (or press Enter to cancel): ");
            string alternativeFilename = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(alternativeFilename))
            {
                Console.WriteLine("Load canceled.");
                return false;
            }

            // If the user didn't provide an extension, assume .txt
            if (!alternativeFilename.Contains('.'))
            {
                alternativeFilename += ".txt";
            }

            // Try both in the project directory and in the current directory
            fullPath = Path.Combine(projectDir, alternativeFilename);
            
            if (!File.Exists(fullPath))
            {
                // Check if this might be a full path already
                if (File.Exists(alternativeFilename))
                {
                    fullPath = alternativeFilename;
                }
                else
                {
                    Console.WriteLine($"File n{filename} ot found!");
                    Console.WriteLine("Load canceled.");
                    return false;
                }
            }
        }
    }

    // Show the file content preview before loading
    Console.WriteLine("\nFile content preview:");
    ShowFilePreview(fullPath);

    Console.Write("\nLoad this file (Type (y/n) or press Enter to cancel)? ");
    if (!Console.ReadLine().ToLower().StartsWith("y"))
    {
        Console.WriteLine("Load canceled.");
        return false;
    }

    bool result = goalManager.LoadFromFile(fullPath);

    // If load was successful, show loaded goals
    if (result && goalManager.Goals.Count > 0)
    {
        Console.WriteLine("\nLoaded goals:");
        goalManager.DisplayGoals();
    }

    return result;
}

static bool RecordEvent(GoalManager goalManager)
{
    if (goalManager.Goals.Count == 0)
    {
        Console.WriteLine("\nYou have no goals to record events for.");
        return false;
    }

    goalManager.DisplayGoals();

    Console.Write("\nWhich goal did you accomplish? Enter the number (or 0 to cancel): ");
    int goalNumber;

    if (!int.TryParse(Console.ReadLine(), out goalNumber))
    {
        Console.WriteLine("\nInvalid input. Please enter a number.");
        return false;
    }

    if (goalNumber == 0)
    {
        Console.WriteLine("Recording canceled.");
        return false;
    }

    // Adjust for 0-based indexing
    int goalIndex = goalNumber - 1;

    if (goalIndex < 0 || goalIndex >= goalManager.Goals.Count)
    {
        Console.WriteLine("\nInvalid goal number.");
        return false;
    }

    // Check if the goal is already complete (for non-eternal goals)
    Goal selectedGoal = goalManager.Goals[goalIndex];
    if (selectedGoal.IsComplete && !(selectedGoal is EternalGoal))
    {
        if (selectedGoal is ChecklistGoal)
        {
            Console.WriteLine("\nThis checklist goal has already been completed the required number of times.");
            return false;
        }
        else
        {
            Console.WriteLine("\nThis goal has already been completed.");
            return false;
        }
    }

    int pointsEarned = goalManager.RecordEvent(goalIndex);

    if (pointsEarned > 0)
    {
        Console.WriteLine($"\n** CONGRATULATIONS! **");
        Console.WriteLine($"*-*-*-*-*-*-*-*-*-*-*");
        Console.WriteLine($"You earned {pointsEarned} points!");
    }
    else if (pointsEarned < 0)
    {
        Console.WriteLine($"\n:: OH NO! ::");
        Console.WriteLine($"------------");
        Console.WriteLine($"You lost {Math.Abs(pointsEarned)} points.");
    }
    else
    {
        Console.WriteLine("\nNo points earned for this event.");
    }

    Console.WriteLine($"Your current score is {goalManager.Score}");
    return true;
}

    static void DisplayScore(GoalManager goalManager)
    {
        goalManager.DisplayScore();
    }

    // Helper method to get the main project directory
    static string GetMainProjectDirectory(string currentPath)
    {
        try
        {
            // Start with the current directory (usually bin/Debug/netX.X)
            DirectoryInfo directory = new DirectoryInfo(currentPath);

            // Navigate up to find the main project directory
            // Typically we need to go up 3 levels from bin/Debug/netX.X
            // bin/Debug/netX.X -> bin/Debug -> bin -> [Project Directory]
            int levelsUp = 0;
            while (levelsUp < 3 && directory != null && directory.Parent != null)
            {
                directory = directory.Parent;
                levelsUp++;

                // Try to find the .csproj file at this level
                if (directory.GetFiles("*.csproj").Length > 0)
                {
                    return directory.FullName;
                }
            }

            // If we've gone up 3 levels and still don't find a .csproj file,
            // return the directory at level 3 (which is typically the main project folder)
            if (levelsUp == 3 && directory != null)
            {
                return directory.FullName;
            }

            // If all else fails, return a folder in the user's documents
            string docsPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                "EternalQuest"
            );

            // Create the directory if it doesn't exist
            if (!Directory.Exists(docsPath))
            {
                Directory.CreateDirectory(docsPath);
            }

            return docsPath;
        }
        catch
        {
            // Fallback to just using the current directory if any error occurs
            return currentPath;
        }
    }

    // Helper method to display all available goal files
    static bool DisplayAvailableGoalFiles(string directory)
    {
        try
        {
            if (!Directory.Exists(directory))
            {
                Console.WriteLine("Directory not found.");
                return false;
            }

            string[] txtFiles = Directory.GetFiles(directory, "*.txt");

            if (txtFiles.Length == 0)
            {
                return false;
            }

            Console.WriteLine("\nAvailable goal files:");
            foreach (string file in txtFiles)
            {
                string fileName = Path.GetFileName(file);
                Console.WriteLine($"- {fileName}");

                try
                {
                    string[] lines = File.ReadAllLines(file);
                    if (lines.Length > 0)
                    {
                        // Try to extract score from first line
                        string[] scoreParts = lines[0].Split(',');
                        if (scoreParts.Length >= 1)
                        {
                            int score = int.Parse(scoreParts[0]);
                            int goalCount = lines.Length - 1;

                            Console.WriteLine($"  Score: {score}, Goals: {goalCount}");
                        }
                    }
                }
                catch
                {
                    // If can't parse, just show it's a file without details
                    Console.WriteLine("  (Cannot read file details)");
                }
            }

            Console.WriteLine();
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error accessing files: {ex.Message}");
            return false;
        }
    }

    // Helper method to show a preview of a file's contents
    static void ShowFilePreview(string filename)
    {
        try
        {
            if (!File.Exists(filename))
            {
                Console.WriteLine("File not found.");
                return;
            }

            string[] lines = File.ReadAllLines(filename);

            if (lines.Length == 0)
            {
                Console.WriteLine("File is empty.");
                return;
            }

            // Show first 10 lines max
            int lineCount = Math.Min(lines.Length, 10);
            for (int i = 0; i < lineCount; i++)
            {
                if (i == 0)
                {
                    // For the first line, try to parse and show more readable format
                    try
                    {
                        string[] parts = lines[i].Split(',');
                        if (parts.Length >= 1)
                        {
                            Console.WriteLine($"Score: {parts[0]}");
                            continue;
                        }
                    }
                    catch { }
                }

                // Format goal lines to be more readable
                if (i > 0)
                {
                    try
                    {
                        string[] typeParts = lines[i].Split(':');
                        if (typeParts.Length == 2)
                        {
                            string goalType = typeParts[0];
                            string[] detailParts = typeParts[1].Split(',');

                            if (detailParts.Length >= 3)
                            {
                                string name = detailParts[0];
                                string desc = detailParts[1];
                                string complete = detailParts.Length >= 4 && detailParts[3].ToLower() == "true" ? "Completed" : "Not Completed";

                                Console.WriteLine($"{i}. {goalType}: {name} - {desc} ({complete})");
                                continue;
                            }
                        }
                    }
                    catch { }
                }

                // Fallback to just showing the raw line
                Console.WriteLine($"{i + 1}. {lines[i]}");
            }

            if (lines.Length > 10)
            {
                Console.WriteLine($"... and {lines.Length - 10} more lines");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading file: {ex.Message}");
        }
    }

    // Helper method to show the user the expected file format
    static void ShowGoalFileFormat()
    {
        Console.WriteLine("\n=== Goal File Format Guide ===");
        Console.WriteLine("First line: Score");
        Console.WriteLine("Example: 1500");
        Console.WriteLine("\nRemaining lines: One goal per line in the format:");
        Console.WriteLine("GoalType:Name,Description,PointValue,IsComplete,Additional Fields...");
        Console.WriteLine("\nExamples:");
        Console.WriteLine("SimpleGoal:Read a Book,Read a book for 30 minutes,100,False");
        Console.WriteLine("EternalGoal:Exercise,Exercise for 30 minutes,50,False");
        Console.WriteLine("ChecklistGoal:Study Scripture,Study scripture for 10 minutes,50,False,7,3,500");
        Console.WriteLine("ProgressiveGoal:Learn Piano,Practice piano,75,False,10,5,1000");
        Console.WriteLine("NegativeGoal:Skip Exercise,Skipped daily exercise,-50,False,2");
        Console.WriteLine("\nFor ChecklistGoal, additional fields are: TargetCount,CurrentCount,BonusPoints");
        Console.WriteLine("For ProgressiveGoal, additional fields are: TotalSteps,CurrentStep,FinalBonus");
        Console.WriteLine("For NegativeGoal, additional field is: OccurrenceCount");
    }
}