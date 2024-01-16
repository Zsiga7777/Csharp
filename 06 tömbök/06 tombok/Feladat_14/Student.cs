    internal class Student
    {
    public string Name {  get; set; }
    public int Saving { get; set; }

    public Student() { }

    public Student(string name, int saving)
    {
        Name = name;
        Saving = saving;
    }

    public override string ToString()
    {
        return $"Tanluló neve: {Name}, az általa szerzett megtakarítás: {Saving}";
    }
}

