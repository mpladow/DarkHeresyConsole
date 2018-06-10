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
            var generatingChar = true;
            while (inGame)
            {
                //TEST
                List<(int, string)> difficulties = Difficulties.GenerateDifficulties();
                var xx= difficulties.FirstOrDefault(x => x.Item1 == 1);
                var xxx = xx.Item2;
                //ENDTEST

                var player = new Player();
                while (generatingChar)
                {
                    Player.ResetValues(player);
                    Player.GeneratePlayer(player);
                    var input = "";

                    Console.WriteLine("You were born on a {0}.", player.HomeWorld);
                    Console.WriteLine("Enter a name for your character.");
                    player.Name = Console.ReadLine();
                    UserInterface.ShowCharacterStats(player);

                    Console.WriteLine("");

                    Console.WriteLine("Would you like to generate a new character?");

                    input = Console.ReadLine();

                    if (input == "n")
                    {
                        generatingChar = false;
                    }
                }


                Constants.Difficulties.GenerateDifficulties();
                Console.WriteLine("You see a guard door.");
                Console.WriteLine(Skills.Sneak(player.Fel, Constants.Difficulties.Trivial));
                Console.ReadLine();

                Console.WriteLine("The door is barred with iron bars.");
                Console.WriteLine(Skills.BreakDoor(player.Str, Constants.Difficulties.VeryHard));
                Console.ReadLine();

                Console.WriteLine("You talk to the guard, who is wary of you");
                Console.WriteLine(Skills.Charm(player.Fel, Constants.Difficulties.Ordinary));
                Console.ReadLine();

                //var player = new Player("Michael", 10, 15, 100, 0);
                //var ui = new UserInterface();
                //player.Options = player.OptionsMenu();

                //var input1 = "";
                //var input2 = "";

                ////Generate Room
                //var entranceRoom = new Room("bedroom", "small", "low");
                //var itemsInRoom = new List<Object>()
                //{
                //    new Book("Book of Light", "Standard", 2.0),
                //    new Potion("Healing Potion", 10, 0.2)
                //};

                //entranceRoom.Options = entranceRoom.OptionsMenu();

                //Console.WriteLine("You enter a {0} {1}, with a bed and a small book on the table.", entranceRoom.Size, entranceRoom.Name);

                //input1 = ui.RegisterInput(player.Options, "What do you choose to do?");//this will wait for an input from the user
                //Console.WriteLine("You wish to {0} ...", input1);
                //input2 = ui.RegisterInput(entranceRoom.Options, "");

                //Console.WriteLine("You try to {0} the {1}",input1, input2);
                //Console.ReadLine();

            }

        }

        public static void SetToTop(Player player)
        {
            var top = Console.CursorTop;
            var left = Console.CursorLeft;
            Console.SetCursorPosition(0, 0);
        }





    }
}
