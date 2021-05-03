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
                    LineBreak();
                    Challenge4();
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
            string[] array1 = { "yes", "yes", "yes", "no", "no", "no", "maybe", "maybe", "maybe" };
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
            Console.WriteLine(ConvertTextToBinary("one one one one one one one one one one one one one one one one zero"));
        }
        public static string ConvertTextToBinary(string text)
        {
            string convertedString = "";
            string tempString = "";
            int previousSpace = 0;
            int currentSpace = 0;

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == ' ')
                {
                    currentSpace = i;                                           //get the index of the next space

                    for (int j = previousSpace; j < currentSpace; j++)          //for the previous space to the current space
                    {
                        tempString += text[j];                                  //add each character from the last space to the current space to a temp string
                    }

                    convertedString += CheckZeroOne(tempString);                //add '1' or '0' to the converted word
                    previousSpace = currentSpace + 1;                           //update the last space index. +1 because to move past the space index to the next character
                    tempString = "";                                            //reset the temp string
                }
                else if (i == text.Length - 1)
                {
                    for (int j = previousSpace; j < text.Length; j++)           //check from the last space to the end of the word because it wont find a space
                    {
                        tempString += text[j];
                    }

                    convertedString += CheckZeroOne(tempString);                //add '1' or '0' to the converted word
                    tempString = "";                                            //reset the temp string
                }
            }

            //make the string a multiple of 8
            if (convertedString.Length > 8)
            {
                if (convertedString.Length % 8 == 0)                            //string length is greater than 8 and also a multiple of 8, just return the string                        
                {
                    return convertedString;
                }
                else
                {
                    int length = 0;
                    for (int i = 1; i < convertedString.Length; i++)            //string is not a multiple of 8
                    {
                        if ((convertedString.Length - i) % 8 == 0)              //reduce string length until it is a multiple of 8
                        {
                            length = convertedString.Length - i;                //store the current length of the string
                            break;
                        }
                    }
                    
                    string shortenedString = "";
                    for (int i = 0; i < length; i++)                            //add each character from the string up to the length which is a multiple of 8
                    {
                        shortenedString += convertedString[i];
                    }

                    return shortenedString;
                }
            }
            else
            {
                return convertedString;
            }
        }
        public static string CheckZeroOne(string word)
        {
            //return '1' or '0' depending on the tempString provided
            if (word.ToUpper() == "ZERO")
            {
                return "0";
            }
            else if (word.ToUpper() == "ONE")
            {
                return "1";
            }
            else
            {
                return null;
            }
        }

        //--------------------------------------CHALLENGE 4------------------------------------
        public static void Challenge4()
        {
            Console.WriteLine(ConvertBinaryStringToDecimal("010101"));
        }
        public static int ConvertBinaryStringToDecimal(string s)
        {
            //010101
            //0,2,4,8,16,32
            //1+0+4+0+16
            //21

            //the first index is 1
            //the second index onwards is n^2 

            //reverse the string. can use Array.Reverse(array)
            //loop through each character in the string
            //for the first index, answer += 1 or 0 because 0^2 = 0
                //if the index is 1
                    //add n^2 to the answer
                //else
                    //dont add anything

            char[] chars = s.ToCharArray();
            Array.Reverse(chars);

            int answer = 0;

            for (int i = 0; i < chars.Length; i++)
            {
                if (i == 0)
                {
                    if (chars[i] == '1')
                    {
                        answer += 1;
                    }
                }
                else
                {
                    if (chars[i] == '1')
                    {
                        answer += (int)Math.Pow(i, 2);
                    }
                }
            }

            return answer;
        }
    }
}
