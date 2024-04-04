
    public class JoinedStudentData
    {
    public string Name { get; set; }
    public string Class { get; set; }
    public string Address { get; set; }
    public Dictionary<string, ICollection<int>> Subjects { get; set; }
    public int Id { get; set; }

    public JoinedStudentData() { }

    public JoinedStudentData(string name, string @class, string address, Dictionary<string, ICollection<int>> subjects, int id)
    {
        Name = name;
        Class = @class;
        Address = address;
        Subjects = subjects;
        Id = id;
    }
}

