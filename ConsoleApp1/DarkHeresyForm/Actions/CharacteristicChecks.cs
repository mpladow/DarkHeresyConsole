using ConsoleApp1.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Actions
{
    class CharacteristicChecks
    {
        public static Tuple<string, bool> FellowshipCheck(int modCharValue)
        {
            Random rn = new Random();
            var dicerollStr = DiceRolls.RollD100(rn);
            var dicerollInt = Convert.ToInt32(dicerollStr);
           

            var isSuccess = false;
            isSuccess = dicerollInt <= (modCharValue) ? true : false;
            isSuccess = dicerollInt == 1 ? true : isSuccess;//if the roll is a 1, then you automatically pass
            return Tuple.Create(dicerollStr, isSuccess);
        }
        public static Tuple<string, bool> StrengthCheck(int modCharValue)
        {
            Random rn = new Random();
            var dicerollStr = DiceRolls.RollD100(rn);
            var dicerollInt = Convert.ToInt32(dicerollStr);

            var isSuccess = false;
            isSuccess = dicerollInt <= (modCharValue) ? true : false;
            isSuccess = dicerollInt == 1 ? true : isSuccess;//if the roll is a 1, then you automatically pass
            return Tuple.Create(dicerollStr, isSuccess);
        }

        public static Tuple<string, bool> PerceptionCheck(int modCharValue)
        {
            Random rn = new Random();
            var dicerollStr = DiceRolls.RollD100(rn);
            var dicerollInt = Convert.ToInt32(dicerollStr);

            var isSuccess = false;
            isSuccess = dicerollInt <= (modCharValue) ? true : false;
            isSuccess = dicerollInt == 1 ? true : isSuccess;//if the roll is a 1, then you automatically pass
            return Tuple.Create(dicerollStr, isSuccess);

        }
    }
}
