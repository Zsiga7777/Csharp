using Custom.Library.ConsoleExtensions;

const int NUMBEROFMUSICS = 3;
Random random = new Random();

Music[] musics = GetMusics();

Console.Clear();
double sumLength = musics.Sum(m => m.Length) /60;
Console.WriteLine($"A lemez hossza: {sumLength:F2} perc.");

double averageLength = musics.Average(m => m.Length);
Console.WriteLine($"\nA lemezek átlagos hossza: {averageLength:F2} másodperc");

int smallestLenght = musics.Min(m => m.Length);
Music[] shortestMusics = musics.Where(m => m.Length == smallestLenght).ToArray();
Console.WriteLine("\nA legrövidebb zene(k): ");
WriteMusicTitle(shortestMusics);

bool musicWithLongerLengthThan4Min = musics.Any(m => m.Length > 240);
Console.WriteLine($"\nVan-e 4 percnél hosszab zene: {(musicWithLongerLengthThan4Min ? "igen" : "nem")}");

Music[] GetMusics()
{
    Music[] musics = new Music[NUMBEROFMUSICS];
    int number = 0;
    string name = "";
    int lenght = 0;

    for (int i = 0; i < NUMBEROFMUSICS; i++)
    {
        name = ExtendentConsole.ReadString("Kérem a zene címét: ");
        number = i + 1;
        lenght = random.Next(20, 501);
        musics[i] = new Music(name, number,lenght);
    }
    return musics;

}

void WriteMusicTitle(Music[] musics)
{
    foreach (var music in musics)
    {
        Console.WriteLine(music.Name);
    }
}