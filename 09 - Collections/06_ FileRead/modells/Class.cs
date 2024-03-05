
    public class Class
    {
    public string ClassName { get; set; }

    public int NumberOfMissingHours { get; set; }

    public Class() { }
    public Class(string className, int numberOfMissingHours) 
    {
        ClassName = className;
        NumberOfMissingHours = numberOfMissingHours;
    }

    public override string ToString()
    {
        return $"{ClassName};{NumberOfMissingHours}";
    }
}

