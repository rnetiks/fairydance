using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using System.Net.Http;

namespace ConsoleApp1
{
    /// <summary>
    /// Fighting game using all Keys by quickly pressing them in the correct order
    /// </summary>
    partial class Program
    {
        private static CultureInfo Culture = CultureInfo.CreateSpecificCulture("en-US");
        private enum Difficulty
        {
            Easy = 1,
            Medium = 2,
            Hard = 4,
            Hardcore = 8,
            Impossible = 16
        }
        private static Difficulty difficulty;
        private static void Main(string[] args)
        {
            MainMenu();
        }
        /// <summary>
        /// Show the Main Menu of the Game, containing the main Windows
        /// </summary>
        private static void MainMenu()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Fairydance");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(">> Type \"help\" for Help");
            string cmd = string.Empty;
            // note used til now
            ConsoleKey lastKey;
            while (true)
            {
                Console.Write(">> ");
                cmd = Console.ReadLine();
                switch (cmd)
                {
                    case "help":
                        HelpMenu();
                        break;
                    case "play":
                        PlayGame();
                        ShowSingleplayer();
                        break;
                }
            }
        }

        private static void ShowTopbar() => Console.WriteLine($"{player.Money.ToString("C", Culture)}\t{player.Name}");
        private static void ShowSingleplayer() {
            ShowTopbar();
            while (true) {
                string cmd = Console.ReadLine();
                switch (cmd) {
                    //Travel a random distance 833m-1244m * Agility, each 1000m chance for random encounter, the further from start point 0,0 the stronger 
                    case "travel":
                        break;
                    default:
                        Console.WriteLine("Unknown Command");
                        break;
                }
            }
        }

        static PlayerData player = new PlayerData();
        
        private static void PlayGame()
        {
            Console.Write(">> Character Name: ");
            var name = Console.ReadLine();
            if (name != null && (name.Length < 3 || name.Length > 32)) {
                Console.WriteLine("Name must not be under 3 Digits or over 32");
                PlayGame();
                return;
            }

            player.Name = name;
            Console.WriteLine("Stats:");
            Console.WriteLine("STR: 10 (Physical Damage)");
            Console.WriteLine("INT: 10 (Magical Damage)");
            Console.WriteLine("AGI: 10 (Evasion Chance & Stamina)");
            Console.WriteLine("(Stats may change in the Future)");
            Console.WriteLine("(Press any Key to continue)");
            Console.ReadKey(true);
        }
        private static void HelpMenu()
        {
            Console.WriteLine("'help' - Shows the Help Page");
            Console.WriteLine("'load' - Shows the Load Page");
        }
    }
}
