using System;
using System.Threading;

class Chatbot
{
    // Handles all responses based on user input
    public static void Respond(string input)
    {
        // Simple conditionals to detect keywords
        if (input.Contains("how are you"))
        {
            Console.WriteLine("I'm just a bot, but I'm here to help!");
        }
        else if (input.Contains("What is your purpose"))
        {
            Console.WriteLine("I help you stay safe online.");
        }
        else if (input.Contains("what can i ask"))
        {
            Console.WriteLine("You can ask me about passwords, phishing, safe browsing, scams, and 2fa.");
        }
        else if (input.Contains("password"))
        {
            Console.WriteLine("Use strong passwords with a mix of letters, numbers, and symbols.");
        }
        else if (input.Contains("phishing"))
        {
            Console.WriteLine("Be careful of fake emails or links pretending to be real companies.");
        }
        else if (input.Contains("safe browsing"))
        {
            Console.WriteLine("Only visit secure websites and avoid downloading unknown files.");
        }
        else if (input.Contains("2fa") || input.Contains("two factor"))
        {
            Console.WriteLine("Two-factor authentication adds an extra layer of security.");
        }
        else if (input.Contains("scam"))
        {
            Console.WriteLine("Avoid scams by not sharing personal information online.");
        }
        else
        {
            // Default response if input is unrecognized
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("I didn't quite understand that. Could you rephrase?");
            Console.ResetColor();
        }

        // Small delay for typing effect
        Thread.Sleep(300);
    }
}
