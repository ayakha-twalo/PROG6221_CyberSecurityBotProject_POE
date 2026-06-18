using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace CybersecurityChatbot
{
    public partial class MainWindow : Window
    {
        // Chatbot object
        private ChatBot bot;

        // Task manager object
        private TaskManager taskManager;

        // Quiz manager object
        private QuizManager quizManager;

        public MainWindow()
        {
            InitializeComponent();

            // Create chatbot
            bot = new ChatBot();

            // Create task manager
            taskManager = new TaskManager();

            // Create quiz manager
            quizManager = new QuizManager();

            // TEST ACTIVITY LOG ENTRY
            ActivityLogger.Log("Application Started");

            // Show chatbot greeting
            AddMessage(bot.GetGreeting(), false);

            // Load saved tasks into ListBox
            LoadTasks();

            // Load first quiz question
            LoadQuizQuestion();

            ActivityLogger.Log("Quiz Started");

            // Play greeting audio after GUI loads
            Loaded += MainWindow_Loaded;
        }

        // Runs after window fully appears
        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            await Task.Delay(500);

            AudioPlayer.PlayGreeting();
        }

        // Send button clicked
        private async void Send_Click(object sender, RoutedEventArgs e)
        {
            await SendMessage();
        }

        // Enter key support
        private async void InputBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                await SendMessage();
            }
        }

        // Main chatbot messaging system
        private async Task SendMessage()
        {
            string input = InputBox.Text;

            if (string.IsNullOrWhiteSpace(input))
            {
                return;
            }

            AddMessage(input, true);

            InputBox.Clear();

            string lowerInput = input.ToLower();

            string response;

            if (lowerInput.Contains("add task") ||
                lowerInput.Contains("add a task") ||
                lowerInput.Contains("create task") ||
                lowerInput.Contains("i need to") ||
                lowerInput.Contains("enable") ||
                lowerInput.Contains("set up") ||
                lowerInput.Contains("remind me") ||
                lowerInput.Contains("reminder") ||
                lowerInput.Contains("set a reminder") ||
                lowerInput.Contains("don't forget"))
            {
                string taskTitle = input;
                string reminder = "Not specified";

                if (lowerInput.Contains("in "))
                {
                    int index = lowerInput.LastIndexOf("in ");

                    reminder = input.Substring(index);

                    taskTitle = input.Substring(0, index).Trim();
                }

                taskManager.AddTask(
                     taskTitle, "Created through chatbot NLP",reminder);

                if (reminder != "Not specified")
                {
                    ActivityLogger.Log(
                        $"Reminder Set - {taskTitle} ({reminder})");
                }

                LoadTasks();

                ActivityLogger.Log(
                    $"Task Added via NLP - {input}");

                response =
                    $"I've created a task for you: '{input}'. Check the Tasks tab to view it.";
            }

            else if (lowerInput.Contains("start quiz") ||
                     lowerInput.Contains("take quiz") ||
                     lowerInput.Contains("take a quiz") ||
                     lowerInput.Contains("quiz me") ||
                     lowerInput.Contains("test my knowledge") ||
                     lowerInput.Contains("play the game"))
            {
                
                response =
                    "Great! Open the Quiz tab to begin your cybersecurity quiz.";
            }

            else if (lowerInput.Contains("show activity log") ||
                     lowerInput.Contains("activity log") ||
                     lowerInput.Contains("what have you done for me") ||
                     lowerInput.Contains("what did you do") ||
                     lowerInput.Contains("show log") ||
                     lowerInput.Contains("recent actions") ||
                     lowerInput.Contains("show recent actions"))
            {
                response = GetRecentActivities();
            }

            else
            {
                response = bot.ProcessInput(input);
            }

            // Show typing indicator
            AddMessage("Typing...", false);

            await Task.Delay(1500);

            // Remove typing indicator
            if (ChatPanel.Children.Count > 0)
            {
                ChatPanel.Children.RemoveAt(ChatPanel.Children.Count - 1);
            }

            // Show response
            AddMessage(response, false);
        }

        // ================= TASK ASSISTANT =================

        // Load all saved tasks into the ListBox
        private void LoadTasks()
        {
            TaskListBox.Items.Clear();

            foreach (CyberTask task in taskManager.GetAllTasks())
            {
                string status =
                    task.IsComplete ? "✓ COMPLETED" : "PENDING";

                TaskListBox.Items.Add(
                    $"{task.Id} | {status} | {task.Title} | {task.Description} | Reminder: {task.Reminder}");
            }
        }

        // Add task button
        private void AddTaskButton_Click(object sender, RoutedEventArgs e)
        {
            string title = TaskTitleBox.Text;
            string description = TaskDescriptionBox.Text;
            string reminder = ReminderBox.Text;

            if (string.IsNullOrWhiteSpace(title))
            {
                MessageBox.Show("Please enter a task title.");
                return;
            }

            string result =
                taskManager.AddTask(title, description, reminder);

            if (!string.IsNullOrWhiteSpace(reminder) && reminder != "Reminder (Optional)")
            {
                ActivityLogger.Log(
                    $"Reminder Set - {title} ({reminder})");
            }

            MessageBox.Show(result);

            // Reload task list
            LoadTasks();

            // Restore default textbox text
            TaskTitleBox.Text = "Task Title";
            TaskDescriptionBox.Text = "Task Description";
            ReminderBox.Text = "Reminder (Optional)";
        }

        // Complete selected task
        private void CompleteTaskButton_Click(object sender,
                                              RoutedEventArgs e)
        {
            if (TaskListBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a task.");
                return;
            }

            string selected =
                TaskListBox.SelectedItem.ToString();

            int taskId =
                int.Parse(selected.Split('|')[0].Trim());

            taskManager.CompleteTask(taskId);

            LoadTasks();

            MessageBox.Show("Task marked as completed.");
        }

        // Delete selected task
        private void DeleteTaskButton_Click(object sender,
                                            RoutedEventArgs e)
        {
            if (TaskListBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a task.");
                return;
            }

            string selected =
                TaskListBox.SelectedItem.ToString();

            int taskId =
                int.Parse(selected.Split('|')[0].Trim());

            taskManager.DeleteTask(taskId);
            
            LoadTasks();

            MessageBox.Show("Task deleted successfully.");
        }

        // ================= QUIZ =================

        private void LoadQuizQuestion()
        {
            QuizQuestion question =
                quizManager.GetCurrentQuestion();

            if (question == null)
            {
                QuizQuestionText.Text =
                    quizManager.GetFinalResult();

                QuizProgressText.Text = "";

                return;
            }

            QuizQuestionText.Text = question.Question;

            OptionA.Content = question.OptionA;
            OptionB.Content = question.OptionB;
            OptionC.Content = question.OptionC;
            OptionD.Content = question.OptionD;

            QuizProgressText.Text =
                quizManager.GetProgress();
        }

        private void SubmitAnswerButton_Click(object sender,
                                              RoutedEventArgs e)
        {
            string selectedAnswer = "";

            if (OptionA.IsChecked == true)
                selectedAnswer = "A";
            else if (OptionB.IsChecked == true)
                selectedAnswer = "B";
            else if (OptionC.IsChecked == true)
                selectedAnswer = "C";
            else if (OptionD.IsChecked == true)
                selectedAnswer = "D";

            if (string.IsNullOrEmpty(selectedAnswer))
            {
                MessageBox.Show("Please select an answer.");
                return;
            }

            QuizFeedbackText.Text =
                quizManager.SubmitAnswer(selectedAnswer);

            ActivityLogger.Log(
                $"Quiz Question Answered - Selected {selectedAnswer}");

        }

        private void NextQuestionButton_Click(object sender,
                                      RoutedEventArgs e)
        {
            if (quizManager.IsFinished())
            {
                string result =
                    quizManager.GetFinalResult();

                QuizQuestionText.Text = result;

                QuizFeedbackText.Text = "";

                ActivityLogger.Log(
                    $"Quiz Completed - {quizManager.GetFinalResult().Replace("\n", " ")}");

                return;
            }

            quizManager.SkipQuestion();

            if (quizManager.IsFinished())
            {
                QuizQuestionText.Text =
                    quizManager.GetFinalResult();

                QuizFeedbackText.Text = "";

                QuizProgressText.Text = "";

                return;
            }

            LoadQuizQuestion();

            QuizFeedbackText.Text = "";

            OptionA.IsChecked = false;
            OptionB.IsChecked = false;
            OptionC.IsChecked = false;
            OptionD.IsChecked = false;
        }

        private void RefreshLogButton_Click(object sender,
                                     RoutedEventArgs e)
        {
            ActivityLogListBox.Items.Clear();

            List<string> activities =
                ActivityLogger.GetActivities();

            int startIndex =
                Math.Max(0, activities.Count - 10);

            for (int i = startIndex; i < activities.Count; i++)
            {
                ActivityLogListBox.Items.Add(activities[i]);
            }
        }

        private void ShowAllLogButton_Click(object sender,
                                    RoutedEventArgs e)
        {
            ActivityLogListBox.Items.Clear();

            foreach (string activity in ActivityLogger.GetActivities())
            {
                ActivityLogListBox.Items.Add(activity);
            }
        }

        private string GetRecentActivities()
        {
            var activities = ActivityLogger.GetActivities();

            if (activities.Count == 0)
            {
                return "No activity has been recorded yet.";
            }

            string result = "Here's a summary of recent actions:\n\n";

            int startIndex =
                Math.Max(0, activities.Count - 5);

            for (int i = startIndex; i < activities.Count; i++)
            {
                result +=
                    $"{i - startIndex + 1}. {activities[i]}\n";
            }

            return result;
        }

        private void AddMessage(string message, bool isUser)
        {
            Border bubble = new Border();

            bubble.CornerRadius = new CornerRadius(15);
            bubble.Padding = new Thickness(12);
            bubble.Margin = new Thickness(5);
            bubble.MaxWidth = 320;

            if (isUser)
            {
                bubble.Background =
                    new System.Windows.Media.SolidColorBrush(
                        System.Windows.Media.Color.FromRgb(0, 90, 160));

                bubble.HorizontalAlignment =
                    HorizontalAlignment.Right;
            }
            else
            {
                bubble.Background =
                    new System.Windows.Media.SolidColorBrush(
                        System.Windows.Media.Color.FromRgb(45, 45, 48));

                bubble.HorizontalAlignment =
                    HorizontalAlignment.Left;
            }

            TextBlock text = new TextBlock();

            text.Text = message;
            text.Foreground = System.Windows.Media.Brushes.White;
            text.TextWrapping = TextWrapping.Wrap;
            text.FontSize = 14;

            bubble.Child = text;

            ChatPanel.Children.Add(bubble);

            ChatScrollViewer.ScrollToEnd();
        }
    }
}