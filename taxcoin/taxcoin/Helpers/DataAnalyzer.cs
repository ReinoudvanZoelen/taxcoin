using System;
using System.Linq;

namespace taxcoin.Helpers
{
    public class DataAnalyzer
    {
        private int _budget;
        private int _taxcoin;
        private int[] _exchangeRate;

        public DataAnalyzer(int[] values)
        {
            _budget = values[0];

            _exchangeRate = new int[values.Length - 1];

            Console.WriteLine("Starting budget: " + _budget);

            for (int i = 0; i < values.Length - 1; i++)
            {
                _exchangeRate[i] = values[i + 1];
                Console.WriteLine("Starting value: " + _exchangeRate[i]);
            }
        }

        public int CalculateOptimalRevenue()
        {
            int foundIndex = FindEndIndexOfNextSubset();

            // Run this as long as there are entries where the entry after it is lower
            while (foundIndex != -1)
            {
                int[] subset = CreateSubset(foundIndex);

                TransferValuta(subset);

                RemoveSubsetFromExchangerates(foundIndex, subset);

                foundIndex = FindEndIndexOfNextSubset();
            }

            return _budget;
        }

        private int FindEndIndexOfNextSubset()
        {
            for (int i = 0; i < _exchangeRate.Length; i++)
            {
                if (i == _exchangeRate.Length - 1
                    || _exchangeRate[i + 1] < _exchangeRate[i]
                    && DoPrecedingItemsContainLower(i))
                {
                    return i;
                }
            }

            return -1;
        }

        private bool DoPrecedingItemsContainLower(int currentItemIndex)
        {
            for (int previousItemIndex = 0; previousItemIndex < currentItemIndex; previousItemIndex++)
            {
                if (_exchangeRate[previousItemIndex] < _exchangeRate[currentItemIndex])
                {
                    return true;
                }
            }

            return false;
        }

        private int[] CreateSubset(int index)
        {
            int[] subset = new int[index + 1];

            for (int i = 0; i <= index; i++)
            {
                subset[i] = _exchangeRate[i];
            }

            return subset;
        }

        private void TransferValuta(int[] subset)
        {
            int lowestPrice = int.MaxValue;
            int highestPrice = subset[subset.Length - 1];

            // Run though all entries except the last one (Length - 1) and see if it is the lowest
            // We know the last one is the highest and any number before that can be used to buy
            for (int i = 0; i < subset.Length - 1; i++)
            {
                if (subset[i] < lowestPrice)
                {
                    lowestPrice = subset[i];
                }
            }

            // Buy when price is low, converting ALL budget into taxcoin
            _taxcoin = _budget / lowestPrice;
            _budget = _budget % lowestPrice;

            // Sell, converting taxcoin back to money
            _budget += highestPrice * _taxcoin;
            _taxcoin = 0;
        }

        private void RemoveSubsetFromExchangerates(int index, int[] subset)
        {
            int[] newExchangeRates = new int[_exchangeRate.Length - subset.Length];

            // Transfer items from the old to the new array
            Console.WriteLine("");
            int counter = 0;
            for (int i = index + 1; i < _exchangeRate.Length; i++)
            {
                newExchangeRates[counter] = _exchangeRate[i];
                counter++;
            }

            _exchangeRate = newExchangeRates;
        }
    }

}