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
                    LineBreak();
                    Challenge5();
                    break;
                case 6:
                    LineBreak();
                    Challenge6();
                    break;
            }
        }
        public static void LineBreak()
        {
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
            Console.Write("Array of words: ");
            for (int i = 0; i < array1.Length; i++)
            {
                Console.Write(array1[i]);
                if (i < array1.Length - 1)
                {
                    Console.Write(", ");
                }
            }
            Console.WriteLine();
            Console.Write("Same array with the duplicates removed: ");
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
            Console.WriteLine("Text: one zero one zero zero one");
            Console.Write("Text converted to binary: ");
            Console.Write(ConvertTextToBinary("one zero one zero zero one"));
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
            Console.Write("Enter a binary number: ");
            string input = Console.ReadLine();
            Console.WriteLine("{0} converted to a decimal number is: {1}", input, ConvertBinaryStringToDecimal(input));
        }
        public static int ConvertBinaryStringToDecimal(string s)
        {
            //1,2,4,8,16,32,64
            //2^index

            //reverse the string to make the loop simpler. can use Array.Reverse(array)
            //loop through each character in the string
            //for the first index, answer += 1 or 0 because 2^0 = 0
            //if the index is 1
            //add n^2 to the answer

            char[] chars = s.ToCharArray();
            Array.Reverse(chars);                                           //reverse the array to make the loop calculations easier to maange

            int answer = 0;

            for (int i = 0; i < chars.Length; i++)
            {
                if (chars[i] == '1')                                        //only need to count 1's
                {
                    if (i == 0)
                    {
                        answer += 1;                                        //if the first index is a 1, using the formula wont work because 2^0 equals 0
                    }
                    else
                    {
                        answer += (int)Math.Pow(2, i);                      //2^i gives the value of that index. just add that to the answer
                    }
                }
            }
            return answer;
        }
        //--------------------------------------CHALLENGE 5------------------------------------
        public static void Challenge5()
        {
            float[][] items =
            {
            new float[] { 4, 2, 7, 1 },
            new float[] { 20, 70, 40, 90 },
            new float[] { 1, 2, 0 }
            };

            float[][] items2 =
            {
            new float[] { -34, -54, -74 },
            new float[] { -2, -32, -65 },
            new float[] { -54, 7, -43}
            };

            float[][] items3 =
            {
            new float[] { 0.4321f, 0.7634f, 0.652f },
            new float[] { 1.324f, 9.32f, 2.5423f, 6.4314f },
            new float[] { 9, 3, 6, 3 }
            };

            Console.WriteLine("Jagged array: ");
            for (int i = 0; i < items.Length; i++)
            {
                for (int j = 0; j < items[i].Length; j++)
                {
                    Console.Write(items[i][j]);
                    if (j < items[i].Length - 1)
                    {
                        Console.Write(", ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.Write("The largest numbers from each array are: ");
            float[] largestNums = LargestIntFromArrays(items);

            for (int i = 0; i < largestNums.Length; i++)
            {
                Console.Write(largestNums[i]);
                if (i < largestNums.Length - 1)
                {
                    Console.Write(", ");
                }
            }
        }
        public static float[] LargestIntFromArrays(float[][] items)
        {
            //loop through the amount of arrays
            //loop through the current array
            //compare current index to the largest
            //once looped through current array, set index 0 of largest array to the found number

            float[] largestNumsArray = new float[items.Length];             //create a new array to store the largest numbers of each array

            for (int i = 0; i < items.Length; i++)                          //loop through each array
            {
                float largestNum = 0f;

                for (int j = 0; j < items[i].Length; j++)                   //loop through the current array
                {
                    if (j == 0)
                    {
                        largestNum = items[i][j];                           //set the largest num as the first index in case of negative numbers
                    }
                    else if (items[i][j] > largestNum)
                    {
                        largestNum = items[i][j];                           //if the array index is greater than the currrent largest number, set it as the new largest
                    }
                    largestNumsArray[i] = largestNum;                       //put the largest number in the largestNumsArray
                }
            }
            return largestNumsArray;
        }
        //--------------------------------------CHALLENGE 6------------------------------------
        public static void Challenge6()
        {
            // string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            // for (int i = 0; i < alphabet.Length; i++)
            // {
            //     int value = alphabet[i];
            //     Console.WriteLine(value);
            // }

            SameLetterPattern("ABAB", "CDCD");
            SameLetterPattern("ABCBA", "BCDCB");
            SameLetterPattern("FFGG", "ABAB");
            SameLetterPattern("ABCD", "FFFF");
            SameLetterPattern("ABCDCBA", "BCDEDCB");
            SameLetterPattern("ABCD", "EFGH");
        }
        public static bool SameLetterPattern(string first, string second)
        {
            //find the smallest code in the pattern
            //substract the smallest from each character in the pattern, store the result in a string.
            //e.g ABAB      A=4 B=5
            //loop through and find the smallest code.... which would be A
            //4-4=0, 5-4=1, 4-4=0, 5-4=1.    the pattern would be 0101
            //repeat for the other string, then compare the pattern numbers   

            string[] patterns = { first, second };
            string[] patternCodes = { "", "" };

            int lowestAsc = 0;

            for (int i = 0; i < patterns.Length; i++)
            {
                for (int j = 0; j < patterns[i].Length; j++)                //loops through all chars of each word. find the lowest acii value
                {
                    int ascValue = patterns[i][j];

                    if (j == 0)
                    {
                        lowestAsc = ascValue;                               //assign the first value as the lowest to begin with
                    }

                    if (ascValue < lowestAsc)
                    {
                        lowestAsc = ascValue;                               //set lowest when a new lowest is found
                    }
                }

                for (int j = 0; j < patterns[i].Length; j++)                //subtract the lowestAsc from all the string's ascii values to get the pattern code
                {
                    int value = patterns[i][j];

                    patternCodes[i] += value - lowestAsc;
                }
            }

            if (patternCodes[0] == patternCodes[1])                         //compare the pattern codees of the 2 strings
            {
                Console.WriteLine("{0}, {1}. Same pattern: True", patterns[0], patterns[1]);
                return true;
            }
            else
            {
                Console.WriteLine("{0}, {1}. Same pattern: False", patterns[0], patterns[1]);
                return false;
            }
        }
    }
}
