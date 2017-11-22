using System;
using taxcoin.Helpers;

namespace taxcoin
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] datasets = new int[4][];

            datasets[0] = Datareader.ReadDataFromLocalFile("testInput1.txt");
            datasets[1] = Datareader.ReadDataFromLocalFile("sampleInput.txt");
            datasets[2] = Datareader.ReadDataFromLocalFile("submitInput.txt");
            datasets[3] = Datareader.ReadDataFromLocalFile("testInput2.txt");

            new DataAnalyzer(datasets[0]).FindMaximalValue();

            // Wait for readkey so the console application doesn't close itself
            Console.WriteLine("Program complete. Press any key to exit.");
            Console.ReadKey();
        }
    }
}