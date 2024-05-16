
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
                        await DataService.CreateNewMessageAsync();
                        break;
                    case 1:
                        await DataService.DeleteMessageAsync();
                        break;
                    case 2:
                        await DataService.SendMessageAsync();
                        break;

                }

            } 
            while (true);
        }

        public static int ReusableMenu<T>(List<T> options)
        {
            int index = 0;
            int pageNumber = 0;
            ConsoleKeyInfo keyinfo;
            do
            {
                List<T> currentPage = options.Skip((pageNumber) * 10).Take(10).ToList();
                ConsoleFunctions.WriteMenu(currentPage, index);
                Console.WriteLine("\nfelfele lépéshez felfelenyíl, lefele lépéhez lefelenyíl, kiválasztáshoz enter, kilépéshez e");
                Console.WriteLine("előző oldal balranyíl, követkető oldal jobbranyíl");
                keyinfo = Console.ReadKey();
                if (keyinfo.Key == ConsoleKey.UpArrow)
                {
                    if (index - 1 < 0)
                    {
                        index = 0;
                    }
                    else
                    {
                        index--;
                    }
                }
                else if (keyinfo.Key == ConsoleKey.DownArrow)
                {
                    if (index + 1 + pageNumber * 10 >= options.Count)
                    {
                        index = 0;
                    }
                    else if (index == 9)
                    {
                        index = 0;
                    }
                    else
                    {
                        index++;
                    }
                }
                else if (keyinfo.Key == ConsoleKey.LeftArrow)
                {
                    if (pageNumber - 1 < 0 && options.Count > 10)
                    {
                        pageNumber = options.Count / 10;
                        index = 0;
                    }
                    else if (pageNumber - 1 < 0)
                    {
                        pageNumber = 0;
                        index = 0;
                    }
                    else
                    {
                        pageNumber--;
                        index = 0;
                    }
                }
                else if (keyinfo.Key == ConsoleKey.RightArrow)
                {
                    if (pageNumber + 1 >= options.Count / (double)10)
                    {
                        pageNumber = 0;
                        index = 0;
                    }
                    else
                    {
                        pageNumber++;
                        index = 0;
                    }
                }
                else if (keyinfo.Key == ConsoleKey.Enter)
                {
                    return index + pageNumber * 10;
                }
                else if (keyinfo.Key == ConsoleKey.E)
                {
                    return -1;
                }
            } while (true);
        }
    }
}

    