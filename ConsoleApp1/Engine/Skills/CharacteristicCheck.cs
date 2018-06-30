using Engine.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static Engine.Actions.DiceRolls;

namespace Engine.Actions
{
    public static class CharacteristicChecks
    {
        public class TestResult
        {
            public int MyProperty { get; set; }
        }

        public static D100Result DoCharacteristicCheck(int modCharValue)
        {
            Cryptorandom rn = new Cryptorandom();
            var d100result = RollD100(rn);

            d100result.isSuccess = d100result.IntValue <= (modCharValue) ? true : false;
            int[] modcharArray = modCharValue.ToString().ToCharArray().Select(x => (int)Char.GetNumericValue(x)).ToArray();
            Array.Reverse(modcharArray);
            d100result.DegreesofSuccess= modcharArray[1] - d100result.Result[1];
            d100result.isSuccess = d100result.IntValue == 1 ? true : d100result.isSuccess;//if the roll is a 1, then you automatically pass
            return d100result;
        }
    }
}
