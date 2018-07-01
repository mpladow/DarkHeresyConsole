﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Engine;
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
            ReadOnlyLists.PopulateBackgrounds();

            Application.Run(new splashscreen());



        }
    }
}
