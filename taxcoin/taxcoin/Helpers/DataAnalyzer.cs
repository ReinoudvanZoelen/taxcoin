using System;

namespace taxcoin.Helpers
{
    public class DataAnalyzer
    {
        private int _budget;
        private int _taxcoin;
        private int[] _exchangeRate;

        public DataAnalyzer(int[] values)
        {
            #region Split read values to budget and exchangeRate
            Console.WriteLine("");
            Console.WriteLine(" ### Starting data analysis.");
            _budget = values[0];

            _exchangeRate = new int[values.Length - 1];

            Console.WriteLine("Starting budget: " + _budget);

            for (int i = 0; i < values.Length - 1; i++)
            {
                _exchangeRate[i] = values[i + 1];
                Console.WriteLine("Starting value: " + _exchangeRate[i]);
            }
            #endregion
        }

        public int FindMaximalValue()
        {
            int foundIndex = FindEndIndexOfNextSubset();

            // Run this as long as there are entries where the entry after it is lower
            while (foundIndex != -1)
            {
                #region create a set of integers starting at index 0 and ending at the foundIndex
                // New int array which we will be working with
                int[] subset = new int[foundIndex + 1];

                Console.WriteLine("Creating a subset. Size: " + subset.Length);

                for (int i = 0; i <= foundIndex; i++)
                {
                    Console.WriteLine("Adding index " + i + " value " + _exchangeRate[i] + " to subset.");
                    subset[i] = _exchangeRate[i];
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
                Console.WriteLine("Calculating new budget. Starting budget: " + _budget);
                Console.WriteLine("Lowest value: " + lowest + ", highest value: " + subset[subset.Length - 1]);

                // Divide, purchase at the lowest prince, converting budget to taxcoin
                double tempTaxcoin = (double)_budget / (double)lowest;
                _taxcoin = (int)tempTaxcoin;
                Console.WriteLine("Purchased taxcoin at the lowest price. Budget(" + _budget + ") divided by " + lowest + " and we now have " + _taxcoin + " taxcoin.");
                _budget = 0;

                // Multiply, sell at the highest price, converting taxcoin to budget
                _budget = _taxcoin * subset[subset.Length - 1];
                Console.WriteLine("Sold taxcoin at the highest price. Taxcoin(" + _taxcoin + ") Multiplied by " + subset[subset.Length - 1] + " and we now have " + _budget + " euros");
                _taxcoin = 0;
                #endregion

                #region Create a new array the size of the diffrence between our subset and the home list
                Console.WriteLine("");
                Console.WriteLine("Starting migration of arrays. Starting size: " + _exchangeRate.Length);

                int[] newExchangeRate = new int[_exchangeRate.Length - subset.Length];

                Console.WriteLine("Subset contained " + (foundIndex + 1) + " entries. They will be removed.");
                Console.WriteLine("newExchangeRate created at size " + (_exchangeRate.Length - subset.Length));

                Console.WriteLine("Starting at index " + foundIndex + " we will be moving " + (_exchangeRate.Length - subset.Length) + " items to newExchangeRate");
                #endregion

                #region Transfer items from the old to the new array
                Console.WriteLine("");
                int counter = 0;
                for (int i = foundIndex + 1; i < _exchangeRate.Length; i++)
                {
                    Console.WriteLine("Pushing entry " + i + " value " + _exchangeRate[i] + " from exchangeRate to entry " + counter + " of newExchangeRate");
                    newExchangeRate[counter] = _exchangeRate[i];
                    counter++;
                }

                _exchangeRate = newExchangeRate;

                Console.WriteLine("Finishing migration of arrays. Ending size: " + _exchangeRate.Length);

                foundIndex = FindEndIndexOfNextSubset();
                #endregion
            }

            Console.WriteLine("");
            Console.WriteLine("No new means of earning money have been found. Exiting algorithm with " + _budget + " euros");
            Console.WriteLine("");
            return _budget;
        }

        /// <summary>
        /// Find an entry where the next entry is lower than the current one and return the index of the current entry.
        /// </summary>
        /// <returns>Returns the index of the next entry where the entry after it is lower. 
        /// If there isnt another entry where the next one is lower, return -1.</returns>
        private int FindEndIndexOfNextSubset()
        {
            int foundIndex = -1;

            Console.WriteLine("");
            Console.WriteLine(" @@@ Started search for the end of the next subset.");

            // Loop through all entries in exchangeRates
            for (int i = 0; i <= _exchangeRate.Length - 1; i++)
            {
                Console.WriteLine("Checking entry at index " + i);

                // If we're the last entry OR if the next entry is lower than the current one
                if (i == _exchangeRate.Length - 1 || _exchangeRate[i + 1] < _exchangeRate[i])
                {
                    Console.WriteLine("Checking entry " + i + " value: " + _exchangeRate[i]);
                    // Check if any of the previous entries are lower than the current one
                    for (int j = i - 1; j >= 0; j--)
                    {
                        Console.WriteLine("Comparing previous entry to see if they are lower than the current one.");
                        if (_exchangeRate[j] < _exchangeRate[i])
                        {
                            if (foundIndex == -1)
                            {
                                Console.WriteLine("Found that an entry before the current one is lower, namely index " + j + " value: " + _exchangeRate[j]);
                                foundIndex = i;
                            }
                            else if (_exchangeRate[j] > _exchangeRate[foundIndex])
                            {
                                foundIndex = i;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Entry before the current one is higher. Moving on to the next entry, if possible.");
                        }

                    }
                }
                else
                {
                    Console.WriteLine("Entry was either not the last one or the one after it was not lower. Moving on to the next entry, if possible.");
                }
                Console.WriteLine("");
            }

            Console.WriteLine("Index: " + foundIndex);

            return foundIndex;
        }
    }

}