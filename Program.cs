using System;

class Program
{
    static void Main(string[] args)
    {
    
        // Calls the method in AudioPlayer class to play a WAV greeting
        AudioPlayer.PlayGreeting();

        // Adds visuals when the chatbot starts
        Console.ForegroundColor = ConsoleColor.Magenta; // Change text color
        Console.WriteLine(@"
   ____        _               ____        _   
  / ___| _   _| |__   ___ _ __| __ )  ___ | |_ 
 | |    | | | | '_ \ / _ \ '__|  _ \ / _ \| __|
 | |___ | |_| | |_) |  __/ |  | |_) | (_) | |_ 
  \____| \__, |_.__/ \___|_|  |____/ \___/ \__|
         |___/                                
");
        // reset text color to default
        Console.ResetColor();
 
        // Makes it clear the program is a Cybersecurity Awareness Bot
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("====================================");
        Console.WriteLine("   CYBERSECURITY AWARENESS BOT");
        Console.WriteLine("====================================");
        Console.ResetColor();

        // asks the user for name
        Console.Write("\nEnter your name: ");
        string name = Console.ReadLine();

        // check if name is empty
        if (string.IsNullOrWhiteSpace(name))
        {
            name = "User";
        }

        // greeting with user name
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine("\nHello " + name + "! Welcome to the Cybersecurity Awareness Bot.");
        Console.ResetColor();

        // start chat loop
        // loop will continue until uder types "exit"
        while (true)
        {
            // prompt user
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("\nAsk a question: ");
            Console.ResetColor();

            string input = Console.ReadLine().ToLower();

            // check for empty input
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please enter something.");
                Console.ResetColor();
            }
            // check for exit command
            else if (input.Contains("exit"))
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Goodbye " + name + "! Stay safe online.");
                Console.ResetColor();
                break; // end loop and program
            }
            else
            {
                // pass input to chatbot for response
                Chatbot.Respond(input);
            }
        }
    }
}
