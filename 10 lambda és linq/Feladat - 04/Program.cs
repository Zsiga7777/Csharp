﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;

List<Movie> LoadData()
{
    JsonSerializerOptions options = new JsonSerializerOptions
    {
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        PropertyNameCaseInsensitive = true,
        WriteIndented = true,
    };

    options.Converters.Add(new DateFormatConverter());

    FileStream fs = new FileStream("./../../../data.json", FileMode.Open, FileAccess.Read, FileShare.None);
    StreamReader sr = new StreamReader(fs, Encoding.UTF8);
    
    string jsonData = sr.ReadToEnd();
    return JsonSerializer.Deserialize<List<Movie>>(jsonData, options);

}

 void WriteToConsole(string text, ICollection<Movie> movies)
{
    Console.WriteLine(text);
    Console.WriteLine(string.Join('\n', movies));
}

 void WriteSingleToConsole(string text, Movie movie)
{
    Console.WriteLine(text);
    Console.WriteLine(movie);
}


List<Movie> movies = LoadData();
WriteToConsole($"Data ({movies.Count})", movies);

// 1 - Hány film adatát dolgozzuk fel?
int numberOfFilms = movies.Count;

// 2 - Mekkora bevételt hoztak a filmek Amerikában?
long usaIncome = movies.Where(m => m.USGross.HasValue)
                       .Sum(m => m.USGross.Value);

// long usaIncome = movies.Sum(m => m.USGross ?? 0);

// 3 - Mekkora bevételt hoztak a filmek Világszerte?
long worldWideIncome = movies.Where(m => m.WorldwideGross.HasValue)
                             .Sum(m => m.WorldwideGross.Value);



// 4 - Hány film jelent meg az 1990-es években?
int countOfMoviesIn90s = movies.Count(m => m.ReleaseDate.Year >= 1990 && m.ReleaseDate.Year < 2000);

// 5 - Hányan szavaztak összessen az IMDB-n?
long sumOfVotes = movies.Sum(m => m.IMDBVotes ?? 0);

// 6 - Hányan szavaztak átlagossan az IMDB-n?
double averageNumberOfVotes = movies.Average(m => m.IMDBVotes ?? 0);

// 7 - A filmek  világszerte átlagban mennyit hoztak a konyhára?
double averageWorldWideIncome = movies.Average(m => m.WorldwideGross ?? 0);


// 8 - Hány filmet rendezett 'Christopher Nolan' ?
int numberOfFilmsByNolan = movies.Count(m => m.Director?.ToLower() == "christopher nolan");

// 9 - Melyik filmeket rendezte 'James Cameron'?
List<Movie> filmsByCameron = movies.Where(m => m.Director?.ToLower() == "james cameron").ToList();

// 10 - Keresse ki a 'Fantasy' kaland (Adventure) zsáner kategóriájjú filmeket.
List<Movie> fantasyFilms = movies.Where(m => m.MajorGenre?.ToLower() == "adventure" && m.CreativeType?.ToLower() == "fantasy").ToList();

// 11 - Kik rendeztek akció (Action) filmeket és mikor?
List<ActionFilm> actionFilms = movies.Where(m => m.MajorGenre?.ToLower() == "action" && m.Director != null)
                                      .GroupBy(m =>m.Director)
                                      .Select(m => new ActionFilm
                                      {
                                            Director = m.Key,
                                            ReleaseYears = m.Select(m =>m.ReleaseDate).ToList()
                                      })
                                      .ToList();


// 12 - 'Paramount Pictures' horror filmjeinek cime?
List<string> horrorMoviesByParamount = movies.Where(m => m.MajorGenre?.ToLower() == "horror" && m.Distributor?.ToLower() == "paramount pictures")
                                             .Select(m => m.Title)
                                             .ToList();

// 13 - Van-e olyan film melyet 'Tom Crusie' rendezett?
bool anyFilmByTomCruise = movies.Any(m => m.Director?.ToLower() == "tom cruise");

// 14 - A 'Little Miss Sunshine' filme mekkora össz bevételt hozott?
long? incomeOfLittleMissSunshine = movies.Where(m => m.Title?.ToLower() == "little miss sunshine")
                                       .Sum(m => m.USDVDSales + m.WorldwideGross + m.USGross);


// 15 - Hány olyan film van amely az IMDB-n 6 feletti osztályzatot ért el és a 'Rotten Tomatoes'-n pedig legalább 25-t?
int numberOfFilmsWithHigherRating = movies.Where(m => m.IMDBRating > 6 && m.RottenTomatoesRating >= 25)
                                          .Count();

// 16 - 'Michael Bay' filmjei átlagban mekkora bevételt hoztak?
double averageIncomeOFBaysMovies = movies.Where(m => m.Director?.ToLower() == "michael bay")
                                            .Average(m => m.USDVDSales ?? 0 + m.USGross ?? 0 + m.WorldwideGross ?? 0);

// 17 - Melyek azok a 'Michael Bay' a 'Walt Disney Pictures' által forgalmazott fimek melyek legalább 150min hosszúak.
List<Movie> moviesMadeByBayAndDisney = movies.Where(m => m.Director?.ToLower() == "michael bay" && 
                                                         m.Distributor?.ToLower() == "walt disney pictures" &&
                                                         m.RunningTime >= 150).ToList();

