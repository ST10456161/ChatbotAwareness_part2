using System;
using System.Collections.Generic;
using System.IO;
using System.Media;
using System.Text;
using System.Threading;

namespace CyberSecurityChatbot
{
    internal class Program
    {
        static string userName = "Guest";
        static string userInterest = "";
        static readonly List<string> phishingTips = new List<string>
        {
            "Be cautious of emails asking for personal info.",
            "Check URLs for spelling errors — it might be a scam.",
            "Never click on suspicious links from unknown senders."
        };

        static void Main(string[] args)
        {
            TypeText("loading greeting audio..... ");
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "greetings.wav");

            PlayGreeting(filePath);
            DisplayAsciiArt();
            GreetUser();
            RespondToQuestions();
        }

        private static void PlayGreeting(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    using (SoundPlayer player = new SoundPlayer(filePath))
                    {
                        player.PlaySync();
                    }
                }
                else
                {
                    TypeText("Greeting sound file not found.\n");
                }
            }
            catch (Exception ex)
            {
                TypeText($"Error playing greeting sound: {ex.Message}\n");
            }
        }

        private static void DisplayAsciiArt()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(@"
   ____             _                          _               _   _             
  / ___| ___   ___ | |_ _ __ ___   __ _ _ __ | |__   __ _ _ __| |_| |_ ___ _ __ 
 | |  _ / _ \ / _ \| __| '_ ` _ \ / _` | '_ \| '_ \ / _` | '__| __| __/ _ \ '__|
 | |_| | (_) | (_) | |_| | | | | | (_| | | | | | | | (_| | |  | |_| ||  __/ |   
  \____|\___/ \___/ \__|_| |_| |_|\__,_|_| |_|_| |_|\__,_|_|   \__|\__\___|_|   
");
            Console.ResetColor();
        }

        private static void GreetUser()
        {
            TypeText("Welcome to the Cybersecurity Awareness Bot!\n");
            TypeText("What is your name? ");
            userName = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(userName))
            {
                userName = "Guest";
            }

            TypeText($"Hello, {userName}! I'm here to help you stay safe online.\n");
            Thread.Sleep(500);
            TypeText("What cybersecurity topic are you most interested in?\n");
            userInterest = Console.ReadLine()?.Trim().ToLower();
            Thread.Sleep(1000);
        }

        private static void RespondToQuestions()
        {
            while (true)
            {
                TypeText("\nWhat would you like to learn about? (Type 'exit' to quit)\n");
                string input = Console.ReadLine()?.Trim().ToLower();

                if (string.IsNullOrWhiteSpace(input))
                {
                    TypeText("I didn't quite understand that. Could you rephrase?\n");
                    continue;
                }

                if (input.Contains("exit"))
                {
                    TypeText("Goodbye! Stay safe online!\n");
                    return;
                }
                else if (input.Contains("how are you"))
                {
                    TypeText("I'm doing great, thank you for asking! How can I help you stay safe online?\n");
                }
                else if (input.Contains("purpose"))
                {
                    TypeText("My purpose is to help educate people like you about cybersecurity best practices.\n");
                }
                else if (input.Contains("password"))
                {
                    TypeText("Passwords should be strong, unique, and hard to guess. Avoid personal details.\n");
                }
                else if (input.Contains("scam") || input.Contains("phishing"))
                {
                    Random rnd = new Random();
                    int index = rnd.Next(phishingTips.Count);
                    TypeText(phishingTips[index] + "\n");
                }
                else if (input.Contains("safe browsing"))
                {
                    TypeText("Only visit trusted websites, avoid suspicious links, and keep your browser updated.\n");
                }
                else if (input.Contains("privacy"))
                {
                    TypeText("Protect your privacy by managing permissions and limiting what you share online.\n");
                }
                else if (input.Contains("recommend") && !string.IsNullOrEmpty(userInterest))
                {
                    TypeText($"Since you're interested in {userInterest}, make sure you review your settings and stay alert online.\n");
                }
                else if (input.Contains("worried"))
                {
                    TypeText("It's okay to feel worried. Let's go through some tips to help you stay safe.\n");
                }
                else if (input.Contains("curious"))
                {
                    TypeText("That's great! Cybersecurity is fascinating. What would you like to explore?\n");
                }
                else if (input.Contains("frustrated"))
                {
                    TypeText("Sorry to hear that. Maybe I can help clarify something for you.\n");
                }
                else
                {
                    TypeText("Hmm, I'm not sure I understand. Maybe try rewording your question?\n");
                }
            }
        }

        private static void TypeText(string text, int delay = 30)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(delay);
            }
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 96cf169bbe4eb2277f8e0b6d7379d58fa8baf532
