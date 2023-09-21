using System;

Console.Write("Please enter a number of a day: ");
int day = int.Parse(Console.ReadLine());

string dayName = day switch
{
    1 => "hetfo",
    2 => "kedd",
    3 => "szerda",
    4 => "csutortok",
    5 => "pentek",
    6 => "szombat",
    7 => "vasarnap",
    _ => "Nincs ilyen nap",
};

Console.WriteLine(dayName);
Console.ReadKey();