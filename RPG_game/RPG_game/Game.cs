using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Media;
using System.Windows.Media;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using Newtonsoft.Json;

namespace RPG_game
{
    internal class Game
    {
        public void Start()
        {
            Character playerCharacter = new Character();

            MediaPlayer player = new MediaPlayer();
            player.Open(new Uri($"{AppDomain.CurrentDomain.BaseDirectory}/sounds/music.wav", UriKind.RelativeOrAbsolute));

            player.Volume = 0.25;

            player.Play();


            string prompt = @"██████╗ ██████╗  █████╗  ██████╗  ██████╗ ███╗   ██╗███████╗     ██████╗ █████╗ ██████╗ ████████╗██╗██╗   ██╗███████╗
██╔══██╗██╔══██╗██╔══██╗██╔════╝ ██╔═══██╗████╗  ██║██╔════╝    ██╔════╝██╔══██╗██╔══██╗╚══██╔══╝██║██║   ██║██╔════╝
██║  ██║██████╔╝███████║██║  ███╗██║   ██║██╔██╗ ██║███████╗    ██║     ███████║██████╔╝   ██║   ██║██║   ██║█████╗  
██║  ██║██╔══██╗██╔══██║██║   ██║██║   ██║██║╚██╗██║╚════██║    ██║     ██╔══██║██╔═══╝    ██║   ██║╚██╗ ██╔╝██╔══╝  
██████╔╝██║  ██║██║  ██║╚██████╔╝╚██████╔╝██║ ╚████║███████║    ╚██████╗██║  ██║██║        ██║   ██║ ╚████╔╝ ███████╗
╚═════╝ ╚═╝  ╚═╝╚═╝  ╚═╝ ╚═════╝  ╚═════╝ ╚═╝  ╚═══╝╚══════╝     ╚═════╝╚═╝  ╚═╝╚═╝        ╚═╝   ╚═╝  ╚═══╝  ╚══════╝
                                                                                                                     
Üdvözöllek a Dragon's Captive: A Hero's Tale játékban. Mit szeretnél csinálni?";

            string[] Valasztasok = { "Karakter létrehozása", "Karakter információk", "Karakter mentése", "Karakter betöltése", "Beállítások", "Kilépés" };
            Menu mainMenu = new Menu(prompt, Valasztasok);
            int kivalasztottmenupont = mainMenu.Run();


            switch (kivalasztottmenupont)
            {
                case 0:
                   RunGame();
                    break;
                case 1:
                    ShowStats(playerCharacter);
                    break;
                case 2:
                    SaveCharacter(playerCharacter);
                    break;
                case 3:
                    LoadCharacter(playerCharacter);
                    break;
                case 4:
                    Settings();
                    break;
                case 5:
                    ExitGame();
                    break;
            }


        }

