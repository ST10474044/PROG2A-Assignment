using System;
using System.Threading.Tasks;

namespace CyberGuardSA
{
    public class CyberGuardBot
    {
        private UIManager _uiManager;
        private ResponseEngine _responseEngine;
        private AudioPlayer _audioPlayer;
        private string _userName;
        private bool _isActive;

        public CyberGuardBot()
        {
            _uiManager = new UIManager();
            _responseEngine = new ResponseEngine();
            _audioPlayer = new AudioPlayer();
            _isActive = true;
        }

        public async Task StartAsync()
        {
            // Play voice greeting
            _audioPlayer.PlayWelcomeGreeting();

            // Display ASCII art and welcome
            _uiManager.DisplayCyberGuardLogo();
            await Task.Delay(800);
            _uiManager.DisplayWelcomeHeader();
            await Task.Delay(500);

            // Get user's name with validation
            _userName = _uiManager.GetUserName();

            // Personalized welcome
            _uiManager.DisplayPersonalizedWelcome(_userName);
            await Task.Delay(800);

            // Show help menu
            _uiManager.ShowHelpMenu();
            await Task.Delay(500);

            // Start conversation loop
            await ConversationLoop();
        }

        private async Task ConversationLoop()
        {
            while (_isActive)
            {
                _uiManager.DisplayPrompt();
                string? userInput = Console.ReadLine()?.Trim();

                // Input validation
                if (string.IsNullOrEmpty(userInput))
                {
                    _uiManager.DisplayInvalidInput();
                    continue;
                }

                // Exit commands
                if (userInput.ToLower() == "exit" ||
                    userInput.ToLower() == "quit" ||
                    userInput.ToLower() == "goodbye" ||
                    userInput.ToLower() == "bye")
                {
                    await ExitChatbot();
                    break;
                }

                // Help command
                if (userInput.ToLower() == "help" ||
                    userInput.ToLower() == "menu" ||
                    userInput.ToLower() == "what can you do" ||
                    userInput.ToLower() == "help me")
                {
                    _uiManager.ShowHelpMenu();
                    continue;
                }

                // Process response with typing effect
                string response = _responseEngine.GetResponse(userInput, _userName);
                await _uiManager.DisplayBotResponseWithTyping(response, _userName);
            }
        }

        private async Task ExitChatbot()
        {
            await _uiManager.DisplayGoodbyeMessage(_userName);
            await Task.Delay(1500);
            _isActive = false;
        }
    }
}
