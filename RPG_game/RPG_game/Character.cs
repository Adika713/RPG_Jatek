using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace RPG_game
{
    internal class Character
    {
        public int Szint { get; set; }
        public int EXP { get; set; }
        public string Nev { get; set; }
        public int Eletero { get; set; }
        public int Sebzes { get; set; }
        public int Armor { get; set; }


        public void DisplayInfo()
        {
            Console.WriteLine($"Név: {Nev}");
            Console.WriteLine($"Szint: {Szint}");
            Console.WriteLine($"EXP: {EXP}");
            Console.WriteLine($"Életerő: {Eletero}");
            Console.WriteLine($"Sebzés: {Sebzes}");
            Console.WriteLine($"Armor: {Armor}");
        }
    }
}
