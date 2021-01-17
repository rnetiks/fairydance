using System;
using System.Collections.Generic;
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
    class Program
    {
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
                        break;
                }
            }
        }
        class PlayerData
        {
            public string Name;
            public int Level;
            public int Strength;
            public int Intelligence;
            public int Agility;
            public byte Statpoints;
            public float Money = 341.32f;

        }
        private static void PlayGame()
        {
            var t = new PlayerData();
            Console.WriteLine(t.Money.ToString("c"));
            Console.Write(">> Character Name: ");
            Console.ReadLine();
            Console.WriteLine("Stats:");
            Console.WriteLine("STR: 10 (Physical Damage)");
            Console.WriteLine("INT: 10 (Magical Damage)");
            Console.WriteLine("AGI: 10 (Evasion Chance & Stamina)");
            Console.WriteLine("(Stats may change in the Future)");
        }
        private static void HelpMenu()
        {
            Console.WriteLine("'help' - Shows the Help Page");
            Console.WriteLine("'load' - Shows the Load Page");
        }
    }
}
