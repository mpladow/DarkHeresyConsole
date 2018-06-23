using ConsoleApp1.Utilities;
using ConsoleApp1.Utilities.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConsoleApp1.Utilities.Constants.Constants;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var inGame = true;

            UserInterface.WriteToCentre("Hello World");
            Console.ReadLine();
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
        public static void NewGame()
        {

            Player[] players = CharacterCreation();

            Console.WriteLine("Character creation complete");

            while (true)
            {
                Console.WriteLine("You see a guard door.");
                Console.WriteLine(Skills.Sneak(players[0], players[0].Fel, Constants.Difficulties.Trivial));
                Console.ReadLine();

                Console.WriteLine("The door is barred with iron bars.");
                Console.WriteLine(Skills.BreakDoor(players[0], players[0].Str, Constants.Difficulties.VeryHard));
                Console.ReadLine();

                Console.WriteLine("You talk to the guard, who is wary of you");
                Console.WriteLine(Skills.Charm(players[0].Fel, Constants.Difficulties.Ordinary));
                Console.ReadLine();
            }


        }

        public static Player[] CharacterCreation() {
            Player[] players = new Player[3];
            do
            {
                for (int i = 0; i < players.Length; i++)
                {
                    if (players[i] != null)
                    {
                        Player.ResetValues(players[i]);
                    }
                    players[i] = new Player();
                    Player.GeneratePlayer(players[i]);
                    var input = "";

                    Console.WriteLine("You were born on a {0}.", players[i].HomeWorld);
                    var acolyteNumber = "";
                    switch (i)
                    {
                        case 0:
                            acolyteNumber = "[first]";
                            break;
                        case 1:
                            acolyteNumber = "[second]";
                            break;
                        case 2:
                            acolyteNumber = "[third]";
                            break;
                        default:
                            acolyteNumber = "";
                            break;
                    }
                    Console.WriteLine("Enter a name for your {0} Acolyte.", acolyteNumber);
                    players[i].Name = Console.ReadLine();
                    UserInterface.ShowCharacterStats(players[i]);

                    Console.WriteLine("");

                    Console.WriteLine("Press 'R' to reset this character, or any other key to continue...");

                    input = Console.ReadLine();
                    if (input == "r")
                    {
                        UserInterface.RefreshUI();
                        i = i - 1;
                    }
                }
                break;
            } while (true);
            return players;
        }
        public static void SetToTop(Player player)
        {
            var top = Console.CursorTop;
            var left = Console.CursorLeft;
            Console.SetCursorPosition(0, 0);
        }
    }

}
