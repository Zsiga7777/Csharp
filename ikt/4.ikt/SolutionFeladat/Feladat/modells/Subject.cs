 public class Subject
    {
    public string Name { get; set; }

    public ICollection<int> Marks { get; set; } 

    public Subject() { }

    public Subject(string name, ICollection<int> marks)
    { 
        Name = name;
        Marks = marks;
    }
    }

