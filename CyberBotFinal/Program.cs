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
