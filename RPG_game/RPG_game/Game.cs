using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using NAudio.Wave;

namespace RPG_game
{
    internal class Game
    {
        public void Start()
        {

            string prompt = @"██████╗ ██████╗  █████╗  ██████╗  ██████╗ ███╗   ██╗███████╗     ██████╗ █████╗ ██████╗ ████████╗██╗██╗   ██╗███████╗
██╔══██╗██╔══██╗██╔══██╗██╔════╝ ██╔═══██╗████╗  ██║██╔════╝    ██╔════╝██╔══██╗██╔══██╗╚══██╔══╝██║██║   ██║██╔════╝
██║  ██║██████╔╝███████║██║  ███╗██║   ██║██╔██╗ ██║███████╗    ██║     ███████║██████╔╝   ██║   ██║██║   ██║█████╗  
██║  ██║██╔══██╗██╔══██║██║   ██║██║   ██║██║╚██╗██║╚════██║    ██║     ██╔══██║██╔═══╝    ██║   ██║╚██╗ ██╔╝██╔══╝  
██████╔╝██║  ██║██║  ██║╚██████╔╝╚██████╔╝██║ ╚████║███████║    ╚██████╗██║  ██║██║        ██║   ██║ ╚████╔╝ ███████╗
╚═════╝ ╚═╝  ╚═╝╚═╝  ╚═╝ ╚═════╝  ╚═════╝ ╚═╝  ╚═══╝╚══════╝     ╚═════╝╚═╝  ╚═╝╚═╝        ╚═╝   ╚═╝  ╚═══╝  ╚══════╝
                                                                                                                     
Üdvözöllek a Dragon's Captive: A Hero's Tale játékban. Mit szeretnél csinálni?";

            string[] Valasztasok = { "Új játék", "Játék folytatása", "Beállítások", "Credits", "Kilépés" };
            Menu mainMenu = new Menu(prompt, Valasztasok);
            int kivalasztottmenupont = mainMenu.Run();


            switch (kivalasztottmenupont)
            {
                case 0:
                    RunGame();
                    break;
                case 1:
                    ContinueGame();
                    break;
                case 2:
                    Settings();
                    break;
                case 3:
                    RollCredits();
                    break;
                case 4:
                    ExitGame();
                    break;
            }


        }

        private void RunGame()
        {
            Clear();
            Console.Write("Mi legyen a karaktered neve: ");
            string karakterNev = Console.ReadLine();
            Console.Write("Válaszd ki a nemed (Férfi/Nő): ");
            string nem = Console.ReadLine();
            Start();
        }

        private void ContinueGame()
        {
            Clear();
            Console.WriteLine("- Nincs mentés -");
            Console.WriteLine("- Nincs mentés -");
            Console.WriteLine("- Nincs mentés -");
            Console.ReadKey(true);
            Start();
        }

        private int savedDifficulty = 0;

        private void Settings()
        {
            string prompt = $"Jelenlegi nehézségi szint: {GetDifficultyName(savedDifficulty)}";
            string[] Valasztasok = { "Könnyű", "Közepes", "Nehéz", "Legendás" };
            Settings beallitasok = new Settings(prompt, Valasztasok);
            int kivalasztottmenupont = beallitasok.SettingsRun();

            switch (kivalasztottmenupont)
            {
                case 0:
                    savedDifficulty = 0;
                    SettingsEasy();
                    break;
                case 1:
                    savedDifficulty = 1;
                    SettingsMedium();
                    break;
                case 2:
                    savedDifficulty = 2;
                    SettingsHard();
                    break;
                case 3:
                    savedDifficulty = 3;
                    SettingsLegendary();
                    break;
            }

            ConsoleKeyInfo keyInfo;
            do
            {
                keyInfo = Console.ReadKey(true);
            } while (keyInfo.Key != ConsoleKey.Backspace);

            Start();
        }
        private string GetDifficultyName(int difficulty)
        {
            string[] difficultyNames = { "Könnyű", "Közepes", "Nehéz", "Legendás" };
            return difficultyNames[difficulty];
        }

        void SettingsEasy()
        {
            string prompt = "Jelenlegi nehézségi szint: Könnyű";
            string[] Valasztasok = { "Könnyű", "Közepes", "Nehéz", "Legendás" };
            Settings beallitasok = new Settings(prompt, Valasztasok);
            int kivalasztottmenupont = beallitasok.SettingsRun();
        }

        void SettingsMedium()
        {
            string prompt = "Jelenlegi nehézségi szint: Közepes";
            string[] Valasztasok = { "Könnyű", "Közepes", "Nehéz", "Legendás" };
            Settings beallitasok = new Settings(prompt, Valasztasok);
            int kivalasztottmenupont = beallitasok.SettingsRun();
        }

        void SettingsHard()
        {
            string prompt = "Jelenlegi nehézségi szint: Nehéz";
            string[] Valasztasok = { "Könnyű", "Közepes", "Nehéz", "Legendás" };
            Settings beallitasok = new Settings(prompt, Valasztasok);
            int kivalasztottmenupont = beallitasok.SettingsRun();
        }

        void SettingsLegendary()
        {
            string prompt = "Jelenlegi nehézségi szint: Legendás";
            string[] Valasztasok = { "Könnyű", "Közepes", "Nehéz", "Legendás" };
            Settings beallitasok = new Settings(prompt, Valasztasok);
            int kivalasztottmenupont = beallitasok.SettingsRun();
        }

        private void RollCredits()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Ez a Dragon's Captive RPG játék konzolos megvalósítása.");
            Console.WriteLine("Készítette: Palkó Dávid, Szabó Gergely, Magyar Ádám");

            int windowHeight = Console.WindowHeight;
            int windowWidth = Console.WindowWidth;
            int textWidth = Console.WindowWidth / 2;
            int startPosition = windowHeight - 1;

            while (true)
            {
                for (int i = 0; i < windowHeight; i++)
                {
                    Console.Clear();


                    Console.SetCursorPosition((windowWidth - textWidth) / 2, startPosition - i);
                    Console.WriteLine("Ez a Dragon's Captive RPG játék konzolos megvalósítása.");
                    Console.SetCursorPosition((windowWidth - textWidth) / 2, startPosition + 1 - i);
                    Console.WriteLine("Készítette: Palkó Dávid, Szabó Gergely, Magyar Ádám");

                    System.Threading.Thread.Sleep(50);
                }

                ForegroundColor = ConsoleColor.Black;

                startPosition = windowHeight - 1;

                Start();
            }
        }

        private void ExitGame()
        {
            Clear();
            Console.WriteLine("\nNyomj meg egy gombot a kilépéshez...");
            Console.ReadKey(true);
            Environment.Exit(0);
        }
    }
}
