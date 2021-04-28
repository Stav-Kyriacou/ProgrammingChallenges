using System;
using System.Collections.Generic;

namespace ProgrammingChallenges
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a task to run: ");
            int input = int.Parse(Console.ReadLine());

            switch (input)
            {
                case 1:
                    LineBreak();
                    Challenge1();
                    break;
                case 2:
                    LineBreak();
                    Challenge2();
                    break;
                case 3:
                    LineBreak();
                    Challenge3();
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 6:
                    break;
                case 7:
                    break;
                case 8:
                    break;
                case 9:
                    break;
                default:
                    break;
            }
        }

        public static void LineBreak()
        {
            Console.WriteLine();
            Console.WriteLine("------------------------------");
        }

        //--------------------------------------CHALLENGE 1------------------------------------
        public static void Challenge1()
        {
            Console.Write("Enter a word: ");
            string input = Console.ReadLine();

            Console.WriteLine("Your word in alternating caps is: {0}", AlternateCaps(input));
        }
        public static string AlternateCaps(string word)
        {
            List<string> wordInChars = new List<string>();
            string convertedWord = "";

            foreach (char letter in word)
            {
                wordInChars.Add(letter.ToString());
            }

            for (int i = 0; i < wordInChars.Count; i++)
            {
                if (i % 2 == 0)
                {
                    convertedWord += wordInChars[i].ToUpper();
                }
                else
                {
                    convertedWord += wordInChars[i].ToLower();
                }
            }
            return convertedWord;
        }

        //--------------------------------------CHALLENGE 2------------------------------------
        public static void Challenge2()
        {
            string[] array1 = { "yes", "yes", "no", "no", "maybe", "maybe" };
            RemoveDups(array1);
        }
        public static void RemoveDups(string[] items)
        {
            //create a temp array of the same size
            //add the first item from items to temp array
            //when adding the following items, check all items in the temp array
            //if it doesnt match with anything add it
            //loop through the temp array
            //everytime the item != null, add to counter
            //create a new array = to the counter size

            //add items from temp array to new array
            //return new array

            string[] tempItems = new string[items.Length];
            bool match = false;

            //writes each item into a temp array only if it doesnt already exist in the temp array
            for (int i = 0; i < items.Length; i++)
            {
                for (int j = 0; j < tempItems.Length; j++)
                {
                    if (tempItems[j] == items[i])
                    {
                        match = true;
                    }
                }
                if (!match)
                {
                    tempItems[i] = items[i];
                }
                match = false;
            }

            //counts what isnt null in the temp array, this will be the size of the final array
            int counter = 0;
            foreach (string item in tempItems)
            {
                if (item != null)
                {
                    counter++;
                }
            }

            //create the final array
            string[] noDupes = new string[counter];
            int counter2 = 0;

            //add the non null items into the final array
            //the counter represents the index where to place it in the array so it doesnt go out of bounds
            for (int i = 0; i < tempItems.Length; i++)
            {
                if (tempItems[i] != null)
                {
                    noDupes[counter2] = tempItems[i];
                    counter2++;
                }
            }

            //write the array with no duplicates to console
            for (int i = 0; i < noDupes.Length; i++)
            {
                Console.Write(noDupes[i]);
                if (i != noDupes.Length - 1)
                {
                    Console.Write(", ");
                }
            }
        }

        //--------------------------------------CHALLENGE 3------------------------------------
        public static void Challenge3()
        {
            Console.WriteLine(ConvertNumbers("one one"));
        }
        public static string ConvertNumbers(string text)
        {
            //"zero one zero one zero one zero one"

            //BUG: the last word doesnt get converted because it is looking for a space after the word
            //SOLUTION: instead of looking for a space, check if the word has been completed

            string convertedWord = "";
            string tempString = "";
            int lastSpaceIndex = 0;
            int currentSpaceIndex = 0;
    
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == ' ' || i == text.Length - 1)
                {
                    currentSpaceIndex = i;                                          //get the index a space

                    for (int j = lastSpaceIndex; j < currentSpaceIndex; j++)
                    {
                        tempString += text[j];                                      //add each character from the last space to the current space to a temp string
                    }

                    if (tempString.ToUpper() == "ZERO")                             //add a 0 or 1 to the converted word depending on the result of the temp string
                    {
                        convertedWord += "0";
                    }
                    else if (tempString.ToUpper() == "ONE")
                    {
                        convertedWord += "1";
                    }

                    lastSpaceIndex = currentSpaceIndex + 1;                         //update the last space index. +1 because to move past the space index to the next character

                    tempString = "";                                                //reset the temp string
                }
            }

            //get the length of the converted word

            return convertedWord;
        }
    }
}
