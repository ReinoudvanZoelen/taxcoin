using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using taxcoin.Helpers;

namespace taxcoin
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] ints = Datareader.ReadDataFromLocalFile("sampleInput.txt");

            foreach (int i in ints) { Console.WriteLine(i); }


            Console.WriteLine("Program complete. Press any key to exit.");
            Console.ReadKey();
        }
    }
}
