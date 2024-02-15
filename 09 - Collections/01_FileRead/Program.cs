﻿using System;

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

