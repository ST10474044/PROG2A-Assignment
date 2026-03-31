using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CyberGuardSA
{
    public class ResponseEngine
    {
        private Dictionary<string, string[]> _knowledgeBase;
        private Random _random;

        public ResponseEngine()
        {
            _random = new Random();
            InitializeKnowledgeBase();
        }

        private void InitializeKnowledgeBase()
        {
            _knowledgeBase = new Dictionary<string, string[]>(StringComparer.OrdinalIgnoreCase)
            {
                {
                    "password", new[]
                    {
                        "🔐 Strong passwords are your first line of defense! Use at least 12 characters with a mix of uppercase, lowercase, numbers, and symbols. Never reuse passwords across different sites!",
                        "💡 Pro tip: Use a password manager like Bitwarden or LastPass to generate and store unique passwords. Enable two-factor authentication for extra security!",
                        "⚠️ Avoid using personal info like birthdays or pet names. Consider using passphrases like 'Blue-Tiger-Jumps-42!' - they're strong AND memorable!"
                    }
                },
                {
                    "phish", new[]
                    {
                        "🎣 Phishing attacks trick you into revealing personal info. Always check email sender addresses carefully, hover over links before clicking, and never share sensitive info via email!",
                        "🚨 Red flags: Urgent language, spelling errors, suspicious attachments, and requests for personal info. When in doubt, contact the company directly through official channels!",
                        "📧 In South Africa, be extra cautious of SMS phishing ('smishing') claiming to be from banks like FNB, Capitec, or SARS. They'll never ask for your PIN or password!"
                    }
                },
                {
                    "brows", new[]
                    {
                        "🌐 Safe browsing habits: Always look for 'https://' in URLs, avoid public Wi-Fi for sensitive transactions, and keep your browser updated. Use ad-blockers and privacy extensions!",
                        "🔒 Install browser extensions like HTTPS Everywhere and uBlock Origin. Clear your cookies regularly and use private/incognito mode for sensitive browsing.",
                        "⚠️ Be careful with pop-ups! Never click on pop-up ads claiming your computer is infected. Legitimate antivirus software doesn't use pop-ups to alert you."
                    }
                },
                {
                    "2fa", new[]
                    {
                        "📱 Two-factor authentication adds an extra security layer. Even if someone gets your password, they can't access your account without the second factor!",
                        "🔐 Enable 2FA on all important accounts: email, banking, and social media. Use authenticator apps like Google Authenticator or Microsoft Authenticator instead of SMS when possible.",
                        "💡 South African banks offer 2FA through their apps. Always enable this feature - it's your best protection against unauthorized access!"
                    }
                },
                {
                    "malware", new[]
                    {
                        "🦠 Malware includes viruses, ransomware, and spyware. Protect yourself by installing reputable antivirus software, keeping systems updated, and avoiding suspicious downloads!",
                        "⚠️ Never download software from untrusted sources. Use official app stores and websites. Be especially careful with .exe files from emails or pop-up ads.",
                        "💡 Use Windows Defender (built-in) which is excellent for most users. Run regular scans and keep real-time protection enabled."
                    }
                },
                {
                    "social media", new[]
                    {
                        "💬 Be careful what you share on social media! Cybercriminals use personal information for targeted attacks. Adjust privacy settings and think before posting!",
                        "🔒 Set your profiles to private, avoid posting your location in real-time, and never share your ID number, address, or phone number publicly.",
                        "⚠️ In South Africa, beware of fake profiles impersonating friends or celebrities. Verify friend requests before accepting!"
                    }
                },
                {
                    "wifi", new[]
                    {
                        "📶 Public Wi-Fi is convenient but risky! Avoid accessing banking or sensitive accounts on public networks. Use a VPN for encryption.",
                        "🔒 At home, secure your Wi-Fi with WPA3 or WPA2 encryption, change the default router password, and keep your router firmware updated.",
                        "⚠️ South African coffee shops and malls offer free Wi-Fi - use a VPN and never auto-connect to unknown networks!"
                    }
                },
                {
                    "ransomware", new[]
                    {
                        "💰 Ransomware locks your files and demands payment. Prevention is key: regular backups, avoid suspicious attachments, and keep software updated!",
                        "💡 Follow the 3-2-1 backup rule: Keep 3 copies of your data, on 2 different media types, with 1 copy off-site (cloud storage)."
                    }
                }
            };
        }

        public string GetResponse(string userInput, string userName)
        {
            userInput = userInput.ToLower();

            // Check for greetings
            if (Regex.IsMatch(userInput, @"\b(hello|hi|hey|howdy|greetings)\b"))
            {
                string[] greetings = {
                    $"Hello {userName}! Great to see you. How can I help you stay safe online today?",
                    $"Hi {userName}! Ready to learn about cybersecurity? Ask me anything!",
                    $"Hey {userName}! I'm here to help. What would you like to know about staying safe online?"
                };
                return greetings[_random.Next(greetings.Length)];
            }

            // Check for thank you
            if (userInput.Contains("thank") || userInput.Contains("thanks"))
            {
                string[] thanksResponses = {
                    $"You're welcome, {userName}! Stay safe out there!",
                    $"My pleasure, {userName}! Remember, cybersecurity is everyone's responsibility.",
                    $"Happy to help, {userName}! Feel free to ask more questions."
                };
                return thanksResponses[_random.Next(thanksResponses.Length)];
            }

            // Check for how are you
            if (userInput.Contains("how are you") || userInput.Contains("how's it going"))
            {
                return $"I'm fully operational and ready to help, {userName}! All systems secure. How can I assist you with cybersecurity today?";
            }

            // Check for purpose
            if (userInput.Contains("purpose") || userInput.Contains("what do you do") || userInput.Contains("who are you"))
            {
                return $"I'm CyberGuardSA, your personal cybersecurity awareness assistant. My purpose is to educate South African citizens about online threats and help them stay safe in the digital world. I cover topics like password safety, phishing detection, secure browsing, and much more!";
            }

            // Check for specific topics
            foreach (var kvp in _knowledgeBase)
            {
                if (userInput.Contains(kvp.Key))
                {
                    return kvp.Value[_random.Next(kvp.Value.Length)];
                }
            }

            // Default response for unrecognized input
            return GetDefaultResponse(userName);
        }

        private string GetDefaultResponse(string userName)
        {
            string[] defaultResponses = {
                $"I'm not sure about that, {userName}. Could you ask me about password safety, phishing, secure browsing, or two-factor authentication?",
                $"Interesting question, {userName}! I specialize in cybersecurity awareness. Try asking me: 'How do I create a strong password?' or 'What is phishing?'",
                $"Hmm, {userName}, I'm still learning about that topic. Why not ask me about South African cybersecurity concerns or how to protect yourself from online scams?",
                $"I'd love to help, {userName}! Can you rephrase your question? I'm best at answering questions about passwords, phishing, safe browsing, and digital security."
            };

            return defaultResponses[_random.Next(defaultResponses.Length)];
        }
    }
}
