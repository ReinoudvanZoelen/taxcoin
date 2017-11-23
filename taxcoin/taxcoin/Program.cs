using System;
using taxcoin.Helpers;

namespace taxcoin
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] datasets = new int[6][];

            datasets[0] = Datareader.ReadDataFromLocalFile("testInput1.txt");
            datasets[1] = Datareader.ReadDataFromLocalFile("sampleInput.txt");
            datasets[2] = Datareader.ReadDataFromLocalFile("submitInput.txt");
            datasets[3] = Datareader.ReadDataFromLocalFile("testInput2.txt");
            datasets[4] = Datareader.ReadDataFromLocalFile("submitInput.txt");
            datasets[5] = Datareader.ReadDataFromLocalFile("submitInputEdited.txt");

            int endBudget = new DataAnalyzer(datasets[5]).CalculateOptimalRevenue();

            Console.WriteLine("");
            Console.WriteLine("No new means of earning money have been found. Exiting algorithm with " + endBudget + " euros");

            // Wait for readkey so the console application doesn't close itself
            Console.WriteLine("Program complete. Press any key to exit.");
            Console.ReadKey();
        }
    }
}