using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace RPG_game
{
    internal class Settings : Menu
    {
        private int KivalasztottMenupont;
        private string[] Valasztasok;
        private string Prompt;
        private int savedDifficulty;
        public Settings(string prompt, string[] valasztasok) : base(prompt, valasztasok)
        {
            Prompt = prompt;
            Valasztasok = valasztasok;
            KivalasztottMenupont = 0;
            savedDifficulty = 0;
        }

        private void ValasztasiLehetosegek()
        {
            static void KozepreIr(string szoveg)
            {
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (szoveg.Length / 2)) + "}", szoveg));
            }
            Console.WriteLine(Prompt);
            for (int i = 0; i < Valasztasok.Length; i++)
            {
                string kivalasztott = Valasztasok[i];
                string prefix;

                if (i == KivalasztottMenupont)
                {
                    prefix = ">>";
                    ForegroundColor = ConsoleColor.Black;
                    BackgroundColor = ConsoleColor.White;
                }
                else
                {
                    prefix = " ";
                    ForegroundColor = ConsoleColor.White;
                    BackgroundColor = ConsoleColor.Black;
                }

                KozepreIr($"{kivalasztott} {prefix}");
            }

            ResetColor();
        }

        public int SettingsRun()
        {
            ConsoleKey keyPressed;
            do
            {
                Clear();
                ValasztasiLehetosegek();
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                keyPressed = keyInfo.Key;

                if (keyPressed == ConsoleKey.UpArrow)
                {
                    KivalasztottMenupont--;
                    if (KivalasztottMenupont == -1)
                    {
                        KivalasztottMenupont = Valasztasok.Length - 1;
                    }
                }
                else if (keyPressed == ConsoleKey.DownArrow)
                {
                    KivalasztottMenupont++;
                    if (KivalasztottMenupont == Valasztasok.Length)
                    {
                        KivalasztottMenupont = 0;
                    }
                }

            } while (keyPressed != ConsoleKey.Enter);

            savedDifficulty = KivalasztottMenupont;

            while (Console.KeyAvailable)
            {
                Console.ReadKey(true);
            }

            return KivalasztottMenupont;
        }

        public int GetSavedDifficulty()
        {
            return savedDifficulty;
        }
    }
}
