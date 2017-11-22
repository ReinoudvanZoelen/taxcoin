using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using taxcoin.Algorithm;
using taxcoin.Helpers;

namespace taxcoin
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] readFromFile = Datareader.ReadDataFromLocalFile("sampleInput.txt");

            int maximumValue = new DataAnalyzer(readFromFile).FindMaximalValue();

            Console.WriteLine("Maximum value: " + maximumValue);

            // Wait for readkey so the console application doesn't close itself
            Console.WriteLine("Program complete. Press any key to exit.");
            Console.ReadKey();
        }
    }
}
