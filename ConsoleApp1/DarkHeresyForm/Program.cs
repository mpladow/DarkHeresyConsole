using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Engine;
using Engine.Utilities;
using Engine.Utilities.Constants;

namespace DarkHeresyForm
{
    static class Program
    {
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ReadOnlyLists.PopulateDifficulties();
            ReadOnlyLists.PopulateSkillLevels();
            ReadOnlyLists.PopulateSkills();
            ReadOnlyLists.PopulateAptitudesDictionary();
            ReadOnlyLists.PopulateRangedWeapons();
            ReadOnlyLists.PopulateBackgrounds();
            ReadOnlyLists.PopulateHomeWorlds();
           

            SaveLoad.Load();
            Application.Run(new splashscreen());



        }
    }
}
