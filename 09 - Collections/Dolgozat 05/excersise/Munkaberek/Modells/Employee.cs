public class Employee
    {
    public string Name { get; set; }

    public string Project { get; set; }

    public ICollection<int> WeeklyWorkedHours { get; set; } = new List<int>();

    public int SumOfHours => WeeklyWorkedHours.Sum();

    public int Payment => SumOfHours * 10000;

    public int MostWorkedHours => WeeklyWorkedHours.Max();

    public Weekday MostWorkedHoursDay
    {
        get {
            List<Weekday> weekdays = Enum.GetValues(typeof(Weekday)).Cast<Weekday>().ToList();
            int index = WeeklyWorkedHours.ToList().IndexOf(MostWorkedHours);
            return weekdays[index];
        }
    }

    public Rating Rating => SumOfHours switch
    {
        >30 => Rating.Excellent,
        >21 => Rating.Average,
        _ => Rating.Bad
    } ;
    public Employee() { }

    public Employee(string name, string project, ICollection<int> weeklyWorkedHours)
    {
        Name = name;
        Project = project;
        WeeklyWorkedHours = weeklyWorkedHours;
    }
}

