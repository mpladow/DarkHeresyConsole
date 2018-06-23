using ConsoleApp1.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Actions
{
    static class DiceRolls
    {
        public static string RollD100(Random rn)
        {
            RNG.NumberBetween(1, 10);
            int d10_ones = rn.Next(1, 10);
            int d10_tens = rn.Next(1, 10);
            if (d10_tens == 10)
            {
                d10_tens = 0;
            }
            string result = d10_ones.ToString() + d10_tens.ToString();
            return result;
        }
        public static int[] RollD10(int times, Random rn)
        {
            var results = new int[times];
            for (int i = 0; i < times; i++)
            {
                results[i] = rn.Next(1, 10);
            }
            return results;
        }

        //takes the number of dice from the roll - i.e. selecting the top results out of 3 dice rolls.
        public static int[] TakeDice(int numDiceToTake, int[] result, bool takeHighest)
        {
            if (takeHighest)
            {
                result = result.OrderByDescending(c => c)
              .Take(numDiceToTake)
              .ToArray();//sort from highest to lowest, take the top 2, then return
            }
            else
            {
                result = result.OrderBy(c => c)
                    .Take(numDiceToTake)
                    .ToArray();//sort from lowest to highest, take the top 2, then return
            }

            return result;
        }

    }
}
