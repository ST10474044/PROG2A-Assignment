using System;
using System.Threading.Tasks;

namespace CyberGuardSA
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.Title = "CyberGuardSA - Cybersecurity Awareness Assistant";
            Console.WindowWidth = 120;
            Console.WindowHeight = 45;

            // Set console encoding for better Unicode support
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            try
            {
                var chatbot = new CyberGuardBot();
                await chatbot.StartAsync();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n❌ Fatal Error: {ex.Message}");
                Console.WriteLine($"Details: {ex.InnerException?.Message ?? "No inner exception"}");
                Console.ResetColor();
                Console.WriteLine("\nPress any key to exit...");
                Console.ReadKey();
            }
        }
    }
}
