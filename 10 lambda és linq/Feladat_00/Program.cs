List<Student> students = new List<Student>
{
    new Student("Hetfo Henrik",10,154),
    new Student("Kedd Kinga",13,250),
    new Student("Szerda Szilárd",9,98),
    new Student("Csütörtök Csongot",11,198),
    new Student("Péntek Petra",13,245),
    new Student("Szombat Szimonetta",10,152),
    new Student("Vasárnap Virág",13,221)
};

// ki érte el a legnagyobb pontszámot?

int maxPoints = students.Max(s => s.Points);

// ki  a legtöbb pontot elért diák?

Student bestStudent = students.MaxBy(s => s.Points);

// legkisebb pontszám

int minPoints = students.Min(s => s.Points);

// ki  a legkevesebb pontot elért diák?

Student worstStudent = students.MinBy(s => s.Points);

// keresse ki a diakok neveit

List<string> studentNames = students.Select(s => s.Name).ToList();

// azon diákok nevei, akik pontszáma meghaladja a 200 pontot 

List<string> studentNamesWithMoreThan200Points = students.Where(s => s.Points > 200).Select(s => s.Name).ToList();

// keressük ki a diákok neveit ABC szerint növekvő sorrendbe 
List<string> orderedStudentsName = students.OrderBy(s => s.Name)
                                           .Select(s => s.Name)
                                           .ToList();

// keressük ki a diákok neveit ABC szerint növekvő sorrendbe
// majd pontok alapján csökkenő sorrendbe
List<string> orderedStudentsNameAndPoints = students.OrderBy(s => s.Name)
                                                    .ThenByDescending(s =>s.Points)
                                                    .Select(s => s.Name)
                                                    .ToList();

//rendezzük osztályok alapján csökkenő sorrrendbe
// pontok alapján csökkenő sorrendbe a diákok neveit

List<string> orderedStudentsByGrade = students.OrderByDescending(s => s.Grade)
                                              .ThenByDescending(s => s.Points)
                                              .Select(s => s.Name)
                                              .ToList();

//évfolyamonként elért pontszámok, évfolyam szerint csökkenő sorrendben

var valmai = students.GroupBy(s => s.Grade)
                     .Select(group => new { classId = group.Key,
                                     pointSum = group.Sum(s => s.Points)})
                     .OrderByDescending(g => g.pointSum);
