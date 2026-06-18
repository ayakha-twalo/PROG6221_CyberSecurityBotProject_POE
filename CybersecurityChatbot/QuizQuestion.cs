namespace CybersecurityChatbot
{
    // Represents one quiz question
    public class QuizQuestion
    {
        // Question text
        public string Question { get; set; }

        // Multiple choice options
        public string OptionA { get; set; }
        public string OptionB { get; set; }
        public string OptionC { get; set; }
        public string OptionD { get; set; }

        // Correct answer
        public string CorrectAnswer { get; set; }

        // Explanation shown after answering
        public string Explanation { get; set; }
    }
}