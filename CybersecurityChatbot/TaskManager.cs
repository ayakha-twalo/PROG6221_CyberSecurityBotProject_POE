using System.Collections.Generic;

namespace CybersecurityChatbot
{
    public class TaskManager
    {
        // Handles saving and loading tasks from JSON storage
        private TaskStorageHelper storage;

        // Constructor
        public TaskManager()
        {
            storage = new TaskStorageHelper();
        }

        // Add a new cybersecurity task
        public string AddTask(string title,
                              string description,
                              string reminder)
        {
            storage.AddTask(title, description, reminder);

            ActivityLogger.Log($"Task Added: {title}");

            return $"Task '{title}' added successfully.";
        }

        // Return all saved tasks
        public List<CyberTask> GetAllTasks()
        {
            return storage.LoadTasks();
        }

        // Mark a task as completed
        public void CompleteTask(int id)
        {
            storage.MarkAsComplete(id);

            ActivityLogger.Log($"Task Completed (ID: {id})");
        }

        // Delete a task
        public void DeleteTask(int id)
        {
            storage.DeleteTask(id);

            ActivityLogger.Log($"Task Deleted (ID: {id})");
        }
    }
}
