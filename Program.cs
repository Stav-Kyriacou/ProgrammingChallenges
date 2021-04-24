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

        public static void Challenge2()
        {
            string[] array1 = {"yes", "yes", "no", "no", "maybe", "maybe"};
            string[] array2 = RemoveDups(array1);

            foreach (string item in array2)
            {
                Console.Write(item);
                Console.Write(", ");
            }
        }
        public static string[] RemoveDups(string[] items)
        {
            //add the first item in the array to a list
            //when adding the next items, loop through the list and check if there are any matches, only add to the list if the matches = 0

            List<string> noDupes = new List<string>();
            int matchCount = 0;

            for (int i = 0; i < items.Length; i++)
            {
                for (int j = 0; j < noDupes.Count; i++)
                {
                    if (i == j)
                    {
                        matchCount++;
                    }
                }
                if (matchCount == 0)
                {
                    noDupes.Add(items[i]);
                }
            }

            string[] returnArray = new string[noDupes.Count];
            for(int i = 0; i < returnArray.Length; i++)
            {
                returnArray[i] = noDupes[i];
            }

            return returnArray;

        }


    }
}
