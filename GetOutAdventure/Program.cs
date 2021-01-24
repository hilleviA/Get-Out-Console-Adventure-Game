using System;
using static System.Console;

namespace GetOutAdventure
{
    class Program
    {
        //Instansiating classes
        private static GameSettings gameSettings = new GameSettings();
        private static Rooms.Basement basement = new Rooms.Basement();

        //Runs the functions to display the GameTitle and StartMenu
        static void Main(string[] args)
        {
            gameSettings.GameTitle();
            gameSettings.StartMenu();
        } 
    }
}
