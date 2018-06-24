using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Utilities
{
    static class UserInterface
    {
        public interface ICommand
        {
            string Description { get; }
            void Execute();
        }
        public class NewGame : ICommand
        {
            public string Description => "New Game";
            public void Execute()
            {
                Program.NewGame();
            }
        }
        public class Exit : ICommand
        {
            public string Description => "Exit game";
            public void Execute()
            {
                Environment.Exit(0);
            }
        }

        //this will take a list of menu options, convert the descriptions into the menu options, then return this string and search the descriptiuons fot the selected option.
        public static void RegisterMenuInput(List<ICommand> menuOptions, string message)
        {
            var optionSelected = menuOptions[0];
            var optionsLength = menuOptions.Count() - 1;
            var selected = menuOptions[0];

            int selectedIndex = menuOptions.IndexOf(selected);
            var input = false;
            List<string> menuStrings = new List<string>();
            foreach (var item in menuOptions)
            {
                menuStrings.Add(item.Description);
            }
            var selectedString = CycleOptions(menuStrings, message);

            selected = menuOptions.FirstOrDefault(x => x.Description == selectedString);

            selected.Execute();


        }

        //this will take either a list of strings
        public static string RegisterInput(List<string> options, string message)
        {
            var optionSelected = options[0];
            var optionsLength = options.Count() - 1;
            var selected = options[0];

            int selectedIndex = options.IndexOf(selected);
            selected = CycleOptions(options, message);

            return selected;
        }





        static string CycleOptions(List<string> options, string message)
        {
            var optionSelected = options[0];
            var optionsLength = options.Count() - 1;
            var selected = options[0];

            int selectedIndex = options.IndexOf(selected);
            var input = false;

            while (!input)
            {
                BuildOptionsMenu(options, selected, message);
                selectedIndex = options.IndexOf(selected);
                var k = Console.ReadKey();
                switch (k.Key)
                {

                    case ConsoleKey.RightArrow:
                        RefreshUI();
                        if (selectedIndex != optionsLength)
                            selected = options[selectedIndex + 1];
                        else
                        {
                            selected = options[0];//returns back to the start
                        }
                        break;
                    case ConsoleKey.LeftArrow:
                        RefreshUI();
                        //then change selected to the next option up
                        if (selectedIndex != 0)
                            selected = options[selectedIndex - 1];
                        else
                        {
                            selected = options[optionsLength];//returns back to the start
                        }
                        break;
                    case ConsoleKey.Enter:
                        RefreshUI();
                        input = true;
                        break;
                    default:
                        RefreshUI();
                        break;
                }
            }
            return selected;
        }
        public static void CreateTitle()
        {

        }

        
        public static void RefreshUI()
        {
            var currentPosition = (Console.CursorTop) + 1;
            for (int i = 1; i < 8; i++)
            {
                Console.Write(new String(' ', Console.WindowWidth));
                Console.SetCursorPosition(0, currentPosition);

                //Console.SetCursorPosition(0, currentPosition - 1);
                currentPosition -= 1;
            }

        }

        public static void WriteToTop(string text)
        {
            Console.SetCursorPosition((Console.WindowWidth - text.Length) / 2, (Console.WindowTop + 1));
            Console.WriteLine(text);
        }

        public static void WriteToCentre(string text)
        {
            Console.SetCursorPosition((Console.WindowWidth - text.Length) / 2, (Console.WindowHeight-1)/3);
            Console.WriteLine(text);
        }

        //this retrieves the options and formats them into a horizontal menu
        static void BuildOptionsMenu(List<string> options, string selected, string message)
        {
            var optionSelected = options[0];
            var optionsLength = options.Count();

            var charCount = 0;
            foreach (var option in options)
            {
                charCount += option.Count() + 4;
            }
            charCount += 4;
            //builds the ui
            for (int i = 0; i < charCount; i++)
            {
                Console.Write("+");
            }
            Console.WriteLine("\r\n");
            foreach (var option in options)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
                if (option == selected)
                {
                    Console.Write(" -- ");
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.Write(option);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write(" -- ");
                    Console.Write(option);
                }
                //if the item is the last item in the list, create a new line
                if (option == options[optionsLength - 1])
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write(" -- ");
                    Console.WriteLine("\r\n");
                }
            }
            for (int i = 0; i < charCount; i++)
            {
                Console.Write("+");
            }
            Console.WriteLine("\r\n");
            Console.WriteLine(message);
        }


        public static void ShowCharacterStats(Player player)
        {
            for (int i = 0; i < 50; i++)
            {
                Console.Write("+");
            }
            Console.WriteLine("");
            Console.WriteLine("Character Stats:");
            Console.WriteLine("{0}", player.Name);
            Console.WriteLine("Home World: {0}", player.HomeWorld);
            Console.WriteLine("Weapon Skill:   {0}             Intelligence: {1}", player.Ws, player.Inte);
            Console.WriteLine("Balistic Skill: {0}             Perception:   {1}", player.Bs, player.Per);
            Console.WriteLine("Strength:       {0}             Willpower:    {1}", player.Str, player.Wp);
            Console.WriteLine("Toughness:      {0}             Fellowship:   {1}", player.T, player.Fel);
            Console.WriteLine("Agility :       {0}             Influence:    {1} \r\n", player.Ag, player.Ifl);
            for (int i = 0; i < 50; i++)
            {
                Console.Write("+");
            }
        }
    }
}
