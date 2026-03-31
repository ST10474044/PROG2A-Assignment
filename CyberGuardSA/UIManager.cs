using System;
using System.Threading.Tasks;

namespace CyberGuardSA
{
    public class UIManager
    {
        public void DisplayCyberGuardLogo()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            string logo = @"
    ╔══════════════════════════════════════════════════════════════════════════════╗
    ║                                                                              ║
    ║     ██████╗██╗   ██╗██████╗ ███████╗██████╗     ██████╗ ██╗   ██╗ █████╗    ║
    ║    ██╔════╝╚██╗ ██╔╝██╔══██╗██╔════╝██╔══██╗   ██╔════╝ ██║   ██║██╔══██╗   ║
    ║    ██║      ╚████╔╝ ██████╔╝█████╗  ██████╔╝   ██║  ███╗██║   ██║███████║   ║
    ║    ██║       ╚██╔╝  ██╔══██╗██╔══╝  ██╔══██╗   ██║   ██║██║   ██║██╔══██║   ║
    ║    ╚██████╗   ██║   ██████╔╝███████╗██║  ██║   ╚██████╔╝╚██████╔╝██║  ██║   ║
    ║     ╚═════╝   ╚═╝   ╚═════╝ ╚══════╝╚═╝  ╚═╝    ╚═════╝  ╚═════╝ ╚═╝  ╚═╝   ║
    ║                                                                              ║
    ║                   ███████╗ █████╗     ██████╗███████╗                         ║
    ║                   ██╔════╝██╔══██╗   ██╔════╝██╔════╝                         ║
    ║                   ███████╗███████║   ██║     █████╗                           ║
    ║                   ╚════██║██╔══██║   ██║     ██╔══╝                           ║
    ║                   ███████║██║  ██║   ╚██████╗███████╗                         ║
    ║                   ╚══════╝╚═╝  ╚═╝    ╚═════╝╚══════╝                         ║
    ║                                                                              ║
    ║               S O U T H   A F R I C A   C Y B E R   G U A R D                ║
    ║                      Protecting You in the Digital World                      ║
    ╚══════════════════════════════════════════════════════════════════════════════╝";

            Console.WriteLine(logo);
            Console.ResetColor();
        }

        public void DisplayWelcomeHeader()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n╔══════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                         WELCOME TO CYBERGUARD SA                               ║");
            Console.WriteLine("║              Your Personal Cybersecurity Awareness Assistant                   ║");
            Console.WriteLine("║                      Stay Safe. Stay Secure. Stay Informed.                    ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════════════════════════════╝");
            Console.ResetColor();
            Console.WriteLine();
        }

        public string GetUserName()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("🔐 May I have your name? ");
            Console.ResetColor();

            string? name = Console.ReadLine()?.Trim();

            while (string.IsNullOrEmpty(name))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("⚠️ Please enter a valid name (cannot be empty): ");
                Console.ResetColor();
                name = Console.ReadLine()?.Trim();
            }

            // Capitalize first letter of each word
            return System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(name.ToLower());
        }

        public void DisplayPersonalizedWelcome(string userName)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"\n✨ Hello, {userName}! ✨");
            Console.ResetColor();
            Console.WriteLine("I'm your CyberGuardSA Assistant, here to help you navigate the digital world safely.");
            Console.WriteLine("Together, we'll learn how to protect yourself from online threats.");
            Console.WriteLine();
        }

        public void ShowHelpMenu()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n┌─────────────────────────────────────────────────────────────────────────────┐");
            Console.WriteLine("│                              WHAT I CAN HELP WITH                             │");
            Console.WriteLine("├─────────────────────────────────────────────────────────────────────────────┤");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("│  🔐 Password Safety     │  🎣 Phishing Detection  │  🌐 Secure Browsing     │");
            Console.WriteLine("│  📱 Two-Factor Auth     │  🦠 Malware Protection  │  💬 Social Media Safety │");
            Console.WriteLine("│  🔒 Data Privacy        │  📥 Safe Downloads      │  📶 Wi-Fi Security      │");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("├─────────────────────────────────────────────────────────────────────────────┤");
            Console.WriteLine("│  Try asking:                                                                 │");
            Console.WriteLine("│  • 'How do I create a strong password?'                                      │");
            Console.WriteLine("│  • 'What is phishing and how to avoid it?'                                   │");
            Console.WriteLine("│  • 'How can I browse safely?'                                                │");
            Console.WriteLine("│  • 'What is two-factor authentication?'                                      │");
            Console.WriteLine("│                                                                               │");
            Console.WriteLine("│  Type 'exit' to end our conversation.                                        │");
            Console.WriteLine("└─────────────────────────────────────────────────────────────────────────────┘");
            Console.ResetColor();
            Console.WriteLine();
        }

        public void DisplayPrompt()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\n💬 You: ");
            Console.ResetColor();
        }

        public async Task DisplayBotResponseWithTyping(string response, string userName)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"🤖 {userName}, I say: ");
            Console.ResetColor();

            // Typing effect
            foreach (char c in response)
            {
                Console.Write(c);
                await Task.Delay(15); // Smooth typing effect
            }
            Console.WriteLine("\n");
        }

        public void DisplayInvalidInput()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n⚠️ I didn't quite understand that. Could you rephrase your question?");
            Console.WriteLine("   Try asking about password safety, phishing, or secure browsing.");
            Console.ResetColor();
        }

        public async Task DisplayGoodbyeMessage(string userName)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n╔══════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                              STAY SAFE ONLINE!                                 ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════════════════════════════╝");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\n👋 Goodbye, {userName}! Remember these golden rules:");
            Console.WriteLine("   🔒 Use strong, unique passwords for every account");
            Console.WriteLine("   🛡️ Enable two-factor authentication whenever possible");
            Console.WriteLine("   📧 Think before clicking links in emails or messages");
            Console.WriteLine("   🔄 Keep your software and devices updated");
            Console.WriteLine("   📱 Be careful what you share on social media");
            Console.WriteLine("   🌐 Look for 'https://' in website URLs");
            Console.WriteLine("\nThank you for using CyberGuardSA! Stay vigilant, stay safe!");
            Console.ResetColor();

            await Task.Delay(1000);
        }
    }
}