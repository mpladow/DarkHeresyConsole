using Engine.Actions;
using Engine.Statistics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Player:Human_Base
    {

        public Location CurrentLocation { get; set; }

        public Player()
        {

        }

        public static void ResetValues(Player player)
        {
            PropertyInfo[] pi = player.GetType().GetProperties();
            for (int i = 0; i < pi.Length; i++)
            {
                if(pi[i].PropertyType == typeof(int))
                {
                    pi[i].SetValue(player, 0);
                }
                if(pi[i].PropertyType == typeof(string))
                {
                    pi[i].SetValue(player, "");
                }
            }
        }

        public static void AllocateValues(Player player)
        {
            //PropertyInfo[] pi = player .GetType().GetProperties();
            //var statValue = 0;
            ////TEST
            //player.HomeWorld = "Feral World";
            //for (int i = 0; i < 12; i++)   
            //{
            //    statValue = 0;
            //    if (pi[i].PropertyType == typeof(int))//checks if the value is an int 
            //    {
            //        statValue = DiceRolls.RollD10(2, rn).Sum();
            //        if(player.HomeWorld == "Feral World")
            //        {
            //            if(pi[i].Name == "Str")
            //            {
            //                int[] roll = DiceRolls.RollD10(3, rn);
            //                statValue = DiceRolls.TakeDice(2, roll, true).Sum();
            //            }
            //            if (pi[i].Name == "T")
            //            {
            //                int[] roll = DiceRolls.RollD10(3, rn);
            //                statValue = DiceRolls.TakeDice(2, roll, true).Sum();
            //            }
            //            if (pi[i].Name == "Inte")
            //            {
            //                int[] roll = DiceRolls.RollD10(3, rn);
            //                statValue = DiceRolls.TakeDice(2, roll, false).Sum();
            //            }
            //        }
            //        statValue += 25;
            //        if (statValue >= 100)
            //        {
            //            statValue = 100;
            //        }
            //        pi[i].SetValue(player, statValue);
            //    }  
            //}
        }

       
    }
}
