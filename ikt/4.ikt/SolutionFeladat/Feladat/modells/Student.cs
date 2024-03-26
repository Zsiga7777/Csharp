
public class Student
{
    public string Name {  get; set; }

    public ICollection<Subject> Subjects { get; set; }

    public string Class { get; set; }

    public string Address { get; set; }

    public Student() { }

    public Student(string name, ICollection<Subject> subjects, string @class, string address)
    { 
    Name = name;
        Subjects = subjects;
        Class = @class;
        Address = address;
    }

    public override string ToString()
    {
        return $"{Name} {Class}";
    }
}

