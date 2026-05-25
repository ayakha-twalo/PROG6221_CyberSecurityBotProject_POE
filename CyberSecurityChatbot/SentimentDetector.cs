using System.Collections.Generic;

namespace CybersecurityChatbot
{
    // Sentiment types
    public enum Sentiment
    {
        Neutral,
        Worried,
        Curious,
        Frustrated,
        Happy
    }

    public class SentimentDetector
    {
        // Dictionary of sentiment keywords
        private Dictionary<Sentiment, List<string>> sentimentKeywords;

        public SentimentDetector()
        {
            sentimentKeywords = new Dictionary<Sentiment, List<string>>()
            {
                {
                    Sentiment.Worried,
                    new List<string>
                    {
                        "worried",
                        "scared",
                        "afraid",
                        "anxious",
                        "nervous",
                        "unsafe"
                    }
                },

                {
                    Sentiment.Curious,
                    new List<string>
                    {
                        "curious",
                        "interested",
                        "wondering",
                        "want to know",
                        "how does"
                    }
                },

                {
                    Sentiment.Frustrated,
                    new List<string>
                    {
                        "frustrated",
                        "annoyed",
                        "confused",
                        "don't understand"
                    }
                },

                {
                    Sentiment.Happy,
                    new List<string>
                    {
                        "great",
                        "thanks",
                        "helpful",
                        "awesome",
                        "love it"
                    }
                }
            };
        }

        // Detect sentiment from user input
        public Sentiment Detect(string input)
        {
            input = input.ToLower();

            foreach (var sentiment in sentimentKeywords)
            {
                foreach (string word in sentiment.Value)
                {
                    if (input.Contains(word))
                    {
                        return sentiment.Key;
                    }
                }
            }

            return Sentiment.Neutral;
        }

        // Return empathetic response
        public string GetSentimentResponse(Sentiment sentiment)
        {
            switch (sentiment)
            {
                case Sentiment.Worried:
                    return "It's completely understandable to feel worried. Let me help you stay safe.\n";

                case Sentiment.Curious:
                    return "I'm glad you're curious about cybersecurity. Here's some useful information.\n";

                case Sentiment.Frustrated:
                    return "Cybersecurity can feel confusing sometimes, but I'll explain it simply.\n";

                case Sentiment.Happy:
                    return "I'm happy you're finding this helpful!\n";

                default:
                    return "";
            }
        }
    }
}