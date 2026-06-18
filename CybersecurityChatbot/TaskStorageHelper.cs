using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace CybersecurityChatbot
{
    public class TaskStorageHelper
    {
        private const string FilePath = "tasks.json";

        // Load all tasks from the JSON file
        public List<CyberTask> LoadTasks()
        {
            try
            {
                if (!File.Exists(FilePath))
                {
                    return new List<CyberTask>();
                }

                string json = File.ReadAllText(FilePath);

                return JsonConvert.DeserializeObject<List<CyberTask>>(json)
                       ?? new List<CyberTask>();
            }
            catch
            {
                return new List<CyberTask>();
            }
        }

        // Save all tasks to the JSON file
        public void SaveTasks(List<CyberTask> tasks)
        {
            try
            {
                string json =
                    JsonConvert.SerializeObject(tasks, Formatting.Indented);

                File.WriteAllText(FilePath, json);
            }
            catch
            {
            }
        }

        // Add a new task to storage
        public void AddTask(string title, string description, string reminder)
        {
            List<CyberTask> tasks = LoadTasks();

            int newId = tasks.Count > 0
                ? tasks[tasks.Count - 1].Id + 1
                : 1;

            tasks.Add(new CyberTask
            {
                Id = newId,
                Title = title,
                Description = description,
                Reminder = reminder,
                IsComplete = false,
                CreatedAt = DateTime.Now.ToString("yyyy-MM-dd HH:mm")
            });

            SaveTasks(tasks);
        }

        // Mark a task as completed
        public void MarkAsComplete(int id)
        {
            List<CyberTask> tasks = LoadTasks();

            CyberTask task = tasks.Find(t => t.Id == id);

            if (task != null)
            {
                task.IsComplete = true;

                // save updated task list
                SaveTasks(tasks);
            }
        }

        // Deleting a task using its ID
        public void DeleteTask(int id)
        {
            // load all tasks
            List<CyberTask> tasks = LoadTasks();

            // remove matching task
            tasks.RemoveAll(t => t.Id == id);

            // save updated task list
            SaveTasks(tasks);
        }
    }
}

