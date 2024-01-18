using Custom.Library.ConsoleExtensions;

const int NUMBEROFMUSICS = 10;
Random random = new Random();

Music[] musics = GetMusics();

Console.Clear();
double sumLength = musics.Sum(m => m.Length) /(double)60;
Console.WriteLine($"A lemez hossza: {sumLength:F2} perc.");

double averageLength = musics.Average(m => m.Length);
Console.WriteLine($"\nA lemezek átlagos hossza: {averageLength:F2} másodperc");

int smallestLenght = musics.Min(m => m.Length);
Music[] shortestMusics = musics.Where(m => m.Length == smallestLenght).ToArray();
Console.WriteLine("\nA legrövidebb zene(k): ");
WriteMusicTitle(shortestMusics);

bool musicWithLongerLengthThan4Min = musics.Any(m => m.Length > 240);
Console.WriteLine($"\nVan-e 4 percnél hosszab zene: {(musicWithLongerLengthThan4Min ? "igen" : "nem")}");

int largestLength = musics.Max(m => m.Length);
int indexOfLongestMusic = GetMusicIndex(musics, largestLength);
Console.WriteLine($"\nA leghosszabb zeneszám {indexOfLongestMusic}-ik a lemezen.");

Music?[] sameLengthMusic = GetSameLengthsongs(musics) ;
Console.WriteLine($"\n2 egyenlő hosszúságú zene: {(sameLengthMusic != null ? "Vannak ilyen zenék" : "Nincsenek ilyen zenék")} ");
WriteToConsole(sameLengthMusic);
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

int GetMusicIndex(Music[] musics, int number)
{
    int index = 0;
    for (int i = 0; i < NUMBEROFMUSICS; i++)
    {
        if (musics[i].Length == number)
        {
            index = i + 1;
            break;
        }
    }

    return index;
}

Music?[] GetSameLengthsongs(Music[] musics)
{
    Music?[] result = null;

    for (int i = 0; i < NUMBEROFMUSICS; i++)
    {
        for (int j = 0; j < NUMBEROFMUSICS; j++)
        {
            if (musics[i].Length == musics[j].Length && i != j)
            {
                result = new Music[] { musics[i], musics[j] };

                break;
            }
        }
    }

    return result;
};

void WriteToConsole(Music[] musics)
{
    foreach (var music in musics)
    {
        Console.WriteLine(music);
    }
}