using User_database___Projekt_opgave;

//string s = "Hello World";
//Console.SetCursorPosition((Console.WindowWidth - s.Length) / 2, Console.CursorTop);
//Console.WriteLine(s);
//File.WriteAllText("Users.txt", "");

UI.ClearConsole();
UI.InitialShowOptions();

do
{
    var input = Console.ReadKey();
    switch (input.Key)
    {
        case ConsoleKey.Q: //quit systemet
            UI.quit();
            return;
        case ConsoleKey.O: //opret en bruger ved at tjekke om tlf. nr. existere
            UI.opret();
            break;
        case ConsoleKey.F: //find en bruger ved at søge efter tlf. nr.
            UI.find();
            break;
        case ConsoleKey.V: //vis alle brugerer
            UI.visalle();
            break;
        case ConsoleKey.S: //fjern en bruger
            UI.fjern();
            break;
    }
    UI.ShowOptions();
} while (true);