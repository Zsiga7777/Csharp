using Feladat___02;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;


List<Game> games = new List<Game>();

void LoadData()
{
    using FileStream fs = new FileStream("./../../../data.json", FileMode.Open, FileAccess.Read, FileShare.None);
    using StreamReader sr = new StreamReader(fs, Encoding.UTF8);
    
    string jsonData = sr.ReadToEnd();
    games = JsonSerializer.Deserialize<List<Game>>(jsonData);
}

void WriteToConsole(string text, ICollection<Game> games)
{
Console.WriteLine(text);
Console.WriteLine(string.Join('\n', games));
}

void WriteSingleToConsole(string text, Game game)
{
Console.WriteLine(text);
Console.WriteLine(game);
}


LoadData();
WriteToConsole("Data", games);

/*
    Hány adat van a listában?
*/
int gamesCount = games.Count;

/*
    Keressük ki azon játékokat, melyek MMORPG tipusuak (genre).
*/
List<Game> mmorpgGames = games.Where(g => g.Genre == "MMORPG").ToList();

/*
Keressük ki azon játékokat, melyek 2013-ban jelentek meg.
*/
List<Game> gamesReleasdIn2013 = games.Where(g => DateTime.Parse(g.Release_date).Year == 2013).ToList();
/*
Keressük ki azon játékokat, melyek Darkflow Distribution KFR fejlesztett.
*/
List<Game> gamesMadeByDarkflow = games.Where(g => g.Developer == "Darkflow Software").ToList();
/*
Keressük ki hány shooter játék van a listában.
*/
int numberOfShooters = games.Count(g => g.Genre.ToLower() == "shooter");
/*
Van-e olyan játék melyet Cryptic Studios fejleszett?
*/
bool isThereAGameDevelopedByCryptic = games.Any(g => g.Developer == "Cryptic Studios");
/*
Keressük ki azon játékokat, melyek a címében (title) szerepel a ,,winter,, szó.
*/
List<Game> gamesWithTitleWinter = games.Where(g => g.Title.ToLower().Contains("winter")).ToList();
/*
Keressük ki a platformokat, de úgy, hogy mindegyik csak egyszer forduljon elő az eredménybe.
*/
List<string> platforms = games.Select(g => g.Platform).Distinct().ToList();
/*
Keressük ki , hogy típusonként (genre) hány játék van.
*/
List<Genre> numberOfGamesInEachGenre = games.GroupBy(g => g.Genre)
                                            .Select(g => new Genre
                                            {
                                                Name = g.Key,
                                                NumberOfGames = g.Count()
                                            })
                                            .ToList();
/*
Keressük ki az Electronic Arts álltal fejlesztett játékokat, melyek shooter típusúak.
*/
List<Game> shootersMadeByEA = games.Where(g => g.Genre.ToLower() == "shooter" && g.Developer == "Electronic Arts").ToList();

/*
Keressük ki a listában szereplő fejlesztők  játékainak címét.
*/
List<Developer> developersGames = games.GroupBy(g => g.Developer)
                                        .Select(g => new Developer
                                        {
                                            DeveloperName = g.Key,
                                            GamesName = g.Select(g => g.Title).ToList()
                                        }).ToList();
/*
Keressük ki azt a játékot mely legkorábban jelent meg.
*/
Game oldestGame = games.MinBy(g => DateTime.Parse(g.Release_date));
/*
Keressük ki azon játékok címét, melyeket az Ubisoft jelenített meg, 
a Blue Byte fejlesztett ki 2010 és 2015 közt.
*/

List<string> gamesMadeByUbisoft = games.Where(g => g.Publisher == "Ubisoft" && g.Developer == "Blue Byte" &&
                                                   DateTime.Parse(g.Release_date).Year >= 2010 && DateTime.Parse(g.Release_date).Year <= 2015)
                                        .Select(g => g.Title).ToList();
