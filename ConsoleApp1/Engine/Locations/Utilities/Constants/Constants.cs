using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Utilities.Constants
{
    class Constants
    {
        public static class Difficulties
        {
            public const int Trivial = 60;
            public const int Ordinary = 10;
            public const int Hard = -10;
            public const int VeryHard = -30;
            public const int Punishing = -50;


            public static List<(int value, string name)> GenerateDifficulties()
            {

                var trivial = new Tuple<int, string>(60, "Trivial");
                var Ordinary = new Tuple<int, string>(10, "Ordinary");
                var Hard = new Tuple<int, string>(-10, "Hard");
                var VeryHard = new Tuple<int, string>(-30, "VeryHard");
                var Punishing = new Tuple<int, string>(-50, "Punishing");

                var tupleList = new List<(int value, string name)>
                {
                    (60, "Trivial"),
                    (10, "Ordinary"),
                    (-10, "Hard"),
                    (-30, "VeryHard"),
                    (-50, "Punishing")
                };
                return tupleList;
            }
        }

    }
}
