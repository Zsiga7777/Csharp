
using Models;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace MMOGameApp
{
    public static class Menu
    {
        public static async Task StarterPageAsnyc()
        {
            List<string> options = new List<string> 
            {
                "Meglévő játékok listázása", "Új játék hozzáadása", "Meglévő játék módosítása"
            };
            int selectedOption = MovementInMenu(options);
            switch (selectedOption)
            {
                case -1:
                    {
                        return;
                    }
                case 0:
                    {
                        await ListGamesAsnyc();
                        break;
                            
                    }
                case 1:
                   Game game = await PostNewGameAsync();
                    Console.WriteLine($"{(game.Id > 0 ? "Sikerült" : "Nem sikerült")} a játék hozzáadása.");
                    await Task.Delay( 3000 );
                    await StarterPageAsnyc();
                    break;
                case 2:
                    {
                        await SecondMenuAsync();
                             break;
                    }

            }

             
        }
        public static async Task SecondMenuAsync()
        {
            Console.Clear();
            int id = ExtendentConsole.ReadInteger(0, "Kérem a kiválasztani kíván játék azonosítóját: ");
            Game game = await MMOGamesService.GetByIdAsnyc(id);
            if (game is null)
            {
                Console.WriteLine("Nem létező azonosítót adott meg.");
                await Task.Delay(2000);
                await SecondMenuAsync();
            }
            else
            {
                AppState.SetGame(game);

                await UpdateOrDeleteMenuAsync();
            }
        }

        public static async Task UpdateOrDeleteMenuAsync()
        {
            int selectedOption = MovementInMenu(["Játék törlése", "Játék módosítása"]);
            switch (selectedOption)
            {
                case -1: 
                    {
                        return;
                    }
                case 0:
                    {
                       await DeleteAsync();
                        break;
                    }
                case 1:
                    {
                        await UpdateAsync();
                        break;
                     }
            }
        }

        private static int MovementInMenu(List<string> options)
        {
            int index = 0;
            ConsoleKeyInfo keyinfo;
            do
            {
                WriteMenu(options, index);
                Console.WriteLine("felfele lépéshez felfelenyíl, lefele lépéhez lefelenyíl, kiválasztáshoz enter, kilépéshez e");
                keyinfo = Console.ReadKey();
                if (keyinfo.Key == ConsoleKey.UpArrow)
                {
                    if (index - 1 < 0)
                    {
                        index = options.Count - 1;
                    }
                    else
                    {
                        index--;
                    }
                }
                else if (keyinfo.Key == ConsoleKey.DownArrow)
                {
                    if (index + 1 > options.Count - 1)
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
                    return index;
                }
                else if (keyinfo.Key == ConsoleKey.E)
                {
                    return -1;
                }
            } while (true);
        }

        private static void WriteMenu(List<string> options, int selected)
        { 
            Console.Clear();
            for(int i = 0;i < options.Count;i++)
            {
                if (i == selected)
                { 
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine(options[i]);
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine($"{options[i]}");
                }
            }
        }

        private static async Task ListGamesAsnyc()
        {
            int page = 0;
            Dictionary<int, List<Game>> games = await MMOGamesService.GetFiveGamesAsnyc(page);
            WriteFiveGames(games.First().Value);
            do
            {
                page = games.Keys.First();
                char direction = ExtendentConsole.ReadChar("B(backwards), E(exit), F(forward)", ['b', 'B', 'e', 'E', 'f', 'F']);
                Console.Clear();
                if (direction == 'e' || direction == 'E')
                {
                    return;
                }
                else if (direction == 'b' || direction == 'B')
                {
                    page--;
                }
                else
                {
                    page++;
                }
                games = await MMOGamesService.SendGetRequestAsync<Dictionary<int, List<Game>>>("api/game/get-five", page);
                WriteFiveGames(games.First().Value);
            }while (true);
        }

        private static void WriteFiveGames(List<Game> games)
        {
            foreach (Game game in games)
            {
                Console.WriteLine(game);
            }
        }

        private static async Task<Game> PostNewGameAsync()
        { 
            Console.Clear ();
            Game game = GetGameData();
            game = await MMOGamesService.PostNewAsnyc(game);
            return game;
        }

        private static Game GetGameData()
        { 
            Game game = new Game();

            Console.WriteLine("Kérem a játék url-jét: ");
            game.Game_url = Console.ReadLine();

            Console.WriteLine("Kérem a játék megjelenési dátumát: ");
            game.Release_date = Console.ReadLine();

            Console.WriteLine("Kérem a játék kiadóját: ");
            game.Publisher = Console.ReadLine();

            Console.WriteLine("Kérem a játék thumbnail-jét: ");
            game.Thumbnail = Console.ReadLine();

            Console.WriteLine("Kérem a játék nevét: ");
            game.Title = Console.ReadLine();

            Console.WriteLine("Kérem a játék rövid leírását: ");
            game.short_Description = Console.ReadLine();

            Console.WriteLine("Kérem a játék műfaját: ");
            game.Genre = Console.ReadLine();

            Console.WriteLine("Kérem a játék felületét: ");
            game.Platform = Console.ReadLine();

            Console.WriteLine("Kérem a játék fejlesztőjét: ");
            game.Developer = Console.ReadLine();

            Console.WriteLine("Kérem a játék profil url-jét: ");
            game.Profile_url = Console.ReadLine();

            return game;
        }

        private static async Task DeleteAsync()
        {
            char option = ExtendentConsole.ReadChar("Biztos Benne (Y/N)?: ", ['y', 'Y', 'n', 'N']);
            if (option == 'n' || option == 'N')
            {
                await StarterPageAsnyc();
            }

            bool result = await MMOGamesService.DeleteByIdAsnyc(AppState.GetId());
            if (result)
            {
                AppState.Clear();
            }
            Console.WriteLine($"\n{(result ? "Sikrült" : "Nem sikerült")} a törlés.");
            await Task.Delay(3000);

            await StarterPageAsnyc();
        }

        private static async Task UpdateAsync()
        {
            Console.Clear();
            Console.WriteLine("Ha valamelyik adatot nem szeretné módosítani, nyomjon entert.");

            Game updatedGameData = GetGameData();
            AppState.Update(updatedGameData);

           await MMOGamesService.UpdateAsnyc(AppState.GetGame());

            Console.WriteLine("Sikerült a frissítés.");
            await Task.Delay(3000);
            await StarterPageAsnyc();
        }
    }
}
