//1.Tárolja el a fájlok tartalmát olyan adatszerkezetben, amivel a további feladatok 
//megoldhatók!
using Custom.Library.ConsoleExtensions;

List<Student> students = await FileService.GetStudentsAsync("szeptember.csv");

//2. Határozza meg, és írja ki a képernyőre, hogy a diákok összesen hány órát mulasztottak 
//ebben a hónapban. 
int sumOfMissings = students.Sum(x => x.MissedHours);
Console.WriteLine($"A tanulók összesen {sumOfMissings} órát hiányoztak.");

//3. Kérjen be a felhasználótól 
// egy napot 1 és 30 között
// egy tanuló nevét
int enteredDay = ExtendentConsole.ReadInteger(1,30,"Kérek egy napot 1 és 30 között: ");
string enteredName = ExtendentConsole.ReadString("Kérem egy tanuló nevét: ");

//4. Írja ki a képernyőre, hogy az előző feladatban beért tanulónak volt-e hiányzása! A „A 
//tanuló hiányzott szeptemberben” vagy „A tanuló nem hiányzott 
//szeptemberben” szöveget jelenítse meg
bool thisStudentMissedAnyDays = students.Any(x => x.Name == enteredName);
Console.WriteLine($"\n{(thisStudentMissedAnyDays ? "A tanuló hiányzott szeptemberben" : "A tanuló nem hiányzott szeptemberben")}");

//5. Írja ki a képernyőre azon tanulók nevét és osztályát a minta szerint, akik a 3. feladatban
//bekért napon hiányoztak! (Ha a 3. feladatot nem tudta megoldani, akkor a 19-ei nappal 
//dolgozzon!) Ha nem volt hiányzó, akkor a „Nem volt hiányzó” szöveget jelenítse 
//meg!
List<Student> studentsMissingOnThatDay = students.Where(x => x.StartingDay == enteredDay).ToList();
Console.WriteLine($"\n{(studentsMissingOnThatDay.Count != 0 ? $"Hiányzók 2017.09.{enteredDay}-n" : "Nem volt hiányzó")}");
studentsMissingOnThatDay.WriteCollectionToConsole();

//6. Készítsen összesítést, amely osztályonként fájlba írja a mulasztott órák számát! Az
//osszesites.csv nevű fájl tartalmazza az osztályt és a mulasztott órák számának 
//összegét
List<Class> classes = students.GroupBy(x => x.Class)
                               .Select(x => new Class
                               {
                                   ClassName = x.Key,
                                   NumberOfMissingHours = x.Sum(x => x.MissedHours)
                               }).ToList();
await FileService.WriteToFileAsync(classes, "osszesites");

//string ReadValueOfList(List<Student> students, string promt)
//{
//    string text = string.Empty;
//    do
//    {
//        Console.Write($"{promt}");
//        text = Console.ReadLine().Trim();

//    }
//    while (string.IsNullOrWhiteSpace(text) && !students.Any(x => x.Name == text));

//    return text;
//}