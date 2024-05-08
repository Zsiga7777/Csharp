
namespace Osszefoglalo
{
    public static class Menus
    {
        public static async Task MainMenuAsync()
        { 
            do 
            {
                int selectedOption = ReusableMenu(["Új üzenet hozzáadása","Üzenet törlése","Üzenet küldése","Jelentés készítése"]);
                if (selectedOption == -1)
                {
                    break;
                }

                switch (selectedOption)
                {
                    case 0:
                        await DataService.CreateNewMessage();
                        break;
                }

            } 
            while (true);
        }

        public static int ReusableMenu<T>(List<T> options)
        {
            int index = 0;
            ConsoleKeyInfo keyinfo;
            do
            {
                ConsoleFunctions.WriteMenu(options, index);
                Console.WriteLine("\nfelfele lépéshez felfelenyíl, lefele lépéhez lefelenyíl, kiválasztáshoz enter, kilépéshez e");
                keyinfo = Console.ReadKey();
                if (keyinfo.Key == ConsoleKey.UpArrow)
                {
                    if (index - 1 < 0)
                    {
                        index = options.Count-1;
                    }
                    else
                    {
                        index--;
                    }
                }
                else if (keyinfo.Key == ConsoleKey.DownArrow)
                {
                    if (index + 1 > options.Count)
                    {
                        index = 0;
                    }
                    else
                    {
                        index++;
                    }
                }
                
                else if (keyinfo.Key == ConsoleKey.Enter)
                {
                    return index ;
                }
                else if (keyinfo.Key == ConsoleKey.E)
                {
                    return -1;
                }
            } while (true);
        }
    }
}

    