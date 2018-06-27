using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Utilities.Constants
{
    public static class Constants
    {
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

        //public static List<(int value, string name)> GenerateDifficulties()
        //{

        //    var trivial = new Tuple<int, string>(60, "Trivial");
        //    var Ordinary = new Tuple<int, string>(10, "Ordinary");
        //    var Hard = new Tuple<int, string>(-10, "Hard");
        //    var VeryHard = new Tuple<int, string>(-30, "Very Hard");
        //    var Punishing = new Tuple<int, string>(-50, "Punishing");

        //    var tupleList = new List<(int value, string name)>
        //    {
        //        (60, "Trivial"),
        //        (10, "Ordinary"),
        //        (-10, "Hard"),
        //        (-30, "Very Hard"),
        //        (-50, "Punishing")
        //    };
        //    return tupleList;
        //}

    }
}
