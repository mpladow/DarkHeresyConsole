using Engine.Statistics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Utilities.Constants;

namespace Engine.Utilities.Constants
{
    public static class SkillModifiersLists
    {
        public static readonly List<SkillModifier> DifficultiesList = new List<SkillModifier>();
        public static readonly List<SkillModifier> AptitudesList = new List<SkillModifier>();

        public static void PopulateDifficulties()
        {
            var trivial = new SkillModifier(Constants.Trivial, 60, "Trivial");
            var Ordinary = new SkillModifier(Constants.Ordinary, 10, "Ordinary");
            var Hard = new SkillModifier(Constants.Hard, -10, "Hard");
            var VeryHard = new SkillModifier(Constants.VeryHard, -30, "Very Hard");
            var Punishing = new SkillModifier(Constants.Punishing, -50, "Punishing");
            DifficultiesList.Add(trivial);
            DifficultiesList.Add(Ordinary);
            DifficultiesList.Add(Hard);
            DifficultiesList.Add(VeryHard);
            DifficultiesList.Add(Punishing);
        }

        public static SkillModifier GetDifficultyById(int id)
        {
            return DifficultiesList.Where(x => x.Id == id).FirstOrDefault();
        }

        public static void PopulateAptitudesList()
        {
            var unskilled = new SkillModifier(Constants.Unskilled, -20, "Unskilled");
            var known = new SkillModifier(Constants.Known, 0, "Known");
            var trained = new SkillModifier(Constants.Trained, 10, "Trained");
            var experienced = new SkillModifier(Constants.Experienced, 20, "Experienced");
            var veteran = new SkillModifier(Constants.Veteran, 30, "Veteran");

            AptitudesList.Add(unskilled);
            AptitudesList.Add(known);
            AptitudesList.Add(trained);
            AptitudesList.Add(experienced);
            AptitudesList.Add(veteran);
        }

        public static SkillModifier GetAptitudesById(int id)
        {
            var aptitude = AptitudesList.Where(x => x.Id == id).FirstOrDefault();
            return aptitude;
        }
    }
}
