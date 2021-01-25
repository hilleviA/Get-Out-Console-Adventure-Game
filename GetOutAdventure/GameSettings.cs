using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using static System.Console; 

namespace GetOutAdventure
{
    public class GameSettings
    {

        //Instansiating classes
        private static Rooms.Basement basement = new Rooms.Basement();
        private static FoundObjects foundObjects = new FoundObjects();

        //The title of the game
        public void GameTitle()
        {
            ForegroundColor = ConsoleColor.DarkRed;

            WriteLine("");
            WriteLine("    ▄████ ▓█████▄▄▄█████▓    ▒█████   █    ██ ▄▄▄█████▓");
            WriteLine("   ██▒ ▀█▒▓█   ▀▓  ██▒ ▓▒   ▒██▒  ██▒ ██  ▓██▒▓  ██▒ ▓▒");
            WriteLine("  ▒██░▄▄▄░▒███  ▒ ▓██░ ▒░   ▒██░  ██▒▓██  ▒██░▒ ▓██░ ▒░");
            WriteLine("  ░▓█  ██▓▒▓█  ▄░ ▓██▓ ░    ▒██   ██░▓▓█  ░██░░ ▓██▓ ░ ");
            WriteLine("  ░▓█  ██▓▒▓█  ▄░ ▓██▓ ░    ▒██   ██░▓▓█  ░██░░ ▓██▓ ░ ");
            WriteLine("  ░▒▓███▀▒░▒████▒ ▒██▒ ░    ░ ████▓▒░▒▒█████▓   ▒██▒ ░ ");
            WriteLine("   ░▒   ▒ ░░ ▒░ ░ ▒ ░░      ░ ▒░▒░▒░ ░▒▓▒ ▒ ▒   ▒ ░░   ");
            WriteLine("    ░   ░  ░ ░  ░   ░         ░ ▒ ▒░ ░░▒░ ░ ░     ░    ");
            WriteLine("  ░ ░   ░    ░    ░         ░ ░ ░ ▒   ░░░ ░ ░   ░      ");
            WriteLine("");

        }

        //The Start menu
        public void StartMenu()
        {
            //Resets game by removing all objects in usedObjects.json and loading start menu
            foundObjects.ResetGame(); 
            ForegroundColor = ConsoleColor.White;
            WriteLine(" Welcome...what do you wanna do? \n");
            WriteLine(" 1) Start Game...if you dare");
            WriteLine(" 2) Read About The Game");
            WriteLine(" 3) Exit Game \n");

            //Looping thru the options and run the code that matches the input
            bool input = true;
            do
            {
                string menuChoice = ReadLine();

                switch (menuChoice)
                {
                    case "1":
                        StartGame(); 
                        break;
                    case "2":
                        AboutGame();
                        break;
                    case "3":
                        Environment.Exit(0);
                        break;
                    default:
                        ErrorMessage();
                        input = false;
                        break;
                }
            } while (input == false);
        }

        //About game option, gives you informtaion about the game and how you play
        public void AboutGame()
        {
            Clear();
            ForegroundColor = ConsoleColor.White;
            WriteLine("\n ABOUT GAME \n");
            WriteLine(" Your waking up in a dark place and have no idea were you are or how you got there.");
            WriteLine(" The lights are out and you can´t se anything.\n");
            WriteLine(" To continue the game after reading a text like this you just press 'ENTER', let's try!");
            ReadLine();
            WriteLine(" Perfect! \n");
            WriteLine(" To complete the game you need to find your way out by making decisions about what to do.");
            WriteLine(" There will always be a number of options to choose from and some will work better than others...");
            WriteLine(" Sometimes you may find stuff that will help you progress. They will be placed in your backpack until you use them.");
            WriteLine(" Then the only question left is: \n  ");
            ReadLine();
            WriteLine(" How do you GET OUT?\n");      
            WriteLine(" PRESS ENTER TO GET BACK TO MENU");
            ReadLine();
            Clear();
            GameTitle();
            StartMenu();
        }

