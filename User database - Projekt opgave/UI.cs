using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User_database___Projekt_opgave
{
    internal class UI
    {
        public static void opret()
        {
            ClearConsole();
            List<string> users = ReadFileContens();
            List<string> telefonnummre = new List<string>();
            foreach (string user in users)
            {
                string[] array = user.Split(" | ");
                telefonnummre.Add(array[0]);
            }

            Console.Write("\tTelefon nr\t\t:  ");
            string tlf = Console.ReadLine() ?? "";
            int telefon;
            if (!int.TryParse(tlf, out telefon)) //tjekker om telefon nummeret indeholder andet end tal
            {
                Console.WriteLine("\tTelefon nr er ikke gyldigt!");
                return;
            }
            if (tlf.Length != 8) //tjekker om telefon nummeret er 8 cifre langt
            {
                Console.WriteLine("\tTelefon nr er ikke gyldigt!");
                return;
            }
            if (telefonnummre.Contains(tlf)) //tjekker om telefon nummeret allerede existere í systemet
            {
                Console.WriteLine("\tTelefon nr findes allerde!");
                return;
            }
            Console.Write("\tFor- og efternavn\t:  ");
            string navn = Console.ReadLine() ?? "";
            Console.Write("\tAdresse\t\t\t:  ");
            string adresse = Console.ReadLine() ?? "";
            Console.Write("\tPostnr\t\t\t:  ");
            string postnr = Console.ReadLine() ?? "";
            if (postnr.Length != 4)
            {
                Console.WriteLine("\tPostnr er ikke gyldigt!");
                return;
            }
            Console.Write("\tBy\t\t\t:  ");
            string by = Console.ReadLine() ?? "";
            Console.Write("\tEmail\t\t\t:  ");
            string email = Console.ReadLine() ?? "";
            if (!email.Contains('@') && !email.Contains('.'))
            {
                Console.WriteLine("\tEmail er ikke gyldig!");
                return;
            }
            string guest = tlf + " | " + navn + " | " + adresse + " | " + postnr + " | " + by + " | " + email;
            users.Add(guest);

            WriteToFile(users);
        }
        public static void fjern()
        {
            ClearConsole();
            List<string> users = ReadFileContens();

            for (int i = 0; i < users.Count; i++)
            {
                Console.WriteLine("\t" + i + ":\t" + users[i]);
            }
            Console.WriteLine("\tHvilket nummer har useren du vil slette?");
            string removeSearch = Console.ReadLine() ?? "";
            int position;
            if (removeSearch != "")
            {
                return;
            }
            if (!int.TryParse(removeSearch, out position))
            {
                Console.WriteLine("\tDu indstatte ikke en gyldig position.");
                return;
            }
            if (position > users.Count)
            {
                Console.WriteLine("\tDu indstatte ikke en gyldig position.");
                return;
            }

            Console.WriteLine($"\t{users[position]} er nu slettet.");
            users.Remove(users[position]);

            WriteToFile(users);
        }
        public static void find()
        {
            ClearConsole();
            List<string> users = ReadFileContens();

            List<string> telefonnummre = new List<string>();
            List<string> navne = new List<string>();
            foreach (string user in users)
            {
                string[] array = user.Split(" | ");
                telefonnummre.Add(array[0]);
                navne.Add(array[1]);
            }

            Console.Write("\tTryk [T] for at søge efter et telefon nummer eller [N] for at søge efter et navn.");
            var input = Console.ReadKey();
            ClearConsole();
            switch (input.Key)
            {
                case ConsoleKey.T:
                    Console.Write("\tSkriv det telefon nummer du gerne vil søge efter: ");
                    string telefon = Console.ReadLine() ?? "";
                    Console.WriteLine("\n");
                    int tlf;
                    if (!int.TryParse(telefon, out tlf))
                    {
                        Console.WriteLine("\tTelefon nr er ikke gyldigt!");
                        return;
                    }
                    if (telefon.Length != 8)
                    {
                        Console.WriteLine("\tTelefon nr er ikke gyldigt!");
                        return;
                    }
                    foreach (string nummer in users)
                    {
                        if (nummer.Contains(telefon, StringComparison.OrdinalIgnoreCase))
                        {
                            Console.WriteLine("\t" + nummer);
                        }
                    }
                    break;
                case ConsoleKey.N:
                    Console.Write("\tSkriv det navn du gerne vil søge efter:");
                    string navn = Console.ReadLine() ?? "";
                    Console.WriteLine("\n" +
                        "\n" +
                        "\n");
                    foreach (string name in users) 
                    {
                        
                        if (name.Contains(navn, StringComparison.OrdinalIgnoreCase))
                        {
                            Console.WriteLine("\t" + name);
                        }
                    }
                    break;
            }

        }
        public static void visalle()
        {
            ClearConsole();
            List<string> users = ReadFileContens();

            int length = users.Count;
            Console.WriteLine($"\tDer er {length} users i systemet" +
                $"\n");
            int i = 0;
            foreach (string user in users)
            {
                Console.WriteLine($"\t{user}");

                i++;
                if (i % 15 == 0)
                {
                    Console.Write("\tTryk [ENTER] for at vise flere linjer, og tryk [ESC] for at forlade visning: ");
                        var input = Console.ReadKey();
                    switch (input.Key)
                    {
                        case ConsoleKey.Enter:
                            ClearConsole();
                            Console.WriteLine($"\tDer er {length} users i systemet" +
                                $"\n");
                            break;
                        case ConsoleKey.Escape:
                            return;
                    }
                }
            }

        }
        public static void quit()
        {
            UI.ClearConsole();
            Console.Write("\tQuitting program");
            System.Threading.Thread.Sleep(1000); //wait 1 second
            Console.Write('.');
            System.Threading.Thread.Sleep(1000); //wait 1 second
            Console.Write('.');
            System.Threading.Thread.Sleep(1000); //wait 1 second
            Console.Write('.');
            System.Threading.Thread.Sleep(1000); //wait 1 second
        }

        //-------------------------------------------------------------------------------------------------------------
        //      Repeats

        private static List<string> ReadFileContens() //læser fra file "users.txt"
        {
            string[] user = File.ReadAllLines("Users.txt");
            List<string> users = new List<string>(user);
            return users;
        }
        private static void WriteToFile(List<string> users) //udskirver til filen "users.txt"
        {
            File.WriteAllText("Users.txt", String.Join("\n", users));
        }
        public static void ClearConsole()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            UI.BannerMessage();
        }
        public static void ShowOptions()
        {
            Console.WriteLine("\n" +
                "\n");
            InitialShowOptions();
        }
        public static void InitialShowOptions()
        {
            Console.WriteLine("\tTryk [O] for at oprette en bruger, [F] for at søge efter et tlf. nr. \n" +
                "\t[V] for at vise alle brugere, [Q] for at forlade programmet");
            Console.Write("\t");
        }
        public static void BannerMessage()
        {
            string banner = "<<<   Christian Mørk Information Systems - Gæste-registreing V 1.0    >>>";
            Console.SetCursorPosition((Console.WindowWidth - banner.Length) / 2, Console.CursorTop);
            Console.WriteLine(banner +
                "\n");

        }
    }
}
