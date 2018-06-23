using ConsoleApp1.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DarkHeresyForm
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            var inGame = true;

            while (inGame)
            {
                //create options menu - which will include new game, load game, and exit
                var mainMenu = new List<UserInterface.ICommand>()
                {
                    new UserInterface.NewGame(),
                    new UserInterface.Exit()
                };
                UserInterface.RegisterMenuInput(mainMenu, "What would you like to do today?");
                Console.ReadLine();
            }
        }
    }
}
