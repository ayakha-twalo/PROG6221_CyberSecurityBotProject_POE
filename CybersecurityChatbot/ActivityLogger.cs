using System;
using System.Collections.Generic;

namespace CybersecurityChatbot
{
    // Stores and manages chatbot activity history
    public static class ActivityLogger
    {
        // List that stores all recorded activities
        private static List<string> activities =
            new List<string>();

        // Add a new activity to the log with a timestamp
        public static void Log(string action)
        {
            activities.Add(
                $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {action}");
        }

        // Return all recorded activities
        public static List<string> GetActivities()
        {
            return activities;
        }
    }
}