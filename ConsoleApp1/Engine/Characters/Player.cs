using Engine.Actions;
using Engine.Statistics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static Engine.Actions.DiceRolls;

namespace Engine
{
    [Serializable]
    public class Player:Character_base
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

        public D100Result ConductMovementCheck(string skill)
        {
            D100Result result = null;
            //the skill will always be in here, but just in case...
            var skillInList = MovementSkills.Where(x => x.Name == skill).FirstOrDefault();
            if (skillInList != null)
            {
                result = skillInList.ConductCheck();
            }
            return result;
        }


    }
}
