using ConsoleApp1.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ConsoleApp1
{
    static class Skills
    {
       
        public static string Sneak(Player player, int charvalue, int difficulty = 0)
        {
            var modValue = CalculateSkill(charvalue, difficulty);
            var result = CharacteristicChecks.FellowshipCheck(modValue);

            var message = player.Name + " attempts to sneak.\r\n";
            message += "You rolled a " + result.Item1 + " against your Fellowship value of " + modValue;
            if (result.Item2 == false)
            {
                message += ", unfortunately you were spotted...";
            }
            else
            {
                message += ", you are currently sneaking!"; ;
            }
            return message;

        }
        public static string BreakDoor(Player player, int charvalue, int difficulty = 0)
        {
            var modValue = CalculateSkill(charvalue, difficulty);
            var result = CharacteristicChecks.StrengthCheck(modValue);

            var message = player.Name + " attempt to break down the door.\r\n";
            message += "(You rolled a " + result.Item1 + " against your Strength value of " + modValue+ ").";
            if (result.Item2 == false)
            {
                message += ", unfortunately you failed.";
            }
            else
            {
                message += ", you successfully"; ;
            }
            return message;

        }

        public static string Charm(int charvalue, int difficulty = 0)
        {
            var modValue = CalculateSkill(charvalue, difficulty);
            var result = CharacteristicChecks.FellowshipCheck(modValue);

            var message = "You attempt to charm CHARACTER.\r\n";
            message += "You rolled a " + result.Item1 + " against the opponent Willpower value of "+charvalue+" with a modifier of " + modValue;
            if (result.Item2 == false)
            {
                message += ", unfortunately you failed.";
            }
            else
            {
                message += ", success!"; ;
            }
            return message;

        }

        public static string Awareness(int charvalue, int difficulty = 0)
        {
            var modValue = CalculateSkill(charvalue, difficulty);
            var result = CharacteristicChecks.StrengthCheck(modValue);

            

            var message = "You rolled a " + result.Item1 + " against the  Willpower value of " + modValue;
            if (result.Item2 == false)
            {
                message += ", unfortunately you failed.";
            }
            else
            {
                message += ", success!"; ;
            }
            return message;

        }

        public static int CalculateSkill(int charvalue, int difficulty = 0)
        {
            var modValue = charvalue + difficulty;
            modValue = modValue >= 100 ? 100 : modValue;
            modValue = modValue <= 1 ? 1 : modValue;

            return modValue;
        }



    }
}
