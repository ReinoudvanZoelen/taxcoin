using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace taxcoin.Helpers
{
    public class Datareader
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filename">The path to the file you would like to read.</param>
        /// <returns></returns>
        public static int[] ReadDataFromLocalFile(string filename)
        {
            // Create an initial list of string to put read data in
            List<string> readLines = new List<string>();

            #region Take the root path from where the program runs at first, then keep trimming away until a file is found
            string path = Directory.GetCurrentDirectory();

            // Trim the path and go up a level if the file is not found
            // Starting path: C:\Users\Reino\Desktop\taxcoin\taxcoin\taxcoin\bin\Debug
            while (!File.Exists(path + @"\" + filename))
            {
                //Console.WriteLine("File path " + path + filename + " is not yet valid. Starting to trim.");

                int lastIndexOfBackslash = 0;

                for (int i = 0; i < path.Length; i++)
                {
                    if (path.Substring(i, 1) == @"\")
                    {
                        lastIndexOfBackslash = i;
                        //Console.WriteLine("Current operating path: " + path.Substring(0, lastIndexOfBackslash));
                    }
                }

                path = path.Substring(0, lastIndexOfBackslash);

                //Console.WriteLine("Path has been updated to " + path + @"\" + filename);
            }
            #endregion

            #region Read the lines and write them to readLines
            string fullpath = path + @"\" + filename;

            Console.WriteLine("A file has been found at " + path + @"\" + filename);

            using (StreamReader reader = new StreamReader(fullpath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    readLines.Add(line);
                }
            }
            #endregion

            #region Split the strings into int arrays
            // Split line 2 into individual values
            string[] splitSecondLineToString = readLines[1].Split(' ');

            // Set up int arrays for both lines
            int[] firstLineInteger = new int[1];
            int[] secondLineIntegers = new int[splitSecondLineToString.Length];

            // Add the first value of line 1 to the int array
            firstLineInteger[0] = Convert.ToInt32(readLines[0]);

            // Add all values of line 2 to the other int array
            for (int i = 0; i < splitSecondLineToString.Length; i++)
            {
                secondLineIntegers[i] = Convert.ToInt32(splitSecondLineToString[i]);
            }
            #endregion

            #region DEBUG: Write read values to the console
            /* 
            Console.WriteLine("First line integers: " + firstLineInteger[0]);
            for (int i = 0; i < secondLineIntegers.Length;i++)
            {
                Console.WriteLine("Second line integer: " + secondLineIntegers[i]);
            }
            */
            #endregion

            #region Merge the arrays
            int[] output = new int[firstLineInteger.Length + secondLineIntegers.Length];
            firstLineInteger.CopyTo(output, 0);
            secondLineIntegers.CopyTo(output, firstLineInteger.Length);
            #endregion

            return output;
        }
    }
}