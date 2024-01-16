    internal class Music
    {
    public string Name { get; set; }
    public int Number { get; set; }
    public int Length {  get; set; }
    public int Minute =>(int) Math.Floor((double)Length / 60);
    public int Secondum => Length - Minute*60;

    public Music() { }
    public Music(string name, int number, int lenght)
    {
        Name = name;
        Number = number;
        Length = lenght;
    }

    public override string ToString()
    {
        return $"{Number} – {Name} ({Minute}:{Secondum}) ";
    }
}

