using Models;
using System.Diagnostics.Metrics;
using System.Runtime.InteropServices;

namespace BeerApp
{
    public static class Menu
    {
        public static async Task StartingPage()
        {
            Console.WriteLine("1 - új sör hozzáadása \n2 - jelenlegi sör módosítása\n3 - összes sör megtekintése(kliens)\n4 - összes sör megtekintése(szerver)");
            int enteredNumber = ExtendentConsole.ReadInteger(1, 4, "Kérem, válasszon: ");

            switch (enteredNumber)
            {
                case 1:
                    bool result = await PostNewBeer();
                    Console.WriteLine($"{(result ? "sikerült" : "nem sikerült")} a hozzáadás");
                    break;
                case 2:
                    await Main();
                    break;
                case 3:
                    await ListAllBeers();
                    break;
                case 4:
                    await ListFiveBeersAsnyc();
                    break;

            }
        }
        public static async Task Main()
        {
            Console.Clear();

            int id = ExtendentConsole.ReadInteger("Adja meg a sör azonososítóját: ");

            Beer beer = await BeerService.GetByIdAsync(id);

            if (beer is null)
            {
                Console.WriteLine("Ezzel az azonosítóval nem létezik adat");
                await Task.Delay(3000);
                await Main();
            }
            else
            {
                AppState.SetBeer(beer);

                await UpdateOrDelete();
            }

        }

        public static async Task UpdateOrDelete()
        {
            Console.Clear();

            Beer beer = AppState.GetBeer();
            beer.WriteToConsole();

            Console.WriteLine();
            Console.WriteLine("1 - Törlés");
            Console.WriteLine("2 - Szerkesztés");
            int option = ExtendentConsole.ReadInteger(1, 2, "Válaszzon műveletet: ");
            switch (option)
            {
                case 1:
                    {
                        await DeleteAsync();
                        break;
                    }
                case 2:
                    {
                        await UpdateAsync();
                        break;
                    }
            }
        }

        private static async Task DeleteAsync()
        {
            char option = ExtendentConsole.ReadChar("Biztos Benne (Y/N)?: ", ['y', 'Y', 'n', 'N']);
            if (option == 'n' || option == 'N')
            {
                return;
            }

            bool isSucces = await BeerService.SendDeleteRequestAsync("api/beer/delete", AppState.GetId());
            if (isSucces)
            {
                AppState.Clear();
            }
            Console.WriteLine($"\n{(isSucces ? "Sikerült" : "Nem sikerült")} a törlés.");
            await Task.Delay(3000);

            await Main();
        }

        private static async Task UpdateAsync()
        {
            Console.Clear();

            Beer updatedBeerData = GetUpdatedBeerData();


            await BeerService.SendPutRequestAsync("api/beer/update", updatedBeerData);

            Console.WriteLine($"Sikerült a módosítás.");
            await Task.Delay(3000);

            await Main();
        }

        private static Beer GetUpdatedBeerData()
        {
            Beer beer = new Beer();

            Console.Write("Nev (Ha nem szeretne megvaltoztatni nyomjon egy enter gombot): ");
            beer.Name = Console.ReadLine();

            Console.Write("Kep (Ha nem szeretne megvaltoztatni nyomjon egy enter gombot): ");
            beer.Image = Console.ReadLine();

            double price = ExtendentConsole.ReadDouble(0, "Ár (Ha nem szeretne megvaltoztatni nyomjon egy enter gombot): ");
            beer.Price = $"${price}";

            AppState.Update(beer);

            return AppState.GetBeer();

        }

        private static async Task<bool> PostNewBeer()
        {
            Beer beer = new Beer();
            beer.Name = ExtendentConsole.ReadString("Kérem a sör nevét: ");
            double price = ExtendentConsole.ReadDouble(0, "Kérem a sör árát: ");
            beer.Price = $"${price}";
            beer.Image = ExtendentConsole.ReadString("Kérem a sör képének linkjét: ");
            double average = ExtendentConsole.ReadDouble(0, "Kérem az értékelés átlagát: ");
            int reviews = ExtendentConsole.ReadInteger(0, "Kérem az értékelések számát: ");
            beer.Rating = new Rating { Average = average, Reviews = reviews };

            bool result = await BeerService.SendPostRequestAsync("api/beer/create", beer);
            return result;
        }

        private static async Task ListAllBeers()
        {
            List<Beer> beers = await BeerService.SendGetRequestAsync<List<Beer>>("api/beer/get-all");
            bool exit = false;
            int idCounter = 0;

            Console.Clear();
            await Write5Beers(beers, idCounter);
            do
            {
                if (idCounter <= 0)
                {
                    char direction = ExtendentConsole.ReadChar("E(exit), F(forward)", ['e', 'E', 'f', 'F']);
                    Console.Clear();
                    if (direction == 'e' || direction == 'E')
                    {
                        return;
                    }
                    else
                    {
                        idCounter += 5;
                        await Write5Beers(beers, idCounter);
                    }
                }
                else if (idCounter >= 5 && idCounter < beers.Count - 6)
                {
                    char direction = ExtendentConsole.ReadChar("B(backwards), E(exit), F(forward)", ['b', 'B', 'e', 'E', 'f', 'F']);
                    Console.Clear();
                    if (direction == 'e' || direction == 'E')
                    {
                        return;
                    }
                    else if (direction == 'b' || direction == 'B')
                    {
                        idCounter -= 5;
                        await Write5Beers(beers, idCounter);

                    }
                    else
                    {
                        idCounter += 5;
                        await Write5Beers(beers, idCounter);
                    }
                }
                else if (idCounter >= beers.Count - 6)
                {
                    char direction = ExtendentConsole.ReadChar(" B(Backward), E(exit)", ['b', 'B', 'e', 'E']);
                    Console.Clear();
                    if (direction == 'e' || direction == 'E')
                    {
                        return;
                    }
                    else
                    {
                        idCounter -= 5;
                        await Write5Beers(beers, idCounter);
                    }
                }
            }
            while (!exit);

        }

        private static async Task Write5Beers(List<Beer> beers, int id)
        {
            int endId = id + 4;
            if (beers.Count - 1 <= endId)
            {
                endId = beers.Count - 1;
            }
            for (int i = id; i <= endId; i++)
            {
                Console.WriteLine(beers[i]);
            }
        }

        private static async Task ListFiveBeersAsnyc()
        {
            Dictionary<int, List<Beer>> beers = await BeerService.SendGetRequestAsync<Dictionary<int, List<Beer>>>("api/beer/get-five", 0);
            int pageNumber = 0;
            do
            {
                pageNumber = beers.Keys.First();
                char direction = ExtendentConsole.ReadChar("B(backwards), E(exit), F(forward)", ['b', 'B', 'e', 'E', 'f', 'F']);
                Console.Clear();
                if (direction == 'e' || direction == 'E')
                {
                    return;
                }
                else if (direction == 'b' || direction == 'B')
                {
                    pageNumber--;
                    beers = await BeerService.SendGetRequestAsync<Dictionary<int, List<Beer>>>("api/beer/get-five", pageNumber);
                    
                }
                else
                {
                    pageNumber++;
                    beers = await BeerService.SendGetRequestAsync<Dictionary<int, List<Beer>>>("api/beer/get-five", pageNumber);
                }
                await Write5BeersFromServerAsync(beers);
            } while (true);
        }
            private static async Task Write5BeersFromServerAsync(Dictionary<int, List<Beer>> beers)
                {
                    foreach (Beer beer in beers.First().Value)
                    {
                        Console.WriteLine(beer);
                    }
                }
    }
    
}