        //Funktion to handle wrong inputs from start menu
        public void ErrorMessage()
        {
            //Writes out a random string from the messageOptions array
            Random rnd = new Random();
            string[] messageOptions = { "That was not a correct input, are you to scared to play or what? ", "That didn't work, press 2 to start the game?", "You're not a coward, are you? Try with option 2 instead..", "Did you do that on purpose? To scared to play? Press 2..." };
            int randomNumber = rnd.Next(0, 4);
            string errorMessage = messageOptions[randomNumber];
            WriteLine(errorMessage);
        }
        //Start game option - Presenting the game and then runs the SartGame() function to actually start the game
        public void StartGame()
        {
            Clear();
            GameTitle();
            ForegroundColor = ConsoleColor.White;

            WriteLine(" When you slowly opening  your eyes you realize you can´t se a thing but you must med laying on the floor..");
            WriteLine(" It's pitch black dark, your head hurts realy bad and your mouth is as dry as sahara dessert... \n");
            ReadLine();
            WriteLine(" You'r trying to remember what happend but it's all blurry...");
            WriteLine(" The only thing you actully remember is walking home late at night.");
            WriteLine(" Then it's all black... \n");
            ReadLine();
            WriteLine(" Your body is freezing cold and it hurts when your trying to sit up..");
            WriteLine(" But you really need to focus now...");
            WriteLine(" Where are you?");
            WriteLine(" How did you get here?");
            WriteLine(" And above all...how do you GET OUT?");
            ReadLine();

            basement.TheStart();

        }

        //Function that runs when you loose the game and then reloding startmenu
        public void GameOver()
        {
            Clear();
            ForegroundColor = ConsoleColor.DarkRed;

            WriteLine();
            WriteLine("   ▄████  ▄▄▄       ███▄ ▄███▓▓█████     ▒█████   ██▒   █▓▓█████  ██▀███  ");
            WriteLine("  ██▒ ▀█▒▒████▄    ▓██▒▀█▀ ██▒▓█   ▀    ▒██▒  ██▒▓██░   █▒▓█   ▀ ▓██ ▒ ██▒");
            WriteLine(" ▒██░▄▄▄░▒██  ▀█▄  ▓██    ▓██░▒███      ▒██░  ██▒ ▓██  █▒░▒███   ▓██ ░▄█ ▒");
            WriteLine(" ░▓█  ██▓░██▄▄▄▄██ ▒██    ▒██ ▒▓█  ▄    ▒██   ██░  ▒██ █░░▒▓█  ▄ ▒██▀▀█▄  ");
            WriteLine(" ░▒▓███▀▒ ▓█   ▓██▒▒██▒   ░██▒░▒████▒   ░ ████▓▒░   ▒▀█░  ░▒████▒░██▓ ▒██▒");
            WriteLine("  ░▒   ▒  ▒▒   ▓▒█░░ ▒░   ░  ░░░ ▒░ ░   ░ ▒░▒░▒░    ░ ▐░  ░░ ▒░ ░░ ▒▓ ░▒▓░");
            WriteLine("   ░   ░   ▒   ▒▒ ░░  ░      ░ ░ ░  ░     ░ ▒ ▒░    ░ ░░   ░ ░  ░  ░▒ ░ ▒░");
            WriteLine(" ░ ░   ░   ░   ▒   ░      ░      ░      ░ ░ ░ ▒       ░░     ░     ░░   ░ ");
            WriteLine("       ░       ░  ░       ░      ░  ░       ░ ░        ░     ░  ░   ░     ");

            ResetColor();
            WriteLine("\n That was probbably not the best decesion...");
            ReadLine();
            Clear();

            //Reloding startmenu
            GameTitle();
            StartMenu();
        }

        //Function that runs when you complete the game
        public void EndGame()
        {
            Clear();
            WriteLine("\n Great! You escaped from the basement. ");
            WriteLine(" Part 1 of GET OUT is completed");
            WriteLine(" TO BE CONTINUED...");
            ReadLine();
            Clear();

            //Reloading startmenu
            GameTitle();
            StartMenu();
        }
    }
}
