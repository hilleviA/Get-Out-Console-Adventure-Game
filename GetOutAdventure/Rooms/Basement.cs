using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace GetOutAdventure.Rooms
{
    class Basement     
    {
        //Instasiating classes
        private static GameSettings gameSettings = new GameSettings();
        private static FoundObjects foundObjects = new FoundObjects();
        private static Rooms.Bathroom bathroom = new Rooms.Bathroom();
        private static Rooms.Basement basement = new Rooms.Basement();
        
        //The beginning of the game
        public void TheStart()
        {
            //Menu with option to choose from
            Clear();
            WriteLine(" The room is pitch black dark and you really can't se a thing.");
            WriteLine(" What do you do? \n");
            WriteLine(" 1) Starting to stumble around in the room searching for a way out. ");
            WriteLine(" 2) Searching with your hands on the floor to se what's around you");
            WriteLine(" 3) Screaming for help \n");

            //Looping thru options comparing input value with cases
            bool input = true;
            do
            {
                string inputOption = ReadLine();

                switch (inputOption)
                {
                    case "1":
                        Clear();
                        WriteLine("\n You stand upp and slowly, with your arms reached out you're trying to walk across the room..");
                        ReadLine();
                        WriteLine(" Suddenly you hit the wall");
                        WriteLine(" And there, a button! Could it be the light switch? ");
                        WriteLine(" Do you want to push the button?\n");
                        WriteLine(" 1) Yes, push the button!");
                        WriteLine(" 2) No let it be dark\n");

                        //Looping thru options comparing if-statements
                        bool inputControl = true;
                        do
                        {
                            string lightOption = ReadLine();
                            if (lightOption == "1")
                            {
                                Clear();
                                WriteLine("\n Finally some light!");
                                WriteLine(" Even thouhg it's very weak the light gives you a pretty good view of the room.");
                                WriteLine(" And perfect! There's your backpack! Could be useful. ");
                                ReadLine();
                                BasementView();
                            }
                            else if (lightOption == "2")
                            {
                                Clear();
                                WriteLine("\n Once again, with your hands reached out you're stumbeling around in the dark..  ");
                                WriteLine(" You stumble on something on the floor and falls down on your knees again.. ");
                                ReadLine();
                                TheStart();
                            }
                            else
                            {
                                WriteLine(" That wont' help you..");
                                inputControl = false;
                            }
                        } while (inputControl == false); 
                        
                        break;
                    case "2":
                        Clear();
                        WriteLine("\n There's something wet on the floor.. no idea what it is..and there's something else...but it's to dark. ..");
                        ReadLine();
                        TheStart();
                        break;
                    case "3":
                        Clear();
                        WriteLine("\n Sudenly you're hearing footsteps from above you..is it help that's coming?");
                        WriteLine(" The footsteps are getting closer and it sounds like someones coming downstairs.");
                        ReadLine();
                        WriteLine(" The the door opens and the light hits the room");
                        WriteLine(" A dark silhouette in coming towards you...");
                        WriteLine(" First you feel a big releaf..then you se what's in the persons hand and a another scream is coming from you throut...");
                        ReadLine();
                        gameSettings.GameOver();
                        break;
                    default:
                        WriteLine(" That wont' help you..");
                        input = false;
                        break;
                }
            } while (input == false);
        }
        //Overview of the Basement 
        public void BasementView ()
        {
            Clear();
            WriteLine("\n It seems like the room you're in is a basement with two doors, a metallic one and a older one in wood.");
            WriteLine(" The only furniture is an old rusty bed and a desk.");
            WriteLine(" What do you wanna do?\n");
            WriteLine(" 1) Go to the metalic door");
            WriteLine(" 2) Go to the desk");
            WriteLine(" 3) Look closer at the floor");

            //Check if bathroomdoor is open or not to show matching menu
            if (!foundObjects.CheckForUsedObject("Key"))
            {
                WriteLine(" 4) Go to the second door");
            }
            else
            {
                WriteLine(" 4) Go to Bathroom"); //Go straight to bathroom instead
            }
            WriteLine(" 5) Check out the bed");
            WriteLine(" 6) Open BackPack\n");

            //Looping thru the menu until a valid option in entered and then loading a new function
            bool input = true;
            do
            {
                string menuChoice = ReadLine();
                switch (menuChoice)
                {
                    case "1":
                        BasementDoor();
                        break;
                    case "2":
                        Desk();
                        break;
                    case "3":
                        Floor();
                        break;
                    case "4":
                        //Depending on what menu is shown
                        if (!foundObjects.CheckForUsedObject("Key"))
                        {
                            BathroomDoor();
                        }
                        else
                        {
                            bathroom.BathroomStart();
                        }    
                        break;
                    case "5":
                        Bed();
                        break;
                    case "6":
                        //Opening Backpack and handeling response
                        string backpackResponse = foundObjects.OpenBackpack();
                        if (backpackResponse == "back")
                        {
                            BasementView();
                        }
                        else
                        {
                            WriteLine("\n Naahh...that didn't work");
                            ReadLine();
                            BasementView();
                        }
                        break;
                    default:
                        WriteLine("\n What are you trying to do? That's not a correct input Try again..");
                        input = false;
                        break;
                }
            } while (input == false);  
        }

        //Menu option Basement door
        public static void BasementDoor()
        {
            Clear();
            bool input = true;
            do
            {
                WriteLine("\n Hmm...a door. I wonder what's on the other side \n");
                WriteLine(" 1) Try do open it");
                WriteLine(" 2) Banging on the door with your fists, screaming for help! ");
                WriteLine(" 3) Go back");
                WriteLine(" 4) Open backpack\n");

                string inputOption = ReadLine();
                Clear();
                switch (inputOption)
                {
                    case "1":
                        WriteLine("\n Oh no....it's locked! Can't open it.");
                        ReadLine();
                        BasementDoor();
                        break;
                    case "2":
                        //Sending player to Game Over
                        WriteLine("\n What's that sound? Is someone coming?");
                        ReadLine();
                        WriteLine("\n Yes, you can hear footsteps getting closer and suddenly you hear the door open and someone is entering the room...");
                        WriteLine(" But it's not to help you...");
                        ReadLine();
                        gameSettings.GameOver();
                        break;
                    case "3":
                        basement.BasementView();
                        break;
                    case "4":
                        //Runs the open backpack functions and handling the response with if-statements
                        //If the correct object is choosen you move on in the game
                        string backpackResponse = foundObjects.OpenBackpack();

                        if (backpackResponse == "back")
                        {
                            BasementDoor();
                        }
                        else if (backpackResponse == "BasementDoor")
                        {
                            Clear();
                            WriteLine("\n Yeah, the door is now open, let´s se what's on the other side....");
                            ReadLine();
                            foundObjects.DeleteObject("Keycard");
                            gameSettings.EndGame();
                        }
                        else
                        {
                            Clear();
                            WriteLine("\n Naahh...that didn't work");
                            ReadLine();
                            BasementDoor();
                        }
                        break;
                    default:
                        WriteLine(" What are you trying to do?..Not a correct input");
                        ReadLine();
                        input = false;
                        break;
                }
            } while (input == false);

        }
        //Menu Option Desk 
        public static void Desk()
        {
            Clear();
            WriteLine("\n There are some things on the desk...a book, a box and some papers.. ");
            WriteLine(" What do you wanna do?\n");
            WriteLine(" 1) Look closer at the book");
            WriteLine(" 2) Look closer at the box");
            WriteLine(" 3) Look closer at the papers");
            WriteLine(" 4) Open the drawer");
            WriteLine(" 5) Go back");
            WriteLine(" 6) Open BackPack\n");

            bool input = true;
            do
            {
                string menuChoice = ReadLine();
                switch (menuChoice)
                {
                    case "1":
                        Book();
                        break;
                    case "2":
                        SafetyLocker();
                        break;
                    case "3":
                        Papers();
                        break;
                    case "4":
                        Clear();
                        //Checking for object in both the backpack and the usedObject-file
                        string type = "Light-bulb";
                        if (foundObjects.CheckForObject(type) || foundObjects.CheckForUsedObject(type))
                        {
                            WriteLine("\n The drawer is empty");
                            ReadLine();
                            Desk();
                        }
                        else
                        {   
                            //If not found the new object is saved to JSON-file
                            WriteLine("\n There's a light-bulb, could be useful! Let's put it in the backpack.");
                            ReadLine();
                            if(foundObjects.AddObject("Light-bulb", "Gives light when paired together with a lamp", "BathroomLamp"))
                            {
                                Desk();
                            }
                            else
                            {
                                //Handeling error
                                WriteLine(" Couldn't save item to backpack");
                                ReadLine();
                                Desk();
                            }
                        }
                        break;
                    case "5":
                        basement.BasementView();
                        break;
                    case "6":
                        //Opening Backpack and handeling response
                        string backpackResponse = foundObjects.OpenBackpack();
                        if (backpackResponse == "back")
                        {
                            basement.BasementView();
                        }
                        else
                        {
                            WriteLine("\n Naahh...that didn't work");
                            ReadLine();
                            basement.BasementView();
                        }
                        break;
                    default:
                        WriteLine("\n What are you trying to do? That's not a correct input Try again..");
                        input = false;
                        break;
                }
            } while (input == false);

        }

        //Menu Option Book
        public static void Book()
        {
            Clear();
            WriteLine("\n It's some kind of chemestri book...the bookmark shows a page on how to make deadly poison..");
            WriteLine(" What is this place and who is reading about this? Really need to get out of here... \n");
            WriteLine(" 1) Go back");
            WriteLine(" 2) Open backpack \n");

            bool input = true;
            do
            {
                string inputOptions = ReadLine();
                switch (inputOptions)
                {
                    case "1":
                        Desk();
                        break;
                    case "2":
                        string backpackResponse = foundObjects.OpenBackpack();

                        if (backpackResponse == "back")
                        {
                            Book();
                        }
                        else
                        {
                            Clear();
                            WriteLine("\n Naahh...that didn't work");
                            ReadLine();
                            Book();
                        }
                        break;
                    default:
                        WriteLine("\n What are you trying to do? That's not a correct input Try again..");
                        input = false;
                        break;
                }
            } while (input == false);
        }

        //Menu Option Papers
        public static void Papers()
        {
            Clear();
            WriteLine("\n These papers looks like patients journals...but they´re in a very bad shape...and is that blood on them?! \n ");
            WriteLine(" 1) Go back");
            WriteLine(" 2) Go Open backpack \n");

            bool input = true;
            do
            {
                string inputOptions = ReadLine();
                switch (inputOptions)
                {
                    case "1":
                        Desk();
                        break;
                    case "2":
                        string backpackResponse = foundObjects.OpenBackpack();

                        if (backpackResponse == "back")
                        {
                            Papers();
                        }
                        else
                        {
                            Clear();
                            WriteLine("\n Naahh...that didn't work");
                            ReadLine();
                            Papers();
                        }
                        break;
                    default:
                        WriteLine("\n What are you trying to do? That's not a correct input Try again..");
                        input = false;
                        break;
                }
            } while (input == false);
        }
        //Menu Option SafetyLocker
        public static void SafetyLocker()
        {
            Clear();
            WriteLine("\n Hmm...seems like there´s some kind of code lock with four numbers.\n");
            WriteLine(" 1) Enter code");
            WriteLine(" 2) Go back");
            WriteLine(" 3) Open backpack\n");

            bool input = true;
            do
            {
                string inputOptions = ReadLine();

                switch (inputOptions)
                {   
                    //When entering the right code the box opens and a keycard is fond
                    case "1":
                        Clear();
                        WriteLine(" \nEnter code:");
                        string type = "Keycard";
                        string codeInput = ReadLine();
                        if (codeInput == "7394")
                        {
                            if (foundObjects.CheckForObject(type))
                            {
                                WriteLine("\n The locker is empty");
                                ReadLine();
                                SafetyLocker();
                            }
                            else
                            {   
                                //Adding the new object to backpack
                                foundObjects.AddObject("Keycard", "Open doors", "BasementDoor");
                                WriteLine(" The code is correct! ");
                                WriteLine(" There's a keycard inside, could be useful! Let's put it in the backpack.");
                                ReadLine();
                                SafetyLocker();
                            }      
                        }
                        else
                        {
                            WriteLine(" That code was incorrect");
                            CursorVisible = false;
                            ReadLine();
                            SafetyLocker();
                        }
                        break;
                    case "2":
                        Desk();
                        break;
                    case "3":
                        string backpackResponse = foundObjects.OpenBackpack();

                        if (backpackResponse == "back")
                        {
                            SafetyLocker();
                        }
                        else
                        {
                            WriteLine("\n Naahh...that didn't work");
                            ReadLine();
                            SafetyLocker();
                        }
                        break;
                    default:
                        WriteLine("\n What are you trying to do? That's not a correct input Try again..");
                        input = false;
                        break;
                }
            } while (input == false);
        }
        //Menu Option Floor
        public static void Floor()
        {
            Clear();
            bool input = true;
            do
            {   //Depending on if key is found or not the options and text differ
                if(foundObjects.CheckForObject("Key") || foundObjects.CheckForUsedObject("Key"))
                {
                    WriteLine("\n There is still water on the floor but the plank is removed and there´s nothing else under it. \n ");
                }
                else
                {
                    WriteLine("\n There are a lot of water on the floor, seems like it's coming from the other side of that door..  ");
                    WriteLine(" And there's something strange about one of the floorboards. It sticks out more than the others..but seems to be screwed.\n ");
                }
                
                WriteLine(" 1) Go back");
                WriteLine(" 2) Open backpack \n");

                string inputOption = ReadLine();
                switch (inputOption)
                {
                    case "1": 
                        basement.BasementView();
                        break;
                    case "2":
                        string backpackResponse = foundObjects.OpenBackpack();

                        if (backpackResponse == "back")
                        {
                            Floor();
                        }
                        else if (backpackResponse == "BasementFloor")
                        {
                            Clear();
                            WriteLine("\n Yes, the screws can be loosened..");
                            ReadLine();
                            WriteLine(" There's a key laying under the plank, could be useful! Let's put it in the backpack.");
                            ReadLine();
                            //Adding new object to backpack and delete the used one, reloding Floor-function
                            if (foundObjects.AddObject("Key", "And old key to some kind of door", "BathroomDoor"))
                            {
                                foundObjects.DeleteObject("Screwdriver");
                                Floor();
                            }
                            else
                            {
                                //Handeling Error
                                WriteLine(" Couldn't save item to backpack.");
                            }
                        }
                        else
                        {
                            Clear();
                            WriteLine("\n Naahh...that didn't work");
                            ReadLine();
                            Floor();
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
        //Menu Option Second door
        public static void BathroomDoor()
        {
            Clear();
            bool input = true;
            do
            {
                WriteLine("\n Hmm...could it be a bathroom on the other side? There's a lot of water coming from under the door. \n");
                WriteLine(" 1) Try to open it");
                WriteLine(" 2) Go back");
                WriteLine(" 3) Open backpack\n");

                string inputOption = ReadLine();
                Clear();

                switch (inputOption)
                {
                    case "1":
                        
                        WriteLine("\n Damn! It's locked!");
                        ReadLine();
                        BathroomDoor();
                        break;
                    case "2":
                        Clear();
                        basement.BasementView();
                        break;
                    case "3":
                        //Opens the bathroom door if key is used
                        string backpackResponse = foundObjects.OpenBackpack();

                        if (backpackResponse == "back")
                        {
                            BathroomDoor();
                        }
                        else if (backpackResponse == "BathroomDoor")
                        {
                            Clear(); 
                            WriteLine("\n It works! The door is now open..what's on the other side? Seems pretty dark..");
                            ReadLine();
                            foundObjects.DeleteObject("Key");
                            bathroom.BathroomStart();
                        }
                        else
                        {
                            WriteLine("\n Naahh...that didn't work");
                            ReadLine();
                            BathroomDoor();
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
        //Menu Option Bed
        public static void Bed()
        {
            Clear();
            WriteLine("\n The bed is full of rust, the mattress is dirty and the sheets looks like they haven't been washed for a very long time.");
            WriteLine(" No one could have slept here for year...or could they? \n ");
            WriteLine(" 1) Look under the mattress");
            WriteLine(" 2) Look under the bed");
            WriteLine(" 3) Shake the pillow");
            WriteLine(" 4) Go back");
            WriteLine(" 5) Open Backpack \n");

            bool input = true;
            do
            {
                string menuChoice = ReadLine();
                Clear();
                switch (menuChoice)
                {
                    case "1":
                        WriteLine("\n It's really dirty but can't se anything intresting...");
                        ReadLine();
                        Bed();
                        break;
                    case "2":
                        WriteLine("\n There's nothing under the bed..");
                        ReadLine();
                        Bed();
                        break;
                    case "3":
                        //Checking for screwdriver and showing diffrent text
                        string type = "Screwdriver";
                        if (foundObjects.CheckForObject(type) || foundObjects.CheckForUsedObject(type))
                        {
                            Write("\n You shake the pillow, but apart from a lot of dust swirling up your nose, nothing happens.");
                            ReadLine();
                            Bed();
                        }
                        else
                        {
                            WriteLine("\n A lot of dust are coming from the pillow, but there's something else to! ");
                            ReadLine();
                            WriteLine("\n A screwdriver falls out of the pillowcase. Could be useful! Let's put it in the backpack.");
                            ReadLine();
                            if (foundObjects.AddObject("Screwdriver", "Use to remove screws", "BasementFloor"))
                            {
                                Bed();  
                            }
                            else
                            {
                                WriteLine(" Couldn't save object to Backpaack.");
                            }    
                        }
                        break;
                    case "4":
                        basement.BasementView();
                        break;
                    case "5":
                        string backpackResponse = foundObjects.OpenBackpack();
                        if (backpackResponse == "back")
                        {
                            Bed();
                        }
                        else
                        {
                            WriteLine("\n Naahh...that didn't work");
                            ReadLine();
                            Bed();
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
