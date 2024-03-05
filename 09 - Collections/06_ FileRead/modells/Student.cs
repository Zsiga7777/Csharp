    public class Student
    {
        public string Name { get; set; }
    public string Class { get; set; }

    public int StartingDay { get; set; }

    public int EndingDay { get; set;}

    public int MissedHours { get; set; }

    public Student() { }

    public Student(string name, string @class, int startingDay, int endingDay, int missedHours)
    {
        Name = name;
        Class = @class;
        StartingDay = startingDay;
        EndingDay = endingDay;
        MissedHours = missedHours;
    }

    public override string ToString()
    {
        return $"{Name} ({Class})";
    }
}

