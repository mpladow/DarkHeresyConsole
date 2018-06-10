using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Utilities
{
    class UserInterface
    {
        public string RegisterInput(List<string> options, string message)
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
        public static void RefreshUI()
        {
            var currentPosition = (Console.CursorTop) - 1;
            for (int i = 1; i < 8; i++)
            {
                Console.Write(new String(' ', Console.WindowWidth));
                Console.SetCursorPosition(0, currentPosition);

                //Console.SetCursorPosition(0, currentPosition - 1);
                currentPosition -= 1;
            }

        }
        //this retrieves the options and formats them into a horizontal menu
        public static void BuildOptionsMenu(List<string> options, string selected, string message)
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
