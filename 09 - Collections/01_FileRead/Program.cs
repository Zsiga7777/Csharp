﻿using _01_FileRead.Enums;
using System;

List<Student> students = await FileService.ReadFromFileAsyncMethod1("adatok.txt");


//1 - Írjuk ki minden diák adatát a képernyőre!
students.WriteCollectionToConsole<Student>();

//2 - Hány diák jár az osztályba?
Console.WriteLine($"Az  oszttályba {students.Count} diák jár");

//3 - Mennyi az osztály átlaga?
double average = students.Average(s => s.Average);
Console.WriteLine($"Az  oszttály átlaga {average:F2} diák jár");

//4 - Keressük a legtöbb pontot elért érettségizőt és írjuk ki az adatait a képernyőre.
Student bestStudent = students.MaxBy(s => s.Average);
Console.WriteLine($"Az  oszttály legjobb tanulója: {bestStudent}");

//5 - atlagfelett.txt allományba keressük ki azon tanulókat kiknek pontjai meghaladják az átlagot!
List<Student> studentsAboveAverage = students.Where(s => s.Average > average).ToList();

await FileService.WriteToFileV1Async("atlagFelett", studentsAboveAverage);

//6 - Van e kitünő tanulónk?
bool goodStudent = students.Any(s => s.Average == 5);
Console.WriteLine($"{(goodStudent ? "Van" : "Nincs")} kitűnő tanuló");

//7 - Hány elégtelen, elégséges, jó, jeles és kitünő tanuló van az osztályban?
//    Értékhatárok:
//	-elégtelen, ha: 0.00 - 1.99
//    - elégséges, ha: 2.00 - 2.99
//    - jó, ha: 3.00 - 3.99
//    - jeles, ha: 4.00 - 4.99
//    - kitünő, ha: 5.00

Dictionary<Grade, int> gradesCount = new Dictionary<Grade, int>()
{
    [Grade.Elegtelen] = students.Count(s => s.Grade == Grade.Elegtelen),
    [Grade.Elegseges] = students.Count(s => s.Grade == Grade.Elegseges),
    [Grade.Jo] = students.Count(s => s.Grade == Grade.Jo),
    [Grade.Jeles] = students.Count(s => s.Grade == Grade.Jeles),
    [Grade.Kituno] = students.Count(s => s.Grade == Grade.Kituno),

};

Dictionary<Grade, int> gradesCountV2 = new Dictionary<Grade, int>();
foreach (Grade grade in Enum.GetValues<Grade>())
{
    gradesCountV2[grade] = students.Count(s => s.Grade == grade);
}

foreach (KeyValuePair<Grade, int> grade in gradesCountV2)
{
    Console.WriteLine($"{grade.Key} : {grade.Value} db");
}

//Dictionary<string,int> sumOfRatings =DataService.GetSumOfRatings(students) ;
//.WrsumOfRatingsiteCollectionToConsole();
