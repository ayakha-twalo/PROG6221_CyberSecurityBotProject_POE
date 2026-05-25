using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CybersecurityChatbot
{
    public partial class MainWindow : Window
    {
        private ChatBot bot;

        public MainWindow()
        {
            InitializeComponent();

            bot = new ChatBot();

            // Show greeting first
            ChatBox.Text += bot.GetGreeting() + "\n";

            // Play audio after GUI loads
            Loaded += MainWindow_Loaded;
        }

        // Runs after window fully appears
        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // Small delay so GUI fully renders first
            await Task.Delay(500);

            // Play greeting audio
            AudioPlayer.PlayGreeting();
        }

        // Send button click
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

        // Main messaging system
        private async Task SendMessage()
        {
            string input = InputBox.Text;

            if (string.IsNullOrWhiteSpace(input))
            {
                return;
            }

            // Show user message
            ChatBox.Text += "\nYou: " + input + "\n";

            // Clear input immediately
            InputBox.Clear();

            // Get chatbot response
            string response = bot.ProcessInput(input);

            // Typing indicator
            ChatBox.Text += "\nBot is typing...\n";

            ChatBox.ScrollToEnd();

            // Delay before response
            await Task.Delay(1000);

            // typing message
            ChatBox.Text = ChatBox.Text.Replace("\nBot is typing...\n", "");

            // Type response slowly
            ChatBox.Text += "\nBot: ";

            foreach (char letter in response)
            {
                ChatBox.Text += letter;

                ChatBox.ScrollToEnd();

                await Task.Delay(5);
            }

            ChatBox.Text += "\n";
        }
    }
}