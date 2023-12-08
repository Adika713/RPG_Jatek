using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace RPG_game
{
    internal class Menu
    {
        private int KivalasztottMenupont;
        private string[] Valasztasok;
        private string Prompt;

        public Menu(string prompt, string[] valasztasok)
        {
            Prompt = prompt;
            Valasztasok = valasztasok;
            KivalasztottMenupont = 0;
        }

        private void ValasztasiLehetosegek()
        {
            static void KozepreIr(string szoveg, ConsoleColor forecolor, ConsoleColor backcolor)
            {
                Console.Write(new string(' ', (Console.WindowWidth / 2) - (szoveg.Length / 2)));
                Console.ForegroundColor = forecolor;
                Console.BackgroundColor = backcolor;
                Console.WriteLine(szoveg);
                Console.ResetColor();
            }
            Console.WriteLine(Prompt);
            for (int i = 0; i < Valasztasok.Length; i++)
            {
                string kivalasztott = Valasztasok[i];
                string prefix;

                if (i == KivalasztottMenupont)
                {
                    prefix = ">>";
                }
                else
                {
                    prefix = " ";
                }

                KozepreIr($"{kivalasztott} {prefix}", i==KivalasztottMenupont?ConsoleColor.Black : ConsoleColor.White, i == KivalasztottMenupont ? ConsoleColor.White : ConsoleColor.Black);
            }

            ResetColor();
        }


        public int Run()
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
                else if(keyPressed == ConsoleKey.DownArrow)
                {
                    KivalasztottMenupont++;
                    if (KivalasztottMenupont == Valasztasok.Length)
                    {
                        KivalasztottMenupont = 0;
                    }
                }

            } while (keyPressed != ConsoleKey.Enter);
            return KivalasztottMenupont;
        }
    }
}
