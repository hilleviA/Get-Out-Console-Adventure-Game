using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;
using System.IO;

namespace GetOutAdventure
{   
    //Class to handle all the found objects in the game 
    public class FoundObjects
    {
        //Creating properties with setters and getters to keep them private
        private string type;
        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        private string description;
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        private string workingArea;
        public string WorkingArea
        {
            get { return workingArea; }
            set { workingArea = value; }
        }

        //Open backpack
        public string OpenBackpack()
        {
            Clear();
            WriteLine(" \n What's in your backpack: \n");
            WriteLine("______________________________________________________________\n");

            //Saves the filepath and the content of the JSON-file
            string filePath = $"{AppDomain.CurrentDomain.BaseDirectory}\\FoundObjects.json";
            var json = File.ReadAllText(filePath);

            //Deserializing the JSON to an list of objects                               
            List<FoundObjects> foundObject = JsonConvert.DeserializeObject<List<FoundObjects>>(json);

            //Loopar thru the list of object and presenting them in the terminal window
            int option = 1;

            ForegroundColor = ConsoleColor.Yellow;
            foreach (var theObject in foundObject)
            {
                WriteLine($" {option}) Type: { theObject.Type} \n    Description: { theObject.Description}");
                WriteLine("\n");
                option++;
            }
            ForegroundColor = ConsoleColor.White;

            WriteLine("______________________________________________________________\n");
            ForegroundColor = ConsoleColor.DarkYellow;
            WriteLine($" {option}) Don't want to use any, Go Back \n");
            ForegroundColor = ConsoleColor.White;
            WriteLine("______________________________________________________________\n");

            WriteLine(" Do you want to use any item?\n");

            //Handeling the input and runs the option that matches input
            string inputOption = ReadLine();
            bool success = int.TryParse(inputOption, out int intOption);

            if (success && intOption < option)
            {
                //Looping thru list to se if input matches index and then returning "WorkingArea"
                int index = 1;
                string objectWorkingArea;

                foreach (var theObject in foundObject)
                {
                    if (intOption == index)
                    {
                        objectWorkingArea = theObject.WorkingArea;
                        return objectWorkingArea;
                    }
                    index++;
                }
                //Returning empty string if loop fails, to avoid errors. 
                return "";
            }
            //If index not matching return one of these
            else if (intOption == option)
            {
                return "back";
            }
            else
            { 
                return "Not correct input";
            }
        }

        //Adding a new object to backpack
        public bool AddObject(string type, string description, string area)
        {
            //Saved the filepath of JSON-file  to variable 
            string filePath = $"{AppDomain.CurrentDomain.BaseDirectory}\\FoundObjects.json";

            //If file exists: deserializing to list of objects, add the new item to list en serializing list back to JSON
            if (File.Exists(filePath))
            {
                var json = File.ReadAllText(filePath);                              
                List<FoundObjects> foundObject = JsonConvert.DeserializeObject<List<FoundObjects>>(json);
                foundObject.Add(new FoundObjects() { Type = type, Description = description, WorkingArea = area });
                json = JsonConvert.SerializeObject(foundObject, Formatting.Indented);

                if (json != null)
                {
                    File.WriteAllText(filePath, json);
                    return true;
                }
                else
                {
                    return false;
                }
            } else
            {
                return false;
            }   
        }

        //Looping thru the JSON-file of found objects to se if a object is in the list or not
        public bool CheckForObject(string type)
        { 
            string filePath = $"{AppDomain.CurrentDomain.BaseDirectory}\\FoundObjects.json";

            if (File.Exists(filePath))
            {
                var json = File.ReadAllText(filePath);
                List<FoundObjects> foundObject = JsonConvert.DeserializeObject<List<FoundObjects>>(json);

                foreach (var theObject in foundObject)
                {
                    if (type == theObject.Type)
                    {
                        return true;
                    }
                }
                return false;
            }
            else
            {
                return false;
            }
        }
        
        //Delete object from JSON-file
        public void DeleteObject(string type)
        {   
            //Opens and deserializing JSON file to list of objects
            string filePath = $"{AppDomain.CurrentDomain.BaseDirectory}\\FoundObjects.json";

            if (File.Exists(filePath))
            {
                var json = File.ReadAllText(filePath);                               
                List<FoundObjects> foundObjects = JsonConvert.DeserializeObject<List<FoundObjects>>(json);

                //Looping thru the list of objects and remove item if it matches "type"
                //Adding item to JSON-file "usedObjects" instead
                int index = 0;
                int removeIndex = 0;

                foreach (var theObject in foundObjects)
                {
                    if ( theObject.Type == type)
                    {   
                        AddUsedObject(theObject.Type, theObject.Description, theObject.workingArea);
                        removeIndex = index;
                    }
                    index++;
                }
                foundObjects.RemoveAt(removeIndex);

                //Serializing list back to JSON and saves file
                json = JsonConvert.SerializeObject(foundObjects, Formatting.Indented);
                File.WriteAllText(filePath, json);
                }
            else
            {
                WriteLine("ERROR: SOMEHTING WENT WRRONG.");
            }
        }
    
        //Adding object to JSON-file of used objects
        public void AddUsedObject(string type, string description, string area)
        {
            //Saved the filepath of JSON-file to variable 
            string filePath = $"{AppDomain.CurrentDomain.BaseDirectory}\\UsedObjects.json";

            //If file exists: deserializing to list of objects, add the new item to list en serializing list back to JSON
            if (File.Exists(filePath))
            {
                var json = File.ReadAllText(filePath);                            
                List<FoundObjects> foundObject = JsonConvert.DeserializeObject<List<FoundObjects>>(json);
                foundObject.Add(new FoundObjects() { Type = type, Description = description, WorkingArea = area });

                json = JsonConvert.SerializeObject(foundObject, Formatting.Indented);
                File.WriteAllText(filePath, json);
            }
            else
            {
                WriteLine("ERROR : Something went wrong");
            }
        }

        //Looping thru the JSON-file of "UsedObjects" to see if a object is in the list or not
        public bool CheckForUsedObject(string type)
        {
            string filePath = $"{AppDomain.CurrentDomain.BaseDirectory}\\UsedObjects.json";

            if (File.Exists(filePath))
            {
                var json = File.ReadAllText(filePath);
                List<FoundObjects> foundObject = JsonConvert.DeserializeObject<List<FoundObjects>>(json);

                foreach (var theObject in foundObject)
                {
                    if (type == theObject.Type)
                    {
                        return true;
                    }
                }
                return false;
            }
            else
            {
                return false;
            }
        }
    }    
}
