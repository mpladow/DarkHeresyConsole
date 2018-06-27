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
        //Die results to return object back to characteristic check
        public class DieResult
        {
            public int[] Result{ get; set; }
            public int IntValue { get; set; }
            public string StrValue { get; set; }
            public bool isSuccess { get; set; }
            public int DegreesofSuccess { get; set; }
        }
        public class D100Result:DieResult
        {
            public D100Result(int[] result, int intvalue, string strvalue, bool isSuccess = false, int degreesofsuccess = 0 )
            {
                Result = result;
                IntValue = intvalue;
                StrValue = strvalue;
            }
        }

        //rolls die and returns three different values encapulated in an object
        public static D100Result RollD100(Random rn)
        {
            //RNG.NumberBetween(1, 10);
            int[] die = new int[2];
            die[0] = rn.Next(1, 10);//10
            die[1] = rn.Next(1, 10);//10 = 100

            string strDie = "";
            int intDie = 0;

            if (die[1] == 10 && die[0] == 1)
            {
                intDie = 1;
            }
            if(die[1] == 10 && die[0] == 10)
            {
                intDie = 100;
            }
            strDie = die[1].ToString() + die[0].ToString();
            intDie = Convert.ToInt32(strDie);
            D100Result result = new D100Result(die, intDie, strDie);
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

        //takes the number of dice from the roll - i.e. selecting the top results out of 3 dice rolls. Used in characteristic generation
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
