using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_game
{
    internal class Credits
    {
        public Credits() { }
        public static void RollCredits()
        {
            Console.Clear();
            Console.WriteLine("Ez a Dragon's Captive RPG játék konzolos megvalósítása.");
            Console.WriteLine("Készítette: Palkó Dávid, Szabó Gergely, Magyar Ádám");
            Console.ReadKey(true);

        }
    }
}
