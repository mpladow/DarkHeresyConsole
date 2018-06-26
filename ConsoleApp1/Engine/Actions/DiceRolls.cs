using Engine.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Actions
{
    public static class DiceRolls
    {

        public static int[] RollD100(Random rn)
        {
            //RNG.NumberBetween(1, 10);
            int[] die = new int[2];
            die[0] = rn.Next(1, 10);//
            die[1] = rn.Next(1, 10);//10
            if (die[0] == 10)
            {
                die[0] = 0;
            }
            return die;

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
