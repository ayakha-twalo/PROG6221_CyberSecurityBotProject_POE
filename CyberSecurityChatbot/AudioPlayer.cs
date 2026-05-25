using System.Media;

namespace CybersecurityChatbot
{
    public class AudioPlayer
    {
        public static void PlayGreeting()
        {
            try
            {
                SoundPlayer player = new SoundPlayer("greeting.wav");

                player.PlaySync();
            }
            catch
            {
                // Ignore audio errors
            }
        }
    }
}