// 18 - Listázza ki a forgalmazókat úgy, hogy mindegyik csak egyszer jelenjen meg!
List<string> distributors = movies.Where(m => m.Distributor != null)
                                   .Select(m => m.Distributor)
                                   .Distinct() 
                                   .ToList();

// 19 - Rendezze a filmeket az 'IMDB Votes' szerint  növekvő sorrendbe.
List<Movie> orderedListByIMDBVotes = movies.OrderBy(m => m.IMDBVotes).ToList();

// 20 - Rendezze a filmeket címük szerint csökkenő sorrendbe!
List<Movie> orderedListByFilmNames = movies.OrderByDescending(m => m.Title).ToList();


// 21 - Melyek azok a filmek melyek hossza meghaladja a 120 percet?
List<Movie> moviesWithMoreThan120MinRunningTime = movies.Where(m => m.RunningTime > 120).ToList();

// 22 - Hány film jelent meg december hónapban?
int numberOfMoviesReleasdInDecember = movies.Count(m => m.ReleaseDate.Month == 12);

// 23 - Egyes besorolásokban (Rating) hány film található?
List<NumberFilmsGroupedByRating> numberOfFilmsInRatings = movies.Where(m => m.Rating != null)
                                                                .GroupBy(m => m.Rating)
                                                                .Select(m => new NumberFilmsGroupedByRating { 
                                                                RatingName = m.Key,
                                                                NumberOfFilms = m.Count()
                                                                }).ToList();

// 24 - Keresse ki azokat a filmeket melyeket 'Ron Howard' rendezett a 2000 években, 'PG-13' bsorolású, lagalább 80 perc hosszú és az IMDB legalább 6.5 átlagot ért el.
List<Movie> moviesMadeByRonHoward = movies.Where(m => m.Director?.ToLower() == "ron howard" && 
                                                      m.ReleaseDate.Year >= 2000 && m.ReleaseDate.Year < 2010 &&
                                                      m.Rating?.ToLower() == "pg-13" && 
                                                      m.RunningTime >=80 && m.IMDBRating >= 6.5
                                                      ).ToList();

// 25 - A 'Lionsgate' kiadónál kik rendeztek filmeket?
List<string> directorsDirectedMovieForLionsgate = movies.Where(m => m.Distributor?.ToLower() == "lionsgate" && m.Director != null)
                                                        .Select (m => m.Director).Distinct().ToList();

// 26 - Az 'Universal' forgalmazó átlagban mennyit kültött film forgatására?
double averageBudgetOfUniversalFilms = movies.Where(m => m.Distributor?.ToLower() == "universal")
                                                .Average(m => m.ProductionBudget ?? 0);

// 27 - Az 'IMDB Votes' alapján melyek azok a filmek, melyeket többen értékeltek min 30 000-n?
List<Movie> moviesWithMoreThan30000Votes = movies.Where(m => m.IMDBVotes >= 30000).ToList();

// 28 - Az 'American Pie' című filmnek hány része van?
int numberOfEpisodesOfAmericanPie = movies.Where(m => m.Title != null)
                                          .Count(m => m.Title.ToLower().Contains("american pie"));

// 29 - Van-e olyan film melynek a címében szerepel a 'fantasy' szó és a zsánere 'Adventure'?
bool anyAventureFilmsWithfantasíInTitle = movies.Where(m => m.Title != null)
                        .Any(m => m.MajorGenre?.ToLower() == "adventure" &&
                                  m.Title.ToLower().Contains("fantasy"));

// 30 - Átlagban hányan szavaztak az IMDB-n?
double averageNumberOfVotesOnIMDB = movies.Average(m => m.IMDBVotes ?? 0);

// 31 - Kik rendeztek a 'Warner Bros.' forgalmazónál dráma filmeket 1970 és 1975 közt melyre az 'IMDB Votes' alapján többen szavaztak az átlagnál?
List<string> directorsWhoDirectedMovieForWarner = movies.Where(m => m.Distributor?.ToLower() == "warner bros." &&
                                                                    m.Director != null && m.MajorGenre?.ToLower() == "drama" &&
                                                                    m.ReleaseDate.Year >= 1970 && m.ReleaseDate.Year <=1975 &&
                                                                    m.IMDBVotes >averageNumberOfVotesOnIMDB)
                                                         .Select(m => m.Director).ToList();

// 32 - Van e olyan film amely karácsony napján jelent meg?
bool anyFilmsReleasdOnChristmasDay = movies.Any(m => m.ReleaseDate.Month == 12 && m.ReleaseDate.Day == 25);

// 33 - 'Spider-Man' című filmek USA-ban mekkora bevételt hoztak?
long spiderManMoviesIncomeInTheUSA = movies.Where(m => m.Title != null && m.Title.ToLower().Contains("spider man"))
        .Sum(m => m.USDVDSales ?? 0 + m.USGross ?? 0);

// 34 - Keresse ki  szuperhősös (Super Hero) filmek címeit.
List<string> superHeroMoviesTitles = movies.Where(m => m.CreativeType?.ToLower() == "super hero")
                                            .Select (m => m.Title).ToList();
