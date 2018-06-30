using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Utilities.Constants
{
    public static class Constants
    {
        public const int StartingExperience = 1000;
        //homeworlds
        public const int FeralWorld = 1;
        public const int HiveWorld = 2;
        public const int HighBorn = 3;
        public const int ForgeWorld = 4;
        public const int ShrineWorld = 5;
        public const int VoidBorn = 6;

        //availability 
        public const int AvailUbiquitous= 1;
        public const int AvailAbundant = 2;
        public const int AvailPlentiful = 3;
        public const int AvailCommon = 4;
        public const int AvailAverage = 5;
        public const int AvailScarce = 6;
        public const int AvailRare = 7;
        public const int AvailVeryRare = 8;
        public const int AvailExtremelyRare = 9;
        public const int AvailNearUnique = 2;
        public const int AvailUnique = 3;

        //craftsmanship
        public const int Poor = 1;
        public const int Common = 2;
        public const int Good = 3;
        public const int Best = 4;

        //ranges
        public const int ShortRange = 1;
        public const int LongRange = 2;
        public const int Extreme = 3;

        //difficulties
        public const int Trivial = 0;
        public const int Ordinary = 1;
        public const int Hard = 2;
        public const int VeryHard = 3;
        public const int Punishing = 4;

        //rank ids
        public const int Unskilled = 0;
        public const int Known = 1;
        public const int Trained = 2;
        public const int Experienced = 3;
        public const int Veteran = 4;



    }
}
