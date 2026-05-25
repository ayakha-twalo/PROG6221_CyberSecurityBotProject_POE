using System;
using System.Media;

class AudioPlayer
{
    // plays a recorded WAV greeting when the chatbot starts
    public static void PlayGreeting()
    {
        // Inform the user that audio is loading
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("Loading voice greeting...");
        Console.ResetColor();

        try
        {
            // Provide path to the greeting WAV file
            SoundPlayer player = new SoundPlayer("greeting.wav");
            player.PlaySync(); // Play the sound and wait until it finishes
        }
        catch
        {
            // In case the file is missing or cannot play
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Could not play audio.");
            Console.ResetColor();
        }
    }
}