        public void RunGame()
        {
            Clear();
            SoundPlayer player = new SoundPlayer();
            player.Stop();



            Console.Write("Mi legyen a hős neve: ");
            string karakterNev = Console.ReadLine();

            Clear();
            TypeWriterEffect($"Egykoron, a békés Zafira Királyságban élt egy gyönyörű hercegnő, Alara. Alara volt az egyetlen örökös a királyi trónra, és a nép kedvence. Azonban a békételen időknek leple alatt, Drak'zul, a rettegett sárkány, elragadta Alarát.");

            TypeWriterEffect($"\nA király elkeseredve hirdette meg az országban, hogy aki visszahozza elveszett lányát, az gazdagon meg lesz jutalmazva. Sok bátor hős próbálkozott, de egyikük sem tért vissza. A sárkány fészke a Borús Hegyek mélyén volt, és a bátorság és hűség nélkül senki sem merészkedett odáig.");

            TypeWriterEffect($"\nEgy nap egy fiatal kardforgató, név szerint {karakterNev}, állt elő, hogy felvállalja a küldetést. {karakterNev} sosem hajolt meg a félelem előtt, és a hűség volt az ő vezérlő elve. Édesanyja egykoron egy bölcs varázslónő volt, és {karakterNev} megörökölte a varázserőt. Egy kis csoport hűséges társat gyűjtött maga köré, hogy segítsenek neki az úton.");

            TypeWriterEffect($"\nElindultak a Borús Hegyek felé, az elágazó ösvényeken keresztül és a sűrű erdőkön át. Éjjelente, amikor a csillagok ragyogtak az égen, {karakterNev} gyakran látott álmokat Alara kéréséről. A hercegnő könyörögve fordult felé, kijelentve, hogy az ő sorsuk egybefonódik.");


            TypeWriterEffect("Nyomj egy gombot a folytatáshoz...");
            ReadKey(true);
            Clear();

            Character jatekos = new Character();

            if (savedDifficulty == 0)
            {
                jatekos = new Character()
                {
                    Szint = 1,
                    EXP = 0,
                    Nev = karakterNev,
                    Eletero = 200,
                    Sebzes = 15,
                    Armor = 10
                };
            }
            else if (savedDifficulty == 1)
            {
                jatekos = new Character()
                {
                    Szint = 1,
                    EXP = 0,
                    Nev = karakterNev,
                    Eletero = 150,
                    Sebzes = 13,
                    Armor = 7
                };
            }
            else if (savedDifficulty == 2)
            {
                jatekos = new Character()
                {
                    Szint = 1,
                    EXP = 0,
                    Nev = karakterNev,
                    Eletero = 125,
                    Sebzes = 10,
                    Armor = 5
                };
            }
            else if (savedDifficulty == 3)
            {
                jatekos = new Character()
                {
                    Szint = 1,
                    EXP = 0,
                    Nev = karakterNev,
                    Eletero = 100,
                    Sebzes = 5,
                    Armor = 0
                };
            }




            ShowStats(jatekos);

            ReadKey(true);

            Start();

            static void TypeWriterEffect(string text)
            {
                foreach (char c in text)
                {
                    Console.Write(c);
                    Thread.Sleep(1); //Alap - 50
                }
                Console.WriteLine();
            }
        }

        private void NewCharacter(Character character)
        {
            Clear();
            Console.Write("Add meg a karaktered nevét: ");
            character.Nev = Console.ReadLine();
            Console.Write("Add meg a karaktered életerejét: ");
            character.Eletero = Convert.ToInt32(Console.ReadLine());
            Console.Write("Add meg a karaktered sebzését: ");
            character.Sebzes = Convert.ToInt32(Console.ReadLine());
            Console.Write("Add meg a karaktered armorját: ");
            character.Armor = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Karakter sikeresen elkészítve! Nyomj egy gombot a folytatáshoz...");
            ReadKey(true);
            Start();
        }

        private void ShowStats(Character character)
        {
            Clear();
            if (string.IsNullOrEmpty(character.Nev))
            {
                Console.WriteLine("Nincs ilyen karaktered. Csinálj előszőr egy karaktert.");
            }
            else
            {
                character.DisplayInfo();
            }
            Console.WriteLine("Nyomj egy gombot a folytatáshoz...");
            ReadKey(true);
            Start();
        }

        private void SaveCharacter(Character character)
        {
            Clear();
            if (character.Nev == string.Empty)
            {
                Console.WriteLine("Nincs ilyen karaktered. Csinálj előszőr egy karaktert.");
                ReadKey(true);
                Start();
                return;
            }
            else
            {
                string json = JsonConvert.SerializeObject(character);
                File.WriteAllText("character.json", json);

                Console.WriteLine("Karakter sikeresen elmentve");
                Console.WriteLine("Nyomj egy gombot a folytatáshoz...");
                ReadKey(true);
                Start();
            }
        }


        private void LoadCharacter(Character character) {
            Clear();
            try
            {
                string json = File.ReadAllText("character.json");
                character = JsonConvert.DeserializeObject<Character>(json);

                Console.WriteLine("Karakter sikeresen betöltve!");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Nem található elmentett karakter. Készíts egy új karaktert majd mentsd el.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hiba a karakter betöltése során: {ex.Message}");
            }
            ReadKey(true);
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
