using System.Collections.Generic;

namespace CybersecurityChatbot
{
    public class QuizManager
    {
        // Stores all quiz questions
        private List<QuizQuestion> questions;

        // Current question index
        private int currentQuestion;

        // User score
        private int score;

        public QuizManager()
        {
            questions = new List<QuizQuestion>();

            LoadQuestions();

            currentQuestion = 0;
            score = 0;
        }

        // Add all quiz questions
        private void LoadQuestions()
        {
            questions.Add(new QuizQuestion
            {
                Question = "What should you do if you receive an email asking for your password?",
                OptionA = "Reply with your password",
                OptionB = "Delete the email",
                OptionC = "Report it as phishing",
                OptionD = "Ignore it",
                CorrectAnswer = "C",
                Explanation = "Reporting phishing emails helps prevent scams."
            });

            questions.Add(new QuizQuestion
            {
                Question = "What does 2FA stand for?",
                OptionA = "Two-Factor Authentication",
                OptionB = "Two File Access",
                OptionC = "Two Firewall Applications",
                OptionD = "Two Fast Accounts",
                CorrectAnswer = "A",
                Explanation = "2FA adds an extra layer of account security."
            });

            questions.Add(new QuizQuestion
            {
                Question = "Which password is strongest?",
                OptionA = "123456",
                OptionB = "password",
                OptionC = "John1999",
                OptionD = "T@9x#P2!Lm7",
                CorrectAnswer = "D",
                Explanation = "Strong passwords use letters, numbers and symbols."
            });

            questions.Add(new QuizQuestion
            {
                Question = "What is phishing?",
                OptionA = "A fishing hobby",
                OptionB = "A cyberattack that tricks users",
                OptionC = "An antivirus tool",
                OptionD = "A browser",
                CorrectAnswer = "B",
                Explanation = "Phishing tricks users into revealing sensitive information."
            });

            questions.Add(new QuizQuestion
            {
                Question = "Should you use public WiFi for online banking?",
                OptionA = "Yes",
                OptionB = "No",
                OptionC = "Sometimes",
                OptionD = "Always",
                CorrectAnswer = "B",
                Explanation = "Public WiFi can expose sensitive information."
            });

            questions.Add(new QuizQuestion
            {
                Question = "What is malware?",
                OptionA = "A cyber threat",
                OptionB = "A web browser",
                OptionC = "A password manager",
                OptionD = "An email",
                CorrectAnswer = "A",
                Explanation = "Malware is harmful software."
            });

            questions.Add(new QuizQuestion
            {
                Question = "Why should software be updated?",
                OptionA = "For fun",
                OptionB = "To remove files",
                OptionC = "To improve security",
                OptionD = "To slow the computer",
                CorrectAnswer = "C",
                Explanation = "Updates often fix security vulnerabilities."
            });

            questions.Add(new QuizQuestion
            {
                Question = "Should you share passwords with friends?",
                OptionA = "Yes",
                OptionB = "No",
                OptionC = "Sometimes",
                OptionD = "Only online",
                CorrectAnswer = "B",
                Explanation = "Passwords should remain private."
            });

            questions.Add(new QuizQuestion
            {
                Question = "What is social engineering?",
                OptionA = "Building websites",
                OptionB = "Designing software",
                OptionC = "Manipulating people for information",
                OptionD = "Creating passwords",
                CorrectAnswer = "C",
                Explanation = "Attackers manipulate people into revealing information."
            });

            questions.Add(new QuizQuestion
            {
                Question = "HTTPS websites are generally:",
                OptionA = "More secure",
                OptionB = "Less secure",
                OptionC = "Unsafe",
                OptionD = "Viruses",
                CorrectAnswer = "A",
                Explanation = "HTTPS encrypts data between users and websites."
            });

            questions.Add(new QuizQuestion
            {
                Question = "What should you do before clicking a link in an email?",
                OptionA = "Click immediately",
                OptionB = "Hover over it to inspect the URL",
                OptionC = "Forward it",
                OptionD = "Reply to the sender",
                CorrectAnswer = "B",
                Explanation = "Always inspect links before clicking them."
            });

            questions.Add(new QuizQuestion
            {
                Question = "What is ransomware?",
                OptionA = "A backup tool",
                OptionB = "A type of malware that locks files",
                OptionC = "A browser extension",
                OptionD = "An antivirus",
                CorrectAnswer = "B",
                Explanation = "Ransomware encrypts files and demands payment."
            });

            questions.Add(new QuizQuestion
            {
                Question = "What is the safest way to store passwords?",
                OptionA = "Write them on paper",
                OptionB = "Use the same password everywhere",
                OptionC = "Use a password manager",
                OptionD = "Store them in emails",
                CorrectAnswer = "C",
                Explanation = "Password managers securely store complex passwords."
            });

            questions.Add(new QuizQuestion
            {
                Question = "What does a VPN help protect?",
                OptionA = "Internet traffic",
                OptionB = "Computer screen",
                OptionC = "Keyboard",
                OptionD = "Battery life",
                CorrectAnswer = "A",
                Explanation = "VPNs encrypt internet traffic for added privacy."
            });

            questions.Add(new QuizQuestion
            {
                Question = "True or False: You should use the same password for every account.",
                OptionA = "True",
                OptionB = "False",
                OptionC = "Sometimes",
                OptionD = "Only at work",
                CorrectAnswer = "B",
                Explanation = "Every account should have a unique password."
            });
        }

        // Return current question
        public QuizQuestion GetCurrentQuestion()
        {
            if (currentQuestion >= 0 &&
                currentQuestion < questions.Count)
            {
                return questions[currentQuestion];
            }

            return null;
        }

        // Check answer safely
        public string SubmitAnswer(string answer)
        {
            if (currentQuestion >= questions.Count)
            {
                return GetFinalResult();
            }

            QuizQuestion question =
                questions[currentQuestion];

            string result;

            if (answer.ToUpper() == question.CorrectAnswer)
            {
                score++;
                result = "Correct! " + question.Explanation;
            }
            else
            {
                result = "Incorrect. " + question.Explanation;
            }

            currentQuestion++;

            return result;
        }

        // Quiz finished
        public bool IsFinished()
        {
            return currentQuestion >= questions.Count;
        }

        // Final score
        public string GetFinalResult()
        {
            return $"Quiz Complete!\nScore: {score}/{questions.Count}";
        }

        public string GetProgress()
        {
            int current = currentQuestion + 1;

            if (current > questions.Count)
            {
                current = questions.Count;
            }

            return $"Question {current}/{questions.Count}";
        }

        public void SkipQuestion()
        {
            if (currentQuestion < questions.Count)
            {
                currentQuestion++;
            }
        }
    }
}
