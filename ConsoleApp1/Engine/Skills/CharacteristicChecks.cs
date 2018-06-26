using Engine.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Actions
{
    public static class CharacteristicChecks
    {
        public static Tuple<string, bool, int> DoCharacteristicCheck(int modCharValue)
        {
            Random rn = new Random();
            var dicerollActual = DiceRolls.RollD100(rn);
            var dicerollConvertedString = dicerollActual[1].ToString()+ dicerollActual[0].ToString();
            var dicerollConvertedInt = Convert.ToInt32(dicerollConvertedString);

            var isSuccess = false;
            isSuccess = dicerollConvertedInt <= (modCharValue) ? true : false;
            int[] modcharArray = modCharValue.ToString().ToCharArray().Select(x => (int)Char.GetNumericValue(x)).ToArray();
            Array.Reverse(modcharArray);
            var degreesOfSuccessOrFailure = modcharArray[1] - dicerollActual[1];
            isSuccess = dicerollConvertedInt == 1 ? true : isSuccess;//if the roll is a 1, then you automatically pass
            return Tuple.Create(dicerollConvertedString, isSuccess, degreesOfSuccessOrFailure);
        }
    }
}
