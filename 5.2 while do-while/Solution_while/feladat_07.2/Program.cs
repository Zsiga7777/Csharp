﻿int number1 = 0;
int number2 = 0;
int stepRate = 0;
bool Isnumber = false;
int difference = 0;

while (!Isnumber) 
{
    Console.Write("Kérek egy számot: ");
    string input = Console.ReadLine();

    Isnumber = int.TryParse(input, out number1);
}

while (!Isnumber || number2 < number1) 
{
    Console.Write("Kérek egy másik, az előzőnél nagyobb számot: ");
    string input = Console.ReadLine();

    Isnumber = int.TryParse(input, out number2);
}

difference = number2 - number1;
Isnumber = false;

while (!Isnumber || difference < stepRate) 
{
    Console.Write("Kérek a lépésközt, ami kisebb a két szám különbségénél: ");
    string input = Console.ReadLine();

    Isnumber = int.TryParse(input, out stepRate);
}

for (int i = number2; i > number1; i -= stepRate)
{
    Console.Write($"{i}; ");
}