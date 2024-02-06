﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;

List<Motorcycle> LoadData()
{
    FileStream fs = new FileStream("./../../../data.json", FileMode.Open, FileAccess.Read, FileShare.None);
    StreamReader sr = new StreamReader(fs, Encoding.UTF8);
    
    string jsonData = sr.ReadToEnd();
    return JsonSerializer.Deserialize<List<Motorcycle>>(jsonData);
    
}

void WriteToConsole(string text, ICollection<Motorcycle> motorcycles)
{
    Console.WriteLine(text);
    Console.WriteLine(string.Join('\n', motorcycles));
}

void WriteSingleToConsole(string text, Motorcycle motorcycle)
{
    Console.WriteLine(text);
    Console.WriteLine(motorcycle);
}


List<Motorcycle> motorcycles = LoadData();
WriteToConsole("Data", motorcycles);

// 1 - Hány motorkerékpár van az 'adatbázisban' ?
int numberOfMotorcycles = motorcycles.Count;

// 2 - Hány 'Honda' gyártmányú motorkerékpár van az 'adatbázisban' ?
int numberOfHondas = motorcycles.Count(m => m.Brand == "Honda");

// 3 - Mekkora a legnyaobb köbcenti az 'adatbázisban' ?
int biggestCubicCentiMetre = motorcycles.Max(m => m.Cubic);

// 4 - Melyik a legkisebb végsebesség az 'adatbázisban' ?
int smallestSpeed = motorcycles.Min( m => m.TopSpeed);

// 5 - Van e olyan motorkerékpár az 'adatbázisban' amelyet 1960 előtt gyártottak?
bool motorMadeBefore1960 = motorcycles.Any(m => m.ReleaseYear < 1960);

// 6 - Van-e 'Honda' gyártmányú motorkerképár az 'adatbázisban' melynek beceneve 'Hornet' ?
bool hondaMotorWithNicknameHornet = motorcycles.Any(m => m.Nickname.ToLower() == "hornet" && m.Brand == "Honda");

// 7 - Keressük ki a 'Yamaha' gyártmányú motorkerékpárokat!
List<Motorcycle> motorsMadeByYamaha = motorcycles.Where(m => m.Brand == "Yamaha").ToList();

// 8 -Keressük a 'Suzuki' gyártotmányú motorkerékpárokat melyek 600ccm felett vannak!
List<Motorcycle> motorsMadeBySuzukiAndOver600ccm = motorcycles.Where(m => m.Brand == "Suzuki" && m.Cubic >600).ToList();

// 9 - Keressük ki a 'Kawasaki' gyártotmányú motorkerékpárokat, melyek sebesságe nagyobb min 150km/h!
List<Motorcycle> motorsMadeByKawasakiAndSpeedOver150 = motorcycles.Where(m => m.Brand == "Kawasaki" && m.TopSpeed > 150).ToList();

// 10 - Keressük ki a 'BMW' gyártotmányú motorkerékpárokat, melyeket 2010 előtt gyárottak és a motor köbcentije minimum 1000!
List<Motorcycle> motorsMadeByBMWAndBefor2010AndOver1000ccm = motorcycles.Where(m => m.Brand == "BMW" && 
                                                                        m.Cubic >=1000 && m.ReleaseYear < 2010).ToList();


// 12 - Keressül a motorkerékpárok beceneveit (nickname)!
List<string> motorsNicknames = motorcycles.Select(m => m.Nickname).ToList();

// 13 - Keressük azokat a motorkerékpárokat, melyek neveiben szerepel 'FZ' kifejezés!
List<Motorcycle> motorsWithFZinTheirNicknames = motorcycles.Where(m => m.Nickname.ToLower().Contains("fz")).ToList();

// 14 - Keressük azokat a motorkerékpárokat, melyek nevei 'C' betűvel kezdődnek!
List<Motorcycle> motorsWithStartingLetterC = motorcycles.Where(m => m.Nickname.ToLower().StartsWith("c")).ToList();

// 15 - Keressük az első motorkerékpárt az 'adatbázisunkból'!
Motorcycle firstMotor = motorcycles.First();

// 16 - Keressük az utolsó motorkerékpárt az 'adatbázisunkból'!
Motorcycle lastMotor = motorcycles.Last();

// 17 - Rendezzük növekvő sorrendbe gyártási év alapján az 'adatbázisban' szereplő motorkerékpárokat.
List<Motorcycle> orderdListByYear = motorcycles.OrderBy(m => m.ReleaseYear).ToList();

// 18 - Rendezzük csökkenő sorrendbe a 'Honda' által gyártott motorkerékpárokat, melyek teljesítménye legalább 25kW és 2005 után gyártották őket.
List<Motorcycle> orderedListOfHondas = motorcycles.Where(m => m.Brand == "Honda" && m.KW >=25 && m.ReleaseYear > 2005)
                                                   .OrderByDescending(m => m.KW).ToList();

// 19 - Melyek azok a  motorkerékpárok, melyek nem rendelkeznek becenévvel?
List<Motorcycle> motorsWithNicknames = motorcycles.Where(m => m.Nickname.Length > 1).ToList();

// 20 - Mekkora az 'adatbázisban' szereplő motorkerékpárok sebességének az átlaga?
double averageSpeed = motorcycles.Average(m => m.TopSpeed);

// 21 - Melyik a legyorsabb motorkerékpár? Feltételezzük, hogy csak egy ilyen van!
Motorcycle fastestMotor = motorcycles.MaxBy(m => m.TopSpeed);

// 22 - Hány kategória található meg az 'adatbázisban'?
int numberOfCategories = motorcycles.Select(m => m.Category).Distinct().Count();

// 23 - Határozza meg az 'adatbázisban' talalható motorkerékpárok átlag életkorát!
double averageAgeOfMotors = motorcycles.Average(m => DateTime.Now.Year - m.ReleaseYear);

// 24 - Van-e 'Java' gyártmányú motorkerékpár az 'adatbázisban'?
bool isThereMotorMadeByJava = motorcycles.Any(m => m.Brand.ToLower() == "java");

// 25 - Rendezzül növekvő sorrende az 5 betűvel rendelkező gyártók motorkerékpárjait,
//         majd csökkenő sorrendbe gyártási év alapján és az eredményben csak a nevet és
//         a gyártási évet jelenítse meg!

List<MotorOrdered> motorOrdereds = motorcycles.Where(m => m.Brand.Length == 5)
                                               .OrderBy(m => m.Brand)
                                               .ThenByDescending(m => m.ReleaseYear)
                                               .Select(m => new MotorOrdered 
                                               {
                                                    MotorName = m.Nickname,
                                                    ReleasYear = m.ReleaseYear,
                                               } )
                                               .ToList();

Console.ReadLine();
