using Engine.Statistics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Events
{
    public class MeleeCombat
    {
        public string EncounterType { get; set; }//there can be scripted or random encounters.
        public Character_base[] TeamA { get; set; }
        public Character_base[] TeamB { get; set; }
        public List<string> Messages { get; set; }
        public List<StatModifier> Modifiers { get; set; }
        public bool isSurprised { get; set; }
        //get combatants
        // return the result
        //return any messages that will occur.


        //team 1 makes moves

        public void SetUpCombat()
        {
            //generate any lists or actions that need to be prepared.
            //load up the UI.
            //import the appropriate text script file 
        }
        public void AddModifier(Character_base character, StatModifier modifier)
        {

        }
        public void RemoveModifier(Character_base character, StatModifier modifier)
        {

        }
        public void TeamATurn()
        {
            //it is your turn to move.
            //if standard attack is used, do standard attack.
            //..on the enemy that is selected.
            //conduct validation on when you can use this attack.

            //if take cover is selected, take cover.

        }
        public void TeamBTurn()
        {
            //if the player does not know what to expect, randomly generate enemies. otherwise, pass in the enemy team here.
        }
        public void ResolveCombat()
        {
            //generate loot
            //pass in the appropriate text for when the battle concludes.
            //close the window at the end.
        }
    }
}
