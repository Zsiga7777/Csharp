using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Feladat___01
{
    internal class Program
    {
        private static List<Player> _players = new List<Player>();

        private static void LoadData()
        {
            using (FileStream fs = new FileStream("./../../../data.json", FileMode.Open, FileAccess.Read, FileShare.None))
            {
                using (StreamReader sr = new StreamReader(fs, Encoding.UTF8))
                {
                    string jsonData = sr.ReadToEnd();

                    _players = JsonConvert.DeserializeObject<List<Player>>(jsonData);
                }
            }
        }

        private static void WriteToConsole(string text, ICollection<Player> players)
        {
            Console.WriteLine(text);
            Console.WriteLine(string.Join('\n', _players));
        }

        private static void WriteToConsole(string text, Player player)
        {
            Console.WriteLine(text);
            Console.WriteLine(player);
        }

        static void Main(string[] args)
        {
            LoadData();
            WriteToConsole("Data", _players);

            //feladat 01: Hány játékos van az adatbázisban?
            int numberOfPlayers = _players.Count;

            //játékosok átlagmagasságát
            double averageHeightOfPlayers = _players.Average(x => x.Height);

            //ki a legalacsonyabb játékos?
            string nameOfShortestPlayer = _players.MinBy(p => p.Height).Name;

            //Keressük ki azokat a játékosokat, akik 1980-ban születtek
            //List<Player> playersBornIn1980 = _players.Where(p => DateTime.Parse(p.Birthday).Year == 1980).ToList();
            //List<Player> playersBornIn1980 = _players.Where(p => p.Birthday.Substring(0,4) == "1980").ToList();
            //List<Player> playersBornIn1980 = _players.Where(p => p.Birthday.StartsWith("1980")).ToList();
            //List<Player> playersBornIn1980 = _players.Where(p => p.Birthday.Contains("1980")).ToList();
            //List<Player> playersBornIn1980 = _players.Where(p => int.Parse(x.Birthday.Split('-'[0]) == 1980) .ToList();
            //List<Player> playersBornIn1980 = _players.Where(p => p.Birthday.Split('-'[0]) == "1980") .ToList();

            //Rendezzük a játékosokat név szerint csökkenő sorrendbe és magasság szerint csökkenő sorrendbe
            List<Player> orderedList = _players.OrderByDescending(p => p.Name)
                                                .ThenByDescending(p => p.Height)
                                                .ToList();

            //Keressük ki,hogy posztonként hány játékos van?
            List<Position> numberOfPositions = _players.GroupBy(p => p.Position)
                                                        .Select(p => new Position
                                                        {
                                                            PositionName = p.Key,
                                                            NumberOfPlayers = p.Count()
                                                        })
                                                        .ToList();

            //Kik azok a játékosok, akik az 1990-es években születtek?
            /* List<string> playersBornInThe90S = _players.Where(p => DateTime.Parse(p.Birthday).Year > 1989 && DateTime.Parse(p.Birthday).Year < 2000)
                                                       .Select(p => p.Name).ToList();*/
            List<string> playersBornInThe90S = _players.Where(p => DateTime.Parse(p.Birthday).Year > 1989 )
                                                       .Where(p =>DateTime.Parse(p.Birthday).Year < 2000)
                                                       .Select(p => p.Name)
                                                       .ToList();

            //rendezzük a játékosokat csapatonként.
            List<Team> playersByTeam = _players.GroupBy(p => p.Club)
                                               .Select(p => new Team
                                               {
                                                   Name = p.Key,
                                                   PlayersName = p.Select(p => p.Name).ToList()
                                               })
                                               .ToList();

            foreach (var item in playersByTeam)
            {
                Console.WriteLine(item.Name);

                foreach (var item1 in item.PlayersName)
                {
                    Console.WriteLine($"- {item1}");
                }
                Console.WriteLine();
            }

            /*foreach (var item in playersByTeam)
            {
                Console.WriteLine(item);
            }*/

        }
    }
}
