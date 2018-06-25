using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Statistics
{
    public class CharacterStat
    {
        public enum StatName
        {
            Ws,
            Bs,
            Str,
            T,
            Ag,
            Inte,
            Per,
            Wp,
            Fel,
            Ifl,
        }
        private int _value;
        public string Name { get; set; }
        public int BaseValue { get; set; }//this is set at the character creation and only changes when the character levels up

        public int Value //this is the public value that is constantly displayed
        {
            get
            {
                _value = CalculateFinalValue();
                return _value;
            }
        }
        private List<StatModifier> StatModifiers; //this shows the modifiers that are currently affecting the user. This includes the homeworld buffs and job buffs



        //constructors
        public CharacterStat(string name)
        {
            Name = name;
            StatModifiers = new List<StatModifier>();
        }

        public CharacterStat(string name, int basevalue)
        {
            Name = name;
            BaseValue = basevalue;
        }


        public void SetNewBaseValue(int value)
        {
            this.BaseValue += value;
        }

        void AddModifier(StatModifier modifier)
        {
            StatModifiers.Add(modifier);
        }

        void RemoveModifier(StatModifier modifier)
        {
            var exists = StatModifiers.Any(x => x.Name == modifier.Name);
            if (exists)
            {
                StatModifiers.Remove(modifier);
            }
        }

        private int CalculateFinalValue()
        {
            int finalValue = BaseValue;

            for (int i = 0; i < StatModifiers.Count; i++)
            {
                finalValue += StatModifiers[i].Value;
            }

            return finalValue;
        }
        //should be able to add and remove modifiers
        //should be able to calculate final values
    }

    class StatModifier
    {
        public string Name;
        public int Value;
        public StatModifier(int value, string name = "")
        {
            Name = name;
            Value = value;
        }
    }
}
