using System;
using System.Media;
using Figgle;

namespace CyberBotFinal
{
    class Program
    {
        static void Main(string[] args)
        {
            //play welcome greeting using the playSound method created 
            playSound("greeting.wav", false);

            //displays the logo using figgle fonts
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(FiggleFonts.Speed.Render("Cybersecurity Bot"));
            Console.ResetColor();
            Console.Write("---------------------------------------------------------------------------------------------------------------\n");

            //The above figgle font was found using chatGPT
            //OpenAI. 2025. ChatGPT(Version 4). [Large language model]. Available at: https://chatgpt.com/c/68050f30-2d30-8002-aadf-7aa1214305c0 [Accessed: 20 April 2025].

            //welcome greeting and instructions to the user 
            Console.WriteLine("Welcome to the Cybersecurity Bot! I'm here to help educate you on cybersecurity topics.");

            //asks the user for their name 
            Console.Write("I go by the name CBot, what's your name? ");
            string name = Console.ReadLine();
            Console.WriteLine($"Nice to meet you {name}!\nType out a question for me and click enter OR type 'exit' to leave.");
            Console.Write("---------------------------------------------------------------------------------------------------------------\n");

            //continually allows the user to type to the bot and validates that the user types something
            while (true)
            {
                //displays the users name for a more personalised user experience 
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write($"{name}: ");
                Console.ResetColor();

                string userInput = Console.ReadLine().ToLower().Trim();

                if (userInput == "")
                {
                    Console.Write("---------------------------------------------------------------------------------------------------------------\n");
                    Console.WriteLine("CBot: I noticed your response was blank. Please type out a question OR type 'exit' to leave.");
                    Console.Write("---------------------------------------------------------------------------------------------------------------\n");
                    continue;
                }

                //calls the method for the bot to respond to the users input
               // botResponse(userInput); adding method in the next commit

                if (userInput.Contains("exit"))
                    break;
            }
        }

        //method that contains a dictionary with responses to the user from the bot
        //also displays the repsonses and handles an error if the user input was invalid
        static void botResponse(string input)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            var responses = new Dictionary<List<string>, string>
            {
                { new List<string> {"how are you", "how you doing"},
                  "I'm doing well, I hope you are too!"},

                { new List<string> {"purpose", "what do you do"},
                  "I'm here to help spread awareness about cybersecurity by educating users. \nFeel free to ask me questions :)"},

                { new List<string> {"password", "password safety", "passwords"},
                  "It is important to have a strong password that has more than 8 characters, with lowercase, " +
                  "\nuppercase,numbers and symbols. Remember to avoid using the same password in multiple places."},

                { new List<string> {"phishing", "email phishing"},
                  "Phishing is an attack often carried out on emails.\n Beware of suspicious links from unknown senders."},

                { new List<string> {"safe browsing"},
                  "Install a firewall on your browser like McAFee. Look for 'https' in the link."},

                { new List<string> {"what can i ask", "what do you know"},
                  "Ask me about my purpose, passwords, phishing and safe browsing."},

                { new List<string> {"exit"},
                  "Goodbye!"}
            };

            bool foundMatch = false;

            //writes out the correct response to the user input according to the dictionary
            foreach (var entry in responses)
            {
                foreach (var keyword in entry.Key)
                {
                    if (input.Contains(keyword))
                    {
                        Console.Write("---------------------------------------------------------------------------------------------------------------\n");
                        Console.WriteLine($"CBot: {entry.Value}");
                        Console.Write("---------------------------------------------------------------------------------------------------------------\n");

                        //if the user types exit then play the goodbye audio file using playSound method
                        if (entry.Value.Contains("Goodbye"))
                        {
                            playSound("goodbye.wav", true);
                        }

                        foundMatch = true;
                        break;
                    }
                }

                if (foundMatch)
                    break;
            }

            //if there was NOT a response in the dictionary then the bot lets the user know 
            //and plays unknown input audio with playSound method
            if (!foundMatch)
            {
                Console.Write("---------------------------------------------------------------------------------------------------------------\n");
                Console.WriteLine("CBot: Sorry I could not understand that. Please try rephrasing your question.");
                Console.Write("---------------------------------------------------------------------------------------------------------------\n");
                playSound("unknownInput.wav", false);
            }

            Console.ResetColor();
        }


        //plays the sound of the wav file that is passed into the method
        static void playSound(string path, bool playSync) //playsync is used to allow the goodbye.wav sound to finish playing before exiting
            {
                try
                {
                    using (SoundPlayer player = new SoundPlayer(path))
                    {
                        player.Load();
                        if (playSync)
                            player.PlaySync();//waits until the sound finishes playing
                        else
                            player.Play();
                    }
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("---------------------------------------------------------------------------------------------------------------\n");
                    Console.WriteLine($"CBot: ERROR, could not play sound: {ex.Message}");
                    Console.Write("---------------------------------------------------------------------------------------------------------------\n");
                    Console.ResetColor();
                }
            }

            //The above use of playSync was aided by ChatGPT. Link to the chat provided below.
            //OpenAI. 2025. ChatGPT(Version 4). [Large language model]. Available at: https://chatgpt.com/c/68050ee0-2cd0-8002-8684-bae79e6d18f9[Accessed: 20 April 2025].

        

    }
}
