int starter;
int ender;
bool Isnumber = false;
int sum = 0;
bool counter = true;

do
{
    Console.Write("Please enter a starter value: ");
    string input = Console.ReadLine();

    Isnumber = int.TryParse(input, out starter);
}
while (!Isnumber);
Isnumber = false;
do
{
    Console.Write("Please enter an end value that is bigger than the previous number: ");
    string input = Console.ReadLine();

    Isnumber = int.TryParse(input, out ender);
}
while (!Isnumber || ender < starter);

//for (int i = starter; i <= ender; i++)
//{
//        sum += i * (counter ? 1 : (-1));
//        counter = !counter;
//}

int valami = 1;
for (int i = starter; i <= ender; i++)
    {
           sum += i * valami;
           valami *= -1;
    }

    Console.WriteLine(sum);