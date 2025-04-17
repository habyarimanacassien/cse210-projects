using System;
using System.Collections.Generic;
using System.IO;

// Class to manage all goals and the user's progress
public class GoalManager
{
    // Private fields for encapsulation
    private List<Goal> _goals;
    private int _score;
    private string _lastSavedFilename;

    // Properties with getters and setters
    public List<Goal> Goals { get { return _goals; } }
    public int Score { get { return _score; } }
    public string LastSavedFilename { get { return _lastSavedFilename; } }

    // Constructor
    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
        _lastSavedFilename = "";
    }

    // Add a new goal to the list
    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
    }

    // Record an event (accomplish a goal) and update the score
    public int RecordEvent(int goalIndex)
    {
        if (goalIndex >= 0 && goalIndex < _goals.Count)
        {
            // Check if the goal is already complete (for SimpleGoal and ChecklistGoal)
            Goal goal = _goals[goalIndex];
            if (goal.IsComplete && !(goal is EternalGoal))
            {
                // Goal is already complete
                return 0;
            }
            
            int pointsEarned = _goals[goalIndex].RecordEvent();
            _score += pointsEarned;
            
            return pointsEarned;
        }
        
        return 0;
    }

    // Display all goals with their status
    public void DisplayGoals()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("\nYou have no goals yet. Try adding some!");
            return;
        }
        
        Console.WriteLine("\n=== Your Goals ===");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDisplayString()}");
        }
    }

    // Display the user's score
    public void DisplayScore()
    {
        Console.WriteLine($"\n=== Your Eternal Quest Status ===");
        Console.WriteLine($"Score: {_score} points");
    }

    // Save goals and score to a file
    public bool SaveToFile(string filename, bool append = false)
    {
        try
        {
            // Create the directory if it doesn't exist
            string directory = Path.GetDirectoryName(filename);
            if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            
            // First write to a temporary file to avoid corrupting the original on error
            string tempFilename = $"{filename}.tmp";
            
            // If append mode is true and the file exists, load existing goals first
            List<Goal> combinedGoals = new List<Goal>(_goals);
            int originalScore = _score;
            
            if (append && File.Exists(filename))
            {
                try
                {
                    // Create a temporary GoalManager to load the existing file
                    GoalManager tempManager = new GoalManager();
                    if (tempManager.LoadFromFile(filename))
                    {
                        // Combine the existing goals with the new ones
                        foreach (Goal existingGoal in tempManager.Goals)
                        {
                            bool isDuplicate = false;
                            
                            // Check if this goal already exists in our current goals
                            foreach (Goal currentGoal in _goals)
                            {
                                if (existingGoal.Name == currentGoal.Name && 
                                    existingGoal.Description == currentGoal.Description)
                                {
                                    isDuplicate = true;
                                    break;
                                }
                            }
                            
                            if (!isDuplicate)
                            {
                                combinedGoals.Add(existingGoal);
                            }
                        }
                        
                        // Keep the higher score
                        if (tempManager.Score > _score)
                        {
                            originalScore = _score; // Save for reporting
                            _score = tempManager.Score;
                        }
                        
                        Console.WriteLine($"Combined {_goals.Count} new goals with {tempManager.Goals.Count} existing goals.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Warning: Could not merge with existing file: {ex.Message}");
                    Console.WriteLine("Continuing with save of new goals only.");
                }
            }
            
            using (StreamWriter outputFile = new StreamWriter(tempFilename))
            {
                // First line is the score
                outputFile.WriteLine($"{_score}");
                
                // Then write each goal
                foreach (Goal goal in combinedGoals)
                {
                    outputFile.WriteLine(goal.GetStringRepresentation());
                }
            }
            
            // If we got here without error, move the temp file to the real file
            if (File.Exists(filename))
            {
                File.Delete(filename);
            }
            File.Move(tempFilename, filename);
            
            _lastSavedFilename = filename;
            
            if (append && originalScore != _score)
            {
                Console.WriteLine($"\nGoals and progress saved to {filename}");
                Console.WriteLine($"Score was updated from {originalScore} to {_score}");
            }
            else
            {
                Console.WriteLine($"\nGoals and progress saved to {filename}");
            }
            
            Console.WriteLine($"File location: {Path.GetFullPath(filename)}");
            
            // Show the file contents
            Console.WriteLine("\nFile contents preview:");
            ShowFileContents(filename);
            
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nError saving to file: {ex.Message}");
            return false;
        }
    }

    // Load goals and score from a file
    public bool LoadFromFile(string filename)
    {
        try
        {
            if (!File.Exists(filename))
            {
                Console.WriteLine($"\nFile {filename} not found.");
                return false;
            }
            
            // Create a temporary backup list of goals in case loading fails
            List<Goal> tempGoals = new List<Goal>(_goals);
            int tempScore = _score;
            
            try
            {
                // Clear existing goals
                _goals.Clear();
                
                string[] lines = File.ReadAllLines(filename);
                
                if (lines.Length > 0)
                {
                    // First line contains score
                    string[] scoreParts = lines[0].Split(',');
                    _score = int.Parse(scoreParts[0]);
                    
                    bool hasErrors = false;
                    List<string> errorMessages = new List<string>();
                    
                    // Process the remaining lines (goals)
                    for (int i = 1; i < lines.Length; i++)
                    {
                        try {
                            string[] parts = lines[i].Split(':');
                            if (parts.Length != 2)
                            {
                                errorMessages.Add($"Line {i+1} has incorrect format. Each goal should be formatted as Type:Details.");
                                hasErrors = true;
                                continue;
                            }
                            
                            string goalType = parts[0];
                            string[] goalParts = parts[1].Split(',');
                            
                            Goal goal = CreateGoalFromType(goalType, goalParts);
                            if (goal != null)
                            {
                                _goals.Add(goal);
                            }
                            else
                            {
                                errorMessages.Add($"Couldn't create goal at line {i+1}.");
                                hasErrors = true;
                            }
                        }
                        catch (Exception ex)
                        {
                            errorMessages.Add($"Error with goal at line {i+1}: {ex.Message}");
                            hasErrors = true;
                        }
                    }
                    
                    _lastSavedFilename = filename;
                    
                    if (hasErrors)
                    {
                        Console.WriteLine("\nWarning: Some goals could not be loaded correctly.");
                        foreach (string error in errorMessages)
                        {
                            Console.WriteLine($"- {error}");
                        }
                        
                        if (_goals.Count == 0)
                        {
                            Console.WriteLine("No goals were successfully loaded.");
                            return false;
                        }
                        else
                        {
                            Console.WriteLine($"Successfully loaded {_goals.Count} goal(s).");
                        }
                    }
                    
                    Console.WriteLine($"\nGoals and progress loaded from {filename}");
                    Console.WriteLine($"File location: {Path.GetFullPath(filename)}");
                    return true;
                }
                else
                {
                    throw new FormatException("File is empty.");
                }
            }
            catch (Exception ex)
            {
                // Restore the previous goals and score if loading fails
                _goals = tempGoals;
                _score = tempScore;
                
                throw new Exception($"Error parsing file: {ex.Message}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nError loading from file: {ex.Message}");
            return false;
        }
    }

    // Factory method to create the right type of goal from a string
    private Goal CreateGoalFromType(string goalType, string[] parts)
    {
        try
        {
            Goal goal = null;
            
            switch (goalType)
            {
                case "SimpleGoal":
                    if (parts.Length < 4)
                        throw new FormatException("SimpleGoal format is incorrect.");
                    
                    int simplePointValue = 0;
                    if (parts.Length > 2) 
                        int.TryParse(parts[2], out simplePointValue);
                    
                    goal = new SimpleGoal(
                        parts.Length > 0 ? parts[0] : "", 
                        parts.Length > 1 ? parts[1] : "", 
                        simplePointValue);
                    
                    // Only set isComplete if there are enough parts
                    if (parts.Length > 3)
                    {
                        bool isComplete = false;
                        bool.TryParse(parts[3], out isComplete); // Use TryParse to avoid exceptions
                        
                        if (isComplete)
                        {
                            // Call RecordEvent to properly mark as complete
                            goal.RecordEvent();
                        }
                    }
                    break;
                    
                case "EternalGoal":
                    if (parts.Length < 4)
                        throw new FormatException("EternalGoal format is incorrect.");
                    
                    int eternalPointValue = 0;
                    if (parts.Length > 2) 
                        int.TryParse(parts[2], out eternalPointValue);
                    
                    goal = new EternalGoal(
                        parts.Length > 0 ? parts[0] : "", 
                        parts.Length > 1 ? parts[1] : "", 
                        eternalPointValue);
                    break;
                    
                case "ChecklistGoal":
                    if (parts.Length < 7)
                        throw new FormatException("ChecklistGoal format is incorrect.");
                    
                    // Use safe default values
                    int targetCount = 1;  // Default to 1 to avoid validation errors
                    int currentCount = 0;
                    int bonusPoints = 0;
                    int checklistPointValue = 0;
                    
                    // Try to parse the values, but use defaults if parsing fails
                    if (parts.Length > 2) 
                        int.TryParse(parts[2], out checklistPointValue);
                    if (parts.Length > 4) 
                        int.TryParse(parts[4], out targetCount);
                    if (targetCount <= 0) 
                        targetCount = 1;  // Ensure target count is at least 1
                        
                    if (parts.Length > 5) 
                        int.TryParse(parts[5], out currentCount);
                    if (currentCount < 0) 
                        currentCount = 0;
                        
                    if (parts.Length > 6) 
                        int.TryParse(parts[6], out bonusPoints);
                    
                    goal = new ChecklistGoal(
                        parts.Length > 0 ? parts[0] : "", 
                        parts.Length > 1 ? parts[1] : "", 
                        checklistPointValue,
                        targetCount,
                        bonusPoints);
                    
                    // Handle the current count 
                    ChecklistGoal checklistGoal = (ChecklistGoal)goal;
                    // Set the count directly first to avoid calling RecordEvent too many times
                    checklistGoal.CurrentCount = 0;
                    
                    // Then call RecordEvent for each completion to ensure internal state is updated correctly
                    for (int i = 0; i < currentCount; i++)
                    {
                        checklistGoal.RecordEvent();
                    }
                    break;
                    
                case "ProgressiveGoal":
                    if (parts.Length < 7)
                        throw new FormatException("ProgressiveGoal format is incorrect.");
                    
                    // Use safe default values
                    int totalSteps = 1;  // Default to 1 to avoid validation errors
                    int currentStep = 0;
                    int finalBonus = 0;
                    int progressivePointValue = 0;
                    
                    // Try to parse the values, but use defaults if parsing fails
                    if (parts.Length > 2) 
                        int.TryParse(parts[2], out progressivePointValue);
                    if (parts.Length > 4) 
                        int.TryParse(parts[4], out totalSteps);
                    if (totalSteps <= 0) 
                        totalSteps = 1;  // Ensure total steps is at least 1
                        
                    if (parts.Length > 5) 
                        int.TryParse(parts[5], out currentStep);
                    if (currentStep < 0) 
                        currentStep = 0;
                        
                    if (parts.Length > 6) 
                        int.TryParse(parts[6], out finalBonus);
                    
                    goal = new ProgressiveGoal(
                        parts.Length > 0 ? parts[0] : "", 
                        parts.Length > 1 ? parts[1] : "", 
                        progressivePointValue,
                        totalSteps,
                        finalBonus);
                    
                    // Handle the current step
                    ProgressiveGoal progressiveGoal = (ProgressiveGoal)goal;
                    // Set the step directly first to avoid calling RecordEvent too many times
                    progressiveGoal.CurrentStep = 0;
                    
                    // Then call RecordEvent for each step to ensure internal state is updated correctly
                    for (int i = 0; i < currentStep; i++)
                    {
                        progressiveGoal.RecordEvent();
                    }
                    break;
                    
                case "NegativeGoal":
                    if (parts.Length < 5)
                        throw new FormatException("NegativeGoal format is incorrect.");
                    
                    int negativePointValue = 0;
                    if (parts.Length > 2) 
                        int.TryParse(parts[2], out negativePointValue);
                    
                    goal = new NegativeGoal(
                        parts.Length > 0 ? parts[0] : "", 
                        parts.Length > 1 ? parts[1] : "", 
                        negativePointValue);
                    
                    // Set occurrence count if available
                    if (parts.Length > 4)
                    {
                        int occurrenceCount = 0;
                        int.TryParse(parts[4], out occurrenceCount);
                        ((NegativeGoal)goal).OccurrenceCount = occurrenceCount;
                    }
                    break;
                    
                default:
                    throw new FormatException($"Unknown goal type: {goalType}");
            }
            
            return goal;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error creating goal: {ex.Message}");
            return null;
        }
    }
    
    // Helper method to show file contents
    private void ShowFileContents(string filename)
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
            
            // Show the first line (score)
            Console.WriteLine(lines[0]);
            
            // Show first few goals (up to 5)
            int goalCount = Math.Min(lines.Length - 1, 5);
            for (int i = 1; i <= goalCount; i++)
            {
                Console.WriteLine(lines[i]);
            }
            
            // If more than 5 goals, just show count
            if (lines.Length > 6)
            {
                Console.WriteLine($"... and {lines.Length - 6} more goals");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading file: {ex.Message}");
        }
    }
}