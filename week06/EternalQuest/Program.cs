/* 
    * Exceeding Requirements:
    * 
    * I've enhanced the basic Eternal Quest program with these additional features:
    * 
    * 1. Added more informative console messages throughout the program to make it
    *    more user-friendly, including confirmation messages when goals are created
    *    or loaded successfully.
    * 
    * 2. Added validation for user input to prevent crashes from invalid inputs, 
    *    such as non-numeric values for points or invalid goal indices.
    * 
    * 3. Added error handling with try/catch blocks for file operations to prevent
    *    crashes if there are issues with saving or loading goals.
    * 
    * 4. Created overloaded constructors for the goal classes to make it easier to
    *    create goals when loading from a file versus creating new ones.
    * 
    * 5. Added a congratulatory message when a user completes a goal, which enhances
    *    the "gamification" aspect of the program and provides positive reinforcement.
    * 
    * 6. Enhanced the GetDetailsString method to provide more detailed information
    *    about each goal, especially for checklist goals where progress is shown.
    * 
    * 7. Made the goal listing show empty goals list messages when appropriate, which
    *    improves the user experience by not showing empty lists.
    * 
    * 8. Added a new goal type: LevelUpGoal - This represents progress toward a larger goal
    *    that has multiple levels. Each time the user records an event, they level up and 
    *    receive points plus a bonus. This adds depth to the gamification aspect.
    * 
    * 9. Added a NegativeGoal type for tracking bad habits. When users record these goals,
    *    they lose points, which introduces a penalty system for things they want to avoid.
    * 
    * 10. Created a comprehensive GamificationManager class that provides:
    *     - A player leveling system with titles for each level
    *     - Achievement tracking based on point milestones
    *     - Badge system for completing different types of goals
    *     - Detailed player status display
    *     - Level-up celebrations with custom messages
    * 
    * 11. Enhanced the menu system to include a player status option for viewing
    *     detailed information about achievements, badges, and progress.
*/



using System;

namespace EternalQuest
{
    class Program
    {
        static void Main(string[] args)
        {
            // Extra Creativity: This version uses an interactive console menu to let the user
            // create and track goals along with saving and loading. You can extend it further with
            // features like leveling up or bonus rewards.
            GoalManager goalManager = new GoalManager();
            goalManager.Start();
        }
    }
}