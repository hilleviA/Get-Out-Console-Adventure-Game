using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace GetOutAdventure.Rooms
{
    class Bathroom
    {
        private static Rooms.Basement basement = new Rooms.Basement();
        private static FoundObjects foundObjects = new FoundObjects();
        private static GameSettings gameSettings = new GameSettings();
        private static Bathroom bathroom = new Bathroom();

        //Bathroom Option
        public void BathroomStart()
        {
            Clear();
            //If light-bulb is not used continue this function, else go stright to BathroomView()
            if (!foundObjects.CheckForUsedObject("Light-bulb"))
            {
                WriteLine("\n The room is very dark but the light coming from the other room helps you a little bit. ");
                WriteLine(" It's most likely a bathroom and you can feel there's a lot of water on the floor. ");
                WriteLine(" It sounds like there's water flushing somewhere..but it's to dark to se \n ");

                WriteLine(" 1) Go inside.");
                WriteLine(" 2) Check the ceiling.");
                WriteLine(" 3) Look at the floor.");
                WriteLine(" 4) Go back to Basement \n");

                //Looping thru the menu until a valid option in entered and then loading a new function
                bool input = true;
                do
                {
                    string menuChoice = ReadLine();
                    switch (menuChoice)
                    {
                        case "1":
                            Clear();
                            WriteLine("\n Nahh...it's to dark and to much water...");
                            ReadLine();
                            BathroomStart();
                            break;
                        case "2":
                            Ceiling();
                            break;
                        case "3":
                            Clear();
                            WriteLine("\n Hmm..something is laying on the floor..what is it? It's to dark..");
                            ReadLine();
                            BathroomStart();
                            break;
                        case "4":
                            basement.BasementView();
                            break;
                        default:
                            WriteLine("\n What are you trying to do? That's not a correct input Try again..");
                            input = false;
                            break;
                    }
                } while (input == false);
            }
            else
            {
                BathroomView();
            }
        }

        //Ceiling Option
        public static void Ceiling()
        {
            Clear();
            WriteLine("\n You can see the silhouette of a lamp but it doesn't seems to work. Maybe there's something missing. \n ");
            WriteLine(" 1) Go back");
            WriteLine(" 2) Open backpack \n");

            //Looping thru the menu until a valid option in entered and then loading a new function
            bool input = true;
            do
            {  
                string menuChoice = ReadLine();
                switch (menuChoice)
                {
                    case "1":
                        bathroom.BathroomStart();
                        break;
                    case "2":
                        //If backbackresponse is matching string: Delete object and move on to BathroomView()
                        string backpackResponse = foundObjects.OpenBackpack();

                        if (backpackResponse == "back")
                        {
                            Ceiling();
                        }
                        else if (backpackResponse == "BathroomLamp")
                        {
                            Clear();
                            WriteLine("\n Yes, finally som light! Now you can se what's in the room.");
                            ReadLine();
                            foundObjects.DeleteObject("Light-bulb");
                            BathroomView();
                        }
                        else
                        {
                            WriteLine("\n Naahh...that didn't work");
                            ReadLine();
                            Ceiling();
                        }
                        break;
                    default:
                        WriteLine("\n What are you trying to do? That's not a correct input Try again..");
                        input = false;
                        break;
                }
            } while (input == false);
        }

        //Menu Option Bathroom
        public static void BathroomView()
        {
            Clear();
            WriteLine("\n In the light you can have a better look at the bathroom. ");
            WriteLine("\n It's water all over the floor and it seems like it's the tap in the sink that is flushing water. ");
            WriteLine(" ");
            WriteLine(" What do you wanna do?\n");
            WriteLine(" 1) Go to the sink");
            WriteLine(" 2) Check the lamp");
            WriteLine(" 3) Go inside to look at the wall");
            WriteLine(" 4) Look at the floor");
            WriteLine(" 5) Go back to Basement");
            WriteLine(" 6) Open Backpack\n");


            //Looping thru the menu until a valid option in entered and then loading a new function
            bool input = true;
            do
            {
                string menuChoice = ReadLine();
                switch (menuChoice)
                {
                    case "1":
                        Sink();
                        break;
                    case "2":
                        Clear();
                        WriteLine("\n The lamp gives a good light now.");
                        ReadLine();
                        BathroomView();
                        break;
                    case "3":
                        Clear();
                        //Showing diffrent options depending on if wrench is used or not
                        if (!foundObjects.CheckForUsedObject("Wrench"))
                        {
                            WriteLine("\n There is to much water on the floor, need to get rid of that before looking at the wall..");
                            ReadLine();
                            BathroomView();
                        }
                        else
                        {
                            WriteLine("\n Now when the water is gone you can go inside to get a closer look.");
                            WriteLine(" There's something written on the wall in a strange red color..");
                            WriteLine(" It's some numbers..7394..");
                            WriteLine(" The red color...is it..blood?");
                            WriteLine(" Omg...What has happend here?");
                            ReadLine();
                            BathroomView();
                        }    
                        break;
                    case "4":
                        Clear();
                        //Showing diffrent options depedning on if wrench is used or not
                        if(!foundObjects.CheckForUsedObject("Wrench"))
                        {
                            WriteLine("\n The water is all over the floor...");
                            WriteLine(" When you look down you se a wrench laying beside your feets. Could be useful! It goes in the backpack. ");
                            ReadLine();
                            if(foundObjects.AddObject("Wrench", "A useful tool", "Sink"))
                            {
                                BathroomView();
                            }
                            else
                            {
                                WriteLine("Couldn't save item to backpack.");
                                ReadLine();
                                BathroomView();
                            }   
                        }
                        else
                        {
                            WriteLine("\n The water is finnaly gone...there's nothing else on the floor.");
                            ReadLine();
                            BathroomView();
                        } 
                        break;
                    case "5":
                        basement.BasementView();
                        break;
                    case "6":
                        string backpackResponse = foundObjects.OpenBackpack();

                        if (backpackResponse == "back")
                        {
                            BathroomView();
                        }
                        else
                        {
                            Clear();
                            WriteLine("\n Naahh...that didn't work");
                            ReadLine();
                            BathroomView();
                        }
                        break;
                    default:
                        WriteLine("\n What are you trying to do? That's not a correct input Try again..");
                        input = false;
                        break;
                }
            } while (input == false);
            
        }
        //Menu Option Sink
        public static void Sink()
        {
            Clear();
            //Depending on if Wrench is used or not showing diffrent menu options and texts
            if(foundObjects.CheckForUsedObject("Wrench"))
            {
                WriteLine("\n The sink looks pretty nasty now when the water is gone...");
            }
            else
            {
                WriteLine("\n No wonder there's water on the floor. The tap is on and flushing out water!");
            }
            
            bool input = true;
            do
            {
                if (foundObjects.CheckForUsedObject("Wrench"))
                {
                    WriteLine(" 1) Look closer at the tap");
                }
                else
                {
                    WriteLine(" 1) Turn of the water");
                }       
                WriteLine(" 2) Look closer at the glass.");
                WriteLine(" 3) Go back ");
                WriteLine(" 4) Open backpack\n");

                string inputOption = ReadLine();

                switch (inputOption)
                {
                    case "1":
                        Clear();
                        if (foundObjects.CheckForUsedObject("Wrench"))
                        {
                            WriteLine("\n The tap looks okay now." );
                            ReadLine();
                            Sink();
                        }
                        else
                        {
                            WriteLine("\n The tap seems broken, can't turn it off like that. ");
                            ReadLine();
                            Sink();
                        }    
                        ReadLine();
                        Sink();   
                        break;
                    case "2":
                        WaterGlass();
                        break;
                    case "3":
                        BathroomView();
                        break;
                    case "4":
                        string backpackResponse = foundObjects.OpenBackpack();

                        if (backpackResponse == "back")
                        {
                            Sink();
                        }
                        else if (backpackResponse == "Sink")
                        {
                            Clear();
                            WriteLine("\n That seems to work, the tap is now turned of.");
                            ReadLine();
                            foundObjects.DeleteObject("Wrench");
                            Sink();
                        }
                        else
                        {
                            WriteLine("\n Naahh...that didn't work");
                            ReadLine();
                            Sink();
                        }
                        break;
                    default:
                        WriteLine(" What are you trying to do?..Not a correct input");
                        ReadLine();
                        Clear();
                        input = false;
                        break;
                }
            } while (input == false);
        }

        //Menu option Water glass
        public static void WaterGlass()
        {
            Clear();
            WriteLine("\n You're looking at the glass and realizing how thirsty you are... ");
            WriteLine(" Should you drink it?  \n");
            WriteLine(" 1) Drink the water");
            WriteLine(" 2) Go back");
            WriteLine(" 3) Open backpack \n");

            bool input = true;
            do
            {
                string inputOptions = ReadLine();
                switch (inputOptions)
                {
                    case "1":
                        Clear();
                        WriteLine("\n You bring the glass to your mouth and when the water flows down your throat it feels like heaven.");
                        ReadLine();
                        WriteLine(" But suddenly...it feels like something is burning in your throut!");
                        WriteLine(" Your head is dizzy and you realize it probably wasn't just water in the glass..");
                        WriteLine(" You're trying to take some deep breaths but it's impossible and you falling down on the floor ");
                        WriteLine(" Then it's all black");
                        ReadLine();
                        gameSettings.GameOver();
                        break;
                    case "2":
                        Sink();
                        break;
                    case "3":
                        string backpackResponse = foundObjects.OpenBackpack();
                        if (backpackResponse == "back")
                        {
                            Sink();
                        }
                        else
                        {
                            Clear();
                            WriteLine("\n Naahh...that didn't work");
                            ReadLine();
                            Sink();
                        }
                        break;
                    default:
                        WriteLine("\n What are you trying to do? That's not a correct input Try again..");
                        input = false;
                        break;
                }
            } while (input == false);
        }
    }
}
