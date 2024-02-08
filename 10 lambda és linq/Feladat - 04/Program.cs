using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

// 16 - 'Michael Bay' filmjei átlagban mekkora bevételt hoztak?

// 17 - Melyek azok a 'Michael Bay' a 'Walt Disney Pictures' által forgalmazott fimek melyek legalább 150min hosszúak.

// 18 - Listázza ki a forgalmazókat úgy, hogy mindegyik csak egyszer jelenjen meg!

// 19 - Rendezze a filmeket az 'IMDB Votes' szerint  növekvő sorrendbe.

// 20 - Rendezze a filmeket címük szerint csökkenő sorrendbe!

// 21 - Melyek azok a filmek melyek hossza meghaladja a 120 percet?

// 22 - Hány film jelent meg december hónapban?

// 23 - Egyes besorolásokban (Rating) hány film található?

// 24 - Keresse ki azokat a filmeket melyeket 'Ron Howard' rendezett a 2000 években, 'PG-13' bsorolású, lagalább 80 perc hosszú és az IMDB legalább 6.5 átlagot ért el.

// 25 - A 'Lionsgate' kiadónál kik rendeztek filmeket?

// 26 - Az 'Universal' forgalmazó átlagban mennyit kültött film forgatására?

// 27 - Az 'IMDB Votes' alapján melyek azok a filmek, melyeket többen értékeltek min 30 000-n?

// 28 - Az 'American Pie' című filmnek hány része van?

// 29 - Van-e olyan film melynek a címében szerepel a 'fantasy' szó és a zsánere 'Adventure'?

// 30 - Átlagban hányan szavaztak az IMDB-n?

// 31 - Kik rendeztek a 'Warner Bros.' forgalmazónál dráma filmeket 1970 és 1975 közt melyre az 'IMDB Votes' alapján többen szavaztak az átlagnál?

// 32 - Van e olyan film amely karácsony napján jelent meg?

// 33 - 'Spider-Man' című filmek USA-ban mekkora bevételt hoztak?

// 34 - Keresse ki  szuperhősös (Super Hero) filmek címeit.