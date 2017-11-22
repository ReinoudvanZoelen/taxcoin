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
        private int[] exchangeRate;

        public DataAnalyzer(int[] values)
        {
            #region Split read values to budget and exchangeRate
            budget = values[0];

            exchangeRate = new int[values.Length - 1];

            for (int i = 0; i < values.Length - 1; i++)
            {
                exchangeRate[i] = values[i + 1];
            }
            #endregion
        }

        public int FindMaximalValue()
        {
            while(findIndexWhereNextValueIsLower() != -1)
            {
                #region find a value where the next value is higher than the current one

                #endregion


                #region create a set of integers starting at the start and ending at the abovefound index

                #endregion


                #region Divide our budget with the lowest and multiply with the highest

                #endregion


                #region Continue with the rest of the set untill there is no more value where the next value is higher than the current one

                #endregion
            }

            return budget;
        }

        private int findIndexWhereNextValueIsLower()
        {
            int startingValue = -1;
            
            return startingValue;
        }
    }
}
