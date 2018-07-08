using Engine.Utilities.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Statistics
{
    [Serializable]
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
        public string MainAptitude
        {
            get
            {
                var value = ReturnStatAptitude(Name);
                return value;
            }
        }
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
            StatModifiers = new List<StatModifier>();
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

        public string ReturnStatAptitude(string name)
        {
            var x = "";
            switch (name)
            {
                case "Ws":
                    x = World.AptitudesDict.FirstOrDefault(t => t.Key == 0).Value;
                    break;
                case "Bs":
                    x = World.AptitudesDict.FirstOrDefault(t => t.Key == 1).Value;
                    break;
                case "Str":
                    x = World.AptitudesDict.FirstOrDefault(t => t.Key == 0).Value;
                    break;
                case "T":
                    x = World.AptitudesDict.FirstOrDefault(t => t.Key == 2).Value;
                    break;
                case "Ag":
                    x = World.AptitudesDict.FirstOrDefault(t => t.Key == 1).Value;
                    break;
                case "Inte":
                    x = World.AptitudesDict.FirstOrDefault(t => t.Key == 3).Value;
                    break;
                case "Per":
                    x = World.AptitudesDict.FirstOrDefault(t => t.Key == 4).Value;
                    break;
                case "Wp":
                    x = World.AptitudesDict.FirstOrDefault(t => t.Key == 5).Value;
                    break;
                case "Fel":
                    x = World.AptitudesDict.FirstOrDefault(t => t.Key == 6).Value;
                    break;
                default:
                    break;
            }
            return x;

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
    [Serializable]
    public class StatModifier
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
