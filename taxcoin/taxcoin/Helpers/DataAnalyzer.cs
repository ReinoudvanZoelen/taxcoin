using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace taxcoin.Algorithm
{
    public class DataAnalyzer
    {
        private int budget;
        private int taxcoin;
        private int[] exchangeRate;

        public DataAnalyzer(int[] values)
        {
            #region Split read values to budget and exchangeRate
            budget = values[0];

            exchangeRate = new int[values.Length - 1];

            Console.WriteLine("Starting budget: " + budget);

            for (int i = 0; i < values.Length - 1; i++)
            {
                exchangeRate[i] = values[i + 1];
                Console.WriteLine("Value: " + exchangeRate[i]);
            }
            Console.WriteLine("");
            #endregion
        }

        public int FindMaximalValue()
        {
            int foundIndex = this.FindIndexOfNextHighestEntry();

            // Run this as long as there are entries where the entry after it is lower
            while (foundIndex != -1)
            {
                #region create a set of integers starting at index 0 and ending at the foundIndex
                // New int array which we will be working with
                int[] subset = new int[foundIndex + 1];

                Console.WriteLine("Creating a subset. Size: " + subset.Length);

                for (int i = 0; i <= foundIndex; i++)
                {
                    Console.WriteLine("Adding index " + i + " value " + exchangeRate[i] + " to subset.");
                    subset[i] = exchangeRate[i];
                }
                #endregion

                #region Divide our budget with the lowest and multiply with the highest
                Console.WriteLine("");
                int lowest = int.MaxValue;

                // Run though all entries except the last one (Length - 1) and see if it is the lowest
                // We know the last one is the highest and any number before that can be used to buy
                for (int i = 0; i < subset.Length - 1; i++)
                {
                    if (subset[i] < lowest)
                    {
                        Console.WriteLine(subset[i] + " is lower than " + lowest);
                        lowest = subset[i];
                    }
                }

                // Calculate new budget
                Console.WriteLine("Calculating new budget. Starting budget: " + budget);
                Console.WriteLine("Lowest value: " + lowest + ", highest value: " + subset[subset.Length - 1]);

                // Divide, purchase at the lowest prince, converting budget to taxcoin
                double tempTaxcoin = (double)budget / (double)lowest;
                taxcoin = (int)tempTaxcoin;
                Console.WriteLine("Purchased taxcoin at the lowest price. Budget(" + budget + ") divided by " + lowest + " and we now have " + taxcoin + " taxcoin.");
                budget = 0;

                // Multiply, sell at the highest price, converting taxcoin to budget
                budget = taxcoin * subset[subset.Length - 1];
                Console.WriteLine("Sold taxcoin at the highest price. Taxcoin(" + taxcoin + ") Multiplied by " + subset[subset.Length - 1] + " and we now have " + budget + " moneys");
                taxcoin = 0;
                #endregion

                #region Create a new array the size of the diffrence between our subset and the home list
                Console.WriteLine("");
                Console.WriteLine("Starting migration of arrays. Starting size: " + this.exchangeRate.Length);

                int[] newExchangeRate = new int[exchangeRate.Length - subset.Length];

                Console.WriteLine("Subset contained " + (foundIndex + 1) + " entries. They will be removed.");
                Console.WriteLine("newExchangeRate created at size " + (exchangeRate.Length - subset.Length));

                Console.WriteLine("Starting at index " + foundIndex + " we will be moving " + (exchangeRate.Length - subset.Length) + " items to newExchangeRate");
                #endregion

                #region Transfer items from the old to the new array
                Console.WriteLine("");
                int counter = 0;
                for (int i = foundIndex + 1; i < exchangeRate.Length; i++)
                {
                    Console.WriteLine("Pushing entry " + i + " value " + exchangeRate[i] + " from exchangeRate to entry " + counter + " of newExchangeRate");
                    newExchangeRate[counter] = exchangeRate[i];
                    counter++;
                }

                this.exchangeRate = newExchangeRate;

                Console.WriteLine("Finishing migration of arrays. Ending size: " + this.exchangeRate.Length);

                foundIndex = this.FindIndexOfNextHighestEntry();
                #endregion
            }

            Console.WriteLine("");
            Console.WriteLine("No new means of earning money have been found. Exiting algorithm with value " + budget);
            Console.WriteLine("");
            return budget;
        }

        /// <summary>
        /// Find an entry where the next entry is lower than the current one and return the index of the current entry.
        /// </summary>
        /// <returns>Returns the index of the next entry where the entry after it is lower. 
        /// If there isnt another entry where the next one is lower, return -1.</returns>
        private int FindIndexOfNextHighestEntry()
        {
            int foundIndex = -1;

            Console.WriteLine("Start search for the next index...");

            // Loop through all entries in exchangeRates
            for (int i = 0; i <= exchangeRate.Length - 1; i++)
            {
                Console.WriteLine("Starting loop at index " + i + " value: " + exchangeRate[i]);
                // If we're the last entry OR if the next entry is lower than the current one
                if (i == exchangeRate.Length - 1 || exchangeRate[i + 1] < exchangeRate[i])
                {
                    Console.WriteLine("Checking entry " + i + " value: " + exchangeRate[i]);
                    // Check if any of the previous entries are lower than the current one
                    for (int j = i - 1; j >= 0; j--)
                    {
                        Console.WriteLine("Comparing previous entry " + j + " value: " + exchangeRate[j] + " to " + i + " value: " + exchangeRate[i]);
                        if (exchangeRate[j] < exchangeRate[i])
                        {
                            if (foundIndex == -1)
                            {
                                Console.WriteLine("Found that an entry before index " + i + " value: " + exchangeRate[i] + " is lower, namely index " + j + " value: " + exchangeRate[j]);
                                foundIndex = i;
                            }
                            else if(exchangeRate[j] > exchangeRate[foundIndex])
                            {
                                foundIndex = i;
                            }
                        }

                    }
                }

            }

            Console.WriteLine("Index: " + foundIndex);

            return foundIndex;
        }
    }

}