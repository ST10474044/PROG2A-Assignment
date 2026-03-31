using System;
using System.IO;
using System.Media;
using System.Runtime.InteropServices;

namespace CyberGuardSA
{
    public class AudioPlayer
    {
        private string _audioFilePath;

        public AudioPlayer()
        {
            // Look for the audio file in the executable directory
            _audioFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "greeting.wav");
        }

        public void PlayWelcomeGreeting()
        {
            try
            {
                if (File.Exists(_audioFilePath))
                {
                    // Play the audio file
                    using (SoundPlayer player = new SoundPlayer(_audioFilePath))
                    {
                        player.PlaySync(); // Play synchronously (waits for completion)
                    }

                    Console.ForegroundColor = ConsoleColor.Green;


                else
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;

                    }
                } 
            }


            {
                Console.ForegroundColor = ConsoleColor.Yellow;
               
            }
        }

        // Alternative method using Windows API if SoundPlayer fails
        private void PlayUsingWindowsAPI()
        {
            try
            {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    // Use Windows Media Player COM object as fallback
                    dynamic? wmp = Activator.CreateInstance(Type.GetTypeFromProgID("WMPlayer.OCX"));
                    if (wmp != null)
                    {
                        wmp.URL = _audioFilePath;
                        wmp.controls.play();
                        System.Threading.Thread.Sleep(3000); // Wait for playback to start
                    }
                }
            }
            catch
            {
                // Silently fail - we already have fallback
            }
        }
    }
}

