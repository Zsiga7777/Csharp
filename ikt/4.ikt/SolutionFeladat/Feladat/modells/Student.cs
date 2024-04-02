
public class Student
{
    public string Name {  get; set; }

    public int StudentId { get; set; }

    public string Class { get; set; }

    public string Address { get; set; }

    public Student() { }

    public Student(string name, int studentId, string @class, string address)
    { 
    Name = name;
        StudentId = studentId;
        Class = @class;
        Address = address;
    }

    public override string ToString()
    {
        return $"{Name} {Class}";
    }
}

