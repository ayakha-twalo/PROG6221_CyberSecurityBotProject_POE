using System.Collections.Generic;

namespace CybersecurityChatbot
{
    public class MemoryStore
    {
        // Stores user name
        public string UserName { get; set; }

        // Stores favourite cybersecurity topic
        public string FavouriteTopic { get; set; }

        // Dictionary for storing extra memory values
        private Dictionary<string, string> memory =
            new Dictionary<string, string>();

        // Store information
        public void Store(string key, string value)
        {
            if (memory.ContainsKey(key))
            {
                memory[key] = value;
            }
            else
            {
                memory.Add(key, value);
            }
        }

        // Recall stored information
        public string Recall(string key)
        {
            if (memory.ContainsKey(key))
            {
                return memory[key];
            }

            return "";
        }

        // Personalised response
        public string GetPersonalisedOpener()
        {
            if (!string.IsNullOrEmpty(FavouriteTopic))
            {
                return $"As someone interested in {FavouriteTopic}, ";
            }

            return "";
        }
    }
}