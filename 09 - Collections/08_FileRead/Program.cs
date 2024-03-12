// 1-es feladat
using Custom.Library.ConsoleExtensions;

List<DanceTypeAndCoupleNames> couples = await FileService.GetDanceTypeAndCoupleNames("tancrend.txt");

// 2-es feladat
string firstDance = couples.First().DanceName;
string lastDance = couples.Last().DanceName;
Console.WriteLine($"Az első tánc: {firstDance}, az utolsó: {lastDance}");

// 3-as feladat
int numberOfCouplesDancedSamba = couples.Count(x => x.DanceName.ToLower() == "samba");
Console.WriteLine($"\nA szambát bemutató párok száma: {numberOfCouplesDancedSamba}");

// 4-es feladat
List<string> vilmaDances = couples.Where(x => x.GirlName.ToLower() == "vilma").Select(x => x.DanceName).ToList();
Console.WriteLine("\nVilma táncai: ");
vilmaDances.WriteCollectionToConsole();

// 5-ös feladat
string enteredDanceName = ExtendentConsole.ReadString("\nKérem egy tánc nevét: ");

string? vilmasPartnerName = couples.FirstOrDefault(x => x.DanceName.ToLower() == enteredDanceName.ToLower() && x.GirlName.ToLower() == "vilma")?.BoyName;

Console.WriteLine($"\n{(vilmasPartnerName == null ? $"Vilma nem táncolt {enteredDanceName}-t." : $"A {enteredDanceName} bemutatóján Vilma párja {vilmasPartnerName} volt.")}");

// 6-os feladat
List<string> girlsNames = couples.Select(x => x.GirlName).Distinct().ToList();
List<string> boysNames = couples.Select(x => x.BoyName).Distinct().ToList();
await FileService.WriteListToFileAsync(girlsNames, boysNames, "szereplok");

// 7-es feladat
Dictionary<string, int> boys = boysNames.ToDictionary(x => x, x => couples.Count(y =>y.BoyName == x));
Dictionary<string, int> girls = girlsNames.ToDictionary(x => x, x => couples.Count(y => y.GirlName == x));

int mostBoyAppearance = boys.Max(x => x.Value);
int mostGirlsAppearance = girls.Max(x => x.Value);

List<string> boyNameWithMostAppearance = boys.Where(x => x.Value == mostBoyAppearance).Select(x => x.Key).ToList();
List<string> girlNameWithMostAppearance = girls.Where(x => x.Value == mostGirlsAppearance).Select(x => x.Key).ToList();

Console.WriteLine($"\nA legtöbbször szereplő fiú(k):");
boyNameWithMostAppearance.WriteCollectionToConsole();

Console.WriteLine($"\nA legtöbbször szereplő lány(ok):");
girlNameWithMostAppearance.WriteCollectionToConsole();