using System;
using System.Linq;

namespace CybersecurityChatbot
{
    public class ChatBot
    {
        private KeywordResponder keywords;
        private SentimentDetector sentimentDetector;
        private MemoryStore memory;

        // Tracks whether user still needs to enter name
        private bool awaitingName = true;

        // Stores last discussed topic
        private string lastTopic = "";

        // Constructor
        public ChatBot()
        {
            keywords = new KeywordResponder();
            sentimentDetector = new SentimentDetector();
            memory = new MemoryStore();
        }

        // Starting greeting
        public string GetGreeting()
        {
            return

        "Welcome to the Cybersecurity Awareness Bot. What is your name?";
        }

        // Main chatbot processing method
        public string ProcessInput(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return "I didn't receive anything. Please type a message so I can help you.";
            }

            input = input.ToLower();

            // STEP 1: Capture user name
            if (awaitingName)
            {
                memory.UserName = char.ToUpper(input[0]) + input.Substring(1);

                awaitingName = false;

                return $"Nice to meet you, {memory.UserName}! I'm here to help you stay safe online. You can ask me anything about cybersecurity.";
            }

            // STEP 2: Follow-up handling
            if (input.Contains("tell me more") ||
                input.Contains("another tip") ||
                input.Contains("explain more") ||
                input.Contains("more"))
            {
                if (!string.IsNullOrEmpty(lastTopic))
                {
                    return $"Here is more information about {lastTopic}:\n" +
                           keywords.GetAnotherResponse(lastTopic);
                }
                else
                {
                    return "Please ask about a cybersecurity topic first.";
                }
            }

            // STEP 3: Detect favourite topic
            if (input.Contains("interested in") ||
                input.Contains("i like") ||
                input.Contains("favourite topic") ||
                input.Contains("favorite topic") ||
                input.Contains("i enjoy"))
            {
                string[] allTopics = keywords.GetAllKeywords().ToArray();

                foreach (string topic in allTopics)
                {
                    if (input.Contains(topic))
                    {
                        memory.FavouriteTopic = topic;

                        lastTopic = topic;

                        return $"Great! I'll remember that you're interested in {topic}. It's a very important cybersecurity topic.";
                    }
                }
            }

            // STEP 4: Activity Log Requests
            if (input.Contains("show activity log") ||
                input.Contains("show log") ||
                input.Contains("what have you done for me") ||
                input.Contains("recent actions"))
            {
                var activities = ActivityLogger.GetActivities();

                if (activities.Count == 0)
                {
                    return "No activities have been recorded yet.";
                }

                string logText = "Recent Activities:\n\n";

                int start = activities.Count > 5
                    ? activities.Count - 5
                    : 0;

                for (int i = start; i < activities.Count; i++)
                {
                    logText += activities[i] + "\n";
                }

                return logText;
            }

            // STEP 4B: Show Full Activity Log
            if (input.Contains("show more") ||
                input.Contains("full log") ||
                input.Contains("all activities"))
            {
                var activities = ActivityLogger.GetActivities();

                if (activities.Count == 0)
                {
                    return "No activities have been recorded yet.";
                }

                string logText = "Complete Activity Log:\n\n";

                foreach (string activity in activities)
                {
                    logText += activity + "\n";
                }

                return logText;
            }

            // STEP 4C: Quiz Intents
            if (input.Contains("start quiz") ||
                input.Contains("quiz me") ||
                input.Contains("take quiz") ||
                input.Contains("take a quiz") ||
                input.Contains("test my knowledge") ||
                input.Contains("play the game"))
            {
                return "Great! Click on the Quiz tab to begin the Cybersecurity Quiz and test your knowledge.";
            }

            // STEP 5: Sentiment detection
            Sentiment sentiment = sentimentDetector.Detect(input);

            string sentimentResponse =
                sentimentDetector.GetSentimentResponse(sentiment);

            string keywordResponse =
                keywords.GetResponse(input);

            // Combine response properly
            if (keywordResponse != null)
            {
                lastTopic = keywords.GetTopic(input);

                string personalised = "";

                if (!string.IsNullOrEmpty(lastTopic))
                {
                    personalised =
                        $"As someone interested or worried about {lastTopic}, ";
                }

                return sentimentResponse +
                       personalised +
                       keywordResponse;
            }

            // STEP 6: Special responses
            if (input.Contains("how are you"))
            {
                return "I'm just a chatbot, but I'm ready to help you stay safe online!";
            }

            if (input.Contains("purpose"))
            {
                return "My purpose is to help people learn about cybersecurity awareness.";
            }

            if (input.Contains("what can i ask"))
            {
                return "You can ask me about cybersecurity topics such as:\n\n" +
                       "- Password safety (how to create strong passwords)\n" +
                       "- Phishing (how to identify fake emails and links)\n" +
                       "- Scams (how to avoid getting scammed online)\n" +
                       "- Online privacy (how to protect your personal information)\n" +
                       "- Malware protection (how to avoid viruses and unsafe downloads)\n" +
                       "- Two-factor authentication (extra account security)\n" +
                       "- Safe browsing (how to use the internet securely)\n" +
                       "- Social media safety (how to protect your identity and privacy online)\n" +
                       "- Public WiFi safety (how to avoid risks on unsecured networks)\n\n";
            }

            if (input.Contains("thank you"))
            {
                return $"You're welcome, {memory.UserName}!";
            }

            // STEP 7: Default fallback response
            return "I'm not sure I understand that yet. Try asking about passwords, phishing, scams, privacy, malware, 2FA, social media safety, public WiFi safety or safe browsing.";
        }
    }
}