using IOlibrary;
using System.Drawing;
string name = ExtendentConsole.ReadString("Kérem a nevét: ");
int length = name.Length;
string color = "White";
color = length switch
{
    0 => "Black",
    1 => "DarkBlue",
    2 => "DarkGreen",
    3 => "DarkCyan",
    4 => "DarkRed",
    5 => "DarkMagenta",
    6 => "DarkYellow",
    7 => "Gray",
    8 => "DarkGray",
    9 => "Blue",
    10 => "Green",
    11 => "Cyan",
    12 => "Red",
    13 => "Magenta",
    14 => "Yellow",
    15 => "White",
    _ => "White",
};

Console.ForegroundColor = ConsoleColor.